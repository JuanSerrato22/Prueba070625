using Entity.Dtos.EstudianteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEstudianteService
    {
        Task<IEnumerable<EstudianteDto>> GetAllAsync();
        Task<EstudianteDto?> GetByIdAsync(int id);
        Task<EstudianteDto> CreateAsync(EstudianteDto dto);
        Task<EstudianteDto> UpdateAsync(int id, EstudianteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
