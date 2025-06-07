using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Model.Base;

namespace Entity.Dtos.CursoDTO
{
    public class CursoDto : GenericDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}