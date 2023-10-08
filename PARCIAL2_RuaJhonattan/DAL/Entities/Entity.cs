using System.ComponentModel.DataAnnotations;

namespace PARCIAL2_RuaJhonattan.DAL.Entities
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }
        [Display(Name ="Fecha de creacion")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? ModiedDate { get; set; }
    }
}
