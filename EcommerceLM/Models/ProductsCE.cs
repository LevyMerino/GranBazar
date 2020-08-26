using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceLM.Models
{
    public class ProductsCE
    {
        [Required]
        [Display(Name = "'Nombre del producto'")]
        public string NameProduct { get; set; }
        [Required]
        [Display(Name = "'Precio'")]
        public Nullable<double> Price { get; set; }
        [Required]
        [Display(Name = "'Oferta'")]
        public Nullable<bool> Sale { get; set; }
        [Required]
        [Display(Name = "'Categoría'")]
        public Nullable<int> Category { get; set; }
    }
    [MetadataType (typeof(ProductsCE))]
    public partial class Products
    {
    }
}