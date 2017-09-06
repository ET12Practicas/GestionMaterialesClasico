using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table ("ItemOT")]

    public class ItemOT
    {
        [Key]
        [Required]
        public int idItemOT { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public int cantidad { get; set; }

        public ItemOT()
        {
        }
    }
}