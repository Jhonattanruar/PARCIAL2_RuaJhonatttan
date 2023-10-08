
using System.ComponentModel.DataAnnotations;

namespace PARCIAL2_RuaJhonattan.DAL.Entities
{
    public class PersonaNatural : Entity
    {
        
        [Display(Name ="Full Name")]
        [MaxLength(100, ErrorMessage="El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "¡El campo {0} es requerido!")]

        public String FullName { get; set; }
        public String Email { get; set; }
        public int BirthYear { get; set; }
        public int Age { get; set; }

    }
}
