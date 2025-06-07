using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entity.Dtos.EstudianteDTO;

namespace Web.Controllers.Interface
{
    public interface IEstudianteController
    {
        Task<ActionResult<IEnumerable<EstudianteDto>>> GetAll();
        Task<ActionResult<EstudianteDto>> GetById(int id);
        Task<ActionResult<EstudianteDto>> Create(EstudianteDto dto);
        Task<ActionResult<EstudianteDto>> Update(int id, EstudianteDto dto);
        Task<ActionResult<bool>> Delete(int id);
    }
}