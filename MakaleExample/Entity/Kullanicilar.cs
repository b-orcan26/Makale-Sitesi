namespace MakaleExample.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [Key]
        public int kullanici_id { get; set; }

        [DisplayName("Kullanýcý Adý")]
        [Required]
        public string kullanici_ad { get; set; }

        [DisplayName("Þifre")]
        [Required]
        public string kullanici_sifre { get; set; }
    }
}
