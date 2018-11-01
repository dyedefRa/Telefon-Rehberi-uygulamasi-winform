namespace Nteir.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public Kullanici()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(20)]
        public string Parola { get; set; }
    }
}
