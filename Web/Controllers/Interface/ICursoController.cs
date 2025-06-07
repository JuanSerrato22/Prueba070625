using Entity.Dtos;
using Entity.Dtos.CursoDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface ICursoController
    {
        Task<ActionResult<IEnumerable<CursoDto>>> GetAll();
        Task<ActionResult<CursoDto>> GetById(int id);
        Task<ActionResult<CursoDto>> Create(CursoDto dto);
        Task<ActionResult<CursoDto>> Update(int id, CursoDto dto);
        Task<ActionResult<bool>> Delete(int id);
    }
}