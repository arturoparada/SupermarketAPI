using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del departamento obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        public string? DepartmentName { get; set; }
    }
}
