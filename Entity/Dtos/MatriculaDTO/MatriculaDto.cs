using Entity.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.MatriculaDTO
{
    public class MatriculaDto : BaseDto
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
