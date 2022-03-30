using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SupermarketAPI.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del producto obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Producto")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Todos los articulos deben pertenecer a un departamento")]
        [Display(Name = "Departamento")]
        public string Department { get; set; }

        [Display(Name = "Descripción")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Se debe capturar la existencia")]
        [Display(Name = "Inventario")]
        public int Inventory { get; set; }

        [Required(ErrorMessage = "Se debe capturar el precio")]
        [Display(Name = "Precio")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Articulo activo/inactivo")]
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Display(Name = "Perecedero")]
        public bool? Perishable { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de caducidad")]
        public DateTime? Expirationdate { get; set; }  

    }
}
