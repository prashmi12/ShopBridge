using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class ProductDetails
    {
        [ServiceStack.DataAnnotations.PrimaryKey]
        [Required]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string ProductName { get; set; }
        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Product Description is required")]
        [StringLength(100, MinimumLength = 10)]
        public string ProductDescription { get; set; }
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Product Price is required")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}