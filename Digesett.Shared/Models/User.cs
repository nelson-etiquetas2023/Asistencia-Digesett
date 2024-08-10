using System.ComponentModel.DataAnnotations;

namespace Digesett.Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string TypeUser { get; set; } = null!;
        [Required]
        public string Cargo { get; set; } = null!;
        public string Departament { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool Active { get; set; }
    }
}
