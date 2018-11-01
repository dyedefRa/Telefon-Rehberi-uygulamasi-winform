namespace Nteir.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rehber")]
    public partial class Rehber
    {

        public Rehber()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Ad { get; set; }

        [Required]
        [StringLength(30)]
        public string Soyad { get; set; }

        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string Tel3 { get; set; }

        [Required]
        public string Email { get; set; }

        public string WebAdres { get; set; }

        public string Adres { get; set; }

        public string Aciklama { get; set; }

        public override string ToString()
        {
            return $" {this.Ad} {this.Soyad} - Telefon : {this.Tel1}";
        }
    }
}
