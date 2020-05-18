using MakaleExample.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakaleExample.ViewModels
{
    public class CreateViewModel
    {
        
        [DisplayName("Makale İçeriği")]
        [AllowHtml]
        [UIHint("tinymce_full")]
        public string makale_icerik { get; set; }

        [DisplayName("Makale Başlığı")]
        [Required]
        public string makale_baslik { get; set; }

        [DisplayName("Kategori")]
        [Required]
        public int kategori_id { get; set; }

        [DisplayName("Tarih")]
        [Required]
        [Column(TypeName = "date")]
        public DateTime tarih { get; set; }

        public IEnumerable<SelectListItem> Kategoris { get; set; }
        
    }
}