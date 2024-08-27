﻿using System.ComponentModel.DataAnnotations;

namespace Digesett.Shared.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public string IdentificationNumber { get; set; } = null!;
        public string IdDepartment { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public Boolean Genero { get; set; }
        public string Title { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string Departament { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public bool Sexo { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
