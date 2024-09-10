using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Digesett.Shared.Models
{
    public class PoncheRegistro
    {
        public int Id { get; set; }
        public string Empleado { get; set; } = null!;
        public DateTime RecordTime { get; set; }
        public int Indexday { get; set; }
        public string StringNameDate { get; set; } = null!;
        public string Marca1 { get; set; } = null!;
        public string Marca2 { get; set; } = null!;
        public string Marca3 { get; set; } = null!;
        public string Marca4 { get; set; } = null!;
        public Int64 NumbersPonches { get; set; }
        public string Departamento { get; set; } = null!;
        public string Cargo { get; set; } = null!;
    }
}
