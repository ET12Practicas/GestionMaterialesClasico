using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace gestionmateriales.Models
{
    public class ComprasViewModels
    {
        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaFin { get; set; }

        [Required]
        public List<ItemCompra> items { get; set; }

        public ComprasViewModels ()
        {
            items = new List<ItemCompra>();
        }
        
    }

    public class ItemCompra
    {
        [Required]
        public int idMaterial { get; set; }

        [Required]
        [StringLength(75)]
        public string nombre { get; set; }

        [Required]
        public int stockActual { get; set; }

        [Required]
        public int cantNecesaria { get; set; }

        [Required]
        public int stockRemanente { get; set; }
    }
}