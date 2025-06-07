using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Matricula : BaseEntity
    {
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
