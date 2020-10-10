using PrintStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PrintStore.ViewModel
{
    public class EditorViewModel
    {
        public int templateId { get; set; }
        public int CategoryId { get; set; }
        public TemplateSerializer Template { get; set; }
    }
}
