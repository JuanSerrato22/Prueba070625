using Entity.Dtos.CursoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoDto>> GetAllAsync();
        Task<CursoDto?> GetByIdAsync(int id);
        Task<CursoDto> CreateAsync(CursoDto dto);
        Task<CursoDto> UpdateAsync(int id, CursoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
