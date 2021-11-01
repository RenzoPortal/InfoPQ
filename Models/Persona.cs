using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPQ.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
    }
}
