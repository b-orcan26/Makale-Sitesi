namespace MakaleExample.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Makale")]
    public partial class Makale
    {
        [Key]
        public int makale_id { get; set; }

        [DisplayName("Makale Ýçeriði")]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        [Required]
        public string makale_icerik { get; set; }

        [Required]
        public string makale_baslik { get; set; }

        public int kategori_id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Column(TypeName = "date")]
        public DateTime tarih { get; set; }

        public virtual Kategorilers Kategoriler { get; set; }
    }
}
