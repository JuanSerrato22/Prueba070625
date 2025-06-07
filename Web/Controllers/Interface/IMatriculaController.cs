using Entity.Dtos;
using Entity.Dtos.MatriculaDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers.Interfaces
{
    public interface IMatriculaController
    {
        Task<ActionResult<IEnumerable<MatriculaDto>>> GetAll();
        Task<ActionResult<MatriculaDto>> GetById(int id);
        Task<ActionResult<MatriculaDto>> Create(MatriculaDto dto);
        Task<ActionResult<MatriculaDto>> Update(int id, MatriculaDto dto);
        Task<ActionResult<bool>> Delete(int id);
    }
}
