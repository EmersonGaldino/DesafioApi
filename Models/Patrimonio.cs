namespace DesafioApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patrimonio")]
    public partial class Patrimonio
    {
        public int PatrimonioId { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [Required]
        [StringLength(50)]
        public string PatrimonioNome { get; set; }

        [Column(TypeName = "text")]
        public string PatrimonioDescricao { get; set; }

        public int? PatrimonioNumTombo { get; private set; }

        //public virtual Marca Marca { get; set; }

        public Patrimonio()
        {
            var random = new Random();
            PatrimonioNumTombo = random.Next(1, 500);
        }
    }
}
