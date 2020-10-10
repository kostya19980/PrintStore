using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.Models
{
    public class TemplateSerializer
    {
        public int templateId { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public List<TemplateImage> Images { get; set; }
        public TemplateTexture Texture { get; set; }
        public List<TemplateText> TextBlocks { get; set; }
    }
    public class TemplateImage
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
    }
    public class TemplateTexture
    {
        public string TextureName { get; set; }
        public string TextureSrc { get; set; }
        public string ModelName { get; set; }
        public string ModelSrc { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public List<TextureArea> TextureAreas { get; set; }
    }
    public class TextureArea
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
    }
    public class TemplateText
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public List<Line> Lines { get; set; }
    }
    public class Line
    {
        public List<TextPart> Text { get; set; }
    }
    public class TextPart
    {
        public string Data { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public int FontWeight { get; set; }
        public string FontStyle { get; set; }
        public string TextDecorationLine { get; set; }
        public string TextAlign { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
