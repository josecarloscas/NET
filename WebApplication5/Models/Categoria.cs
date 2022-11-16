using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria es Obligatorio")]
        public string NombreCategoria { get; set; }
        [Required(ErrorMessage ="Orden es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage ="El orden debe ser mayor a cero")]
        public int MostrarOrden { get; set; }
    }
}
