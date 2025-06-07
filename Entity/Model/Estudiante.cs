using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;
namespace Entity.Model
{
    public class Estudiante : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }

        public List<Matricula> Matriculas { get; set; }
    }
}