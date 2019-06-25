using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Amount In Stock")]
        public int InventoryCount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Is this Food?")]
        public bool IsFood { get; set; }
    }
}