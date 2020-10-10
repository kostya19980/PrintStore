using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PrintStore.Models;
using Microsoft.EntityFrameworkCore;
using PrintStore.ViewModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PrintStore.Controllers
{
    public class EditorController : Controller
    {
        PrintContext db;
        private IHostingEnvironment _env;
        public EditorController(PrintContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        [HttpGet]
        public async Task<ActionResult> Editor(int? templateId)
        {
            Template template = await db.Template.Include(p => p.Product).Include(u => u.User).FirstOrDefaultAsync(x => x.Id == templateId);
            if (template != null)
            {
                string UserName = db.GetUserName(HttpContext);
                if ((template.User!= null && template.User.Login==UserName) || template.Name==UserName)
                {
                    var viewModel = new EditorViewModel
                    {
                        CategoryId = template.Product.CategoryId,
                        templateId = template.Id,
                        Template = JsonSerializer.Deserialize<TemplateSerializer>(template.JsonTemplate)
                    };
                    return View(viewModel);
                }
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }
        [HttpGet]
        public async Task<ActionResult> CreateUserTemplate(int TemplateId)
        {
            Template template = await db.Template.Include(p=>p.Product).FirstOrDefaultAsync(x => x.Id == TemplateId);
            if (template != null)
            {
                Template UserTemplate = new Template
                {
                    Product = template.Product,
                    JsonTemplate = template.JsonTemplate,
                    DateCreated = DateTime.Now.ToShortDateString()
                };
                string UserName = db.GetUserName(HttpContext);
                if (User.Identity.IsAuthenticated)
                {
                    User user = await db.User.Include(t => t.Templates).FirstOrDefaultAsync(x => x.Login == UserName);
                    user.Templates.Add(UserTemplate);
                    db.User.Update(user);
                }
                else
                {
                    UserTemplate.Name = UserName;
                    await db.Template.AddAsync(UserTemplate);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Editor", "Editor", new { templateId = UserTemplate.Id });
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateEmptyTemplate(product product)
        {
            const double pixelSize= 37.938105;
            double width = double.Parse(product.Width) * pixelSize; ;
            double height = double.Parse(product.Height) * pixelSize; ;
            TemplateSerializer TemplateJson = new TemplateSerializer
            {
                Width = width,
                Height = height,
                Images=new List<TemplateImage>(),
                TextBlocks=new List<TemplateText>()
            };
            TemplateImage main_image = new TemplateImage
            {
                Name = "MainImage",
                Src = product.PicturePath,
                Width = width,
                Height = height,
                Top = 0,
                Left = 0,
            };
            TemplateJson.Images.Add(main_image);
            Template NewTemplate = new Template
            {
                ProductId=product.Id,
                Name=product.Name,
                UserId = 1,
                JsonTemplate = JsonSerializer.Serialize<TemplateSerializer>(TemplateJson),
                DateCreated = DateTime.Now.ToShortDateString(),
            };
            await db.Template.AddAsync(NewTemplate);
            await db.SaveChangesAsync();
            product.TemplateId = NewTemplate.Id;
            db.product.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Editor", "Editor", new { templateId = NewTemplate.Id });
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<string> SaveTemplate([FromBody] TemplateSerializer data)
        {
            string webRoot = Path.Combine(_env.WebRootPath,"images");
            string date = DateTime.Now.ToShortDateString();
            string path= Path.Combine(webRoot, date);
            if (!System.IO.File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            for (int i = 0; i < data.Images.Count(); i++)
            {
                if (!data.Images[i].Src.Contains("/images/"))
                {
                    byte[] ImageByte = Convert.FromBase64String(data.Images[i].Src);
                    var file = Path.Combine(path, data.Images[i].Name + ".png");
                    System.IO.File.WriteAllBytes(file, ImageByte);
                    string url = Path.Combine("/images/", date+"/",data.Images[i].Name + ".png");
                    data.Images[i].Src = url;
                }
            }
            if (data.Texture.TextureName != null)
            {
                byte[] MainTexture = Convert.FromBase64String(data.Texture.TextureSrc);
                var MainTextureFile = Path.Combine(path, data.Texture.TextureName);
                System.IO.File.WriteAllBytes(MainTextureFile, MainTexture);
                string TextureUrl = "/images/" + date+"/";
                data.Texture.TextureSrc = TextureUrl;
            }
            Template template = await db.Template.FirstOrDefaultAsync(x => x.Id==data.templateId);
            template.JsonTemplate = JsonSerializer.Serialize<TemplateSerializer>(data);
            db.Template.Update(template);
            await db.SaveChangesAsync();
            return "Макет был успешно сохранён!";
        }
        [HttpGet]
        public async Task<IActionResult> CreatePDF (int TemplateId)
        {
            Template template = await db.Template.Include(u => u.User).FirstOrDefaultAsync(x => x.Id == TemplateId);
            string UserName = db.GetUserName(HttpContext);
            if (template != null)
            {
                if((template.User != null && template.User.Login == UserName) || template.Name == UserName)
                {
                    var data = JsonSerializer.Deserialize<TemplateSerializer>(template.JsonTemplate);
                    PdfDocument document = new PdfDocument();
                    document.Options.ColorMode = PdfColorMode.Cmyk;
                    PdfPage page = document.AddPage();
                    page.Width = data.Width;
                    page.Height = data.Height;
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    for (int i = 0; i < data.Images.Count(); i++)
                    {
                        string path = _env.WebRootPath + data.Images[i].Src.Replace('/', '\\');
                        XImage image = XImage.FromFile(path);
                        gfx.DrawImage(image, data.Images[i].Left, data.Images[i].Top, data.Images[i].Width, data.Images[i].Height);
                        //byte[] ImageByte = Convert.FromBase64String(data.Images[i].Src);
                        //using (var stream = new MemoryStream(ImageByte, 0, ImageByte.Length))
                        //{
                        //    XImage image = XImage.FromStream(stream);
                        //    gfx.DrawImage(image, data.Images[i].Left, data.Images[i].Top, data.Images[i].Width, data.Images[i].Height);
                        //}
                    }
                    for (int i = 0; i < data.TextBlocks.Count(); i++)
                    {
                        for (int j = 0; j < data.TextBlocks[i].Lines.Count(); j++)
                        {
                            Line line = data.TextBlocks[i].Lines[j];
                            for (int k = 0; k < line.Text.Count(); k++)
                            {
                                TextPart text = line.Text[k];
                                XRect rect = new XRect(text.Left, text.Top, text.Width, text.Height);
                                gfx.DrawRectangle(XBrushes.Transparent, rect);
                                XTextFormatter tf = new XTextFormatter(gfx);
                                XFontStyle FontStyle = XFontStyle.Regular;
                                if (text.FontWeight == 700)
                                {
                                    FontStyle = XFontStyle.Bold;
                                }
                                if (text.FontStyle == "italic")
                                {
                                    FontStyle |= XFontStyle.Italic;
                                }
                                if (text.TextDecorationLine == "underline")
                                {
                                    FontStyle |= XFontStyle.Underline;
                                }
                                XFont font = new XFont(text.FontFamily, text.FontSize, FontStyle);
                                if (text.TextAlign == "left")
                                {
                                    tf.Alignment = XParagraphAlignment.Left;
                                }
                                if (text.TextAlign == "right")
                                {
                                    tf.Alignment = XParagraphAlignment.Right;
                                }
                                if (text.TextAlign == "center")
                                {
                                    tf.Alignment = XParagraphAlignment.Center;
                                }
                                tf.DrawString(text.Data, font, XBrushes.Black, rect, XStringFormats.TopLeft);
                            }
                        }
                    }
                    string filename = _env.WebRootPath + "/PdfDocuments/Template" + TemplateId + ".pdf";
                    document.Save(filename);
                    return new PhysicalFileResult(filename, "application/pdf");
                }
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}