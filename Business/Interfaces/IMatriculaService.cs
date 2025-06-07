using Entity.Dtos.MatriculaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMatriculaService
    {
        Task<IEnumerable<MatriculaDto>> GetAllAsync();
        Task<MatriculaDto?> GetByIdAsync(int id);
        Task<MatriculaDto> CreateAsync(MatriculaDto dto);
        Task<MatriculaDto> UpdateAsync(int id, MatriculaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
