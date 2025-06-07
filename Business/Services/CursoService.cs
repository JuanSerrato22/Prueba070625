using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.CursoDTO;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repo;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CursoDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CursoDto>>(list);
        }

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<CursoDto>(entity);
        }

        public async Task<CursoDto> CreateAsync(CursoDto dto)
        {
            var entity = _mapper.Map<Curso>(dto);
            var result = await _repo.AddAsync(entity);
            return _mapper.Map<CursoDto>(result);
        }

        public async Task<CursoDto> UpdateAsync(int id, CursoDto dto)
        {
            var entity = _mapper.Map<Curso>(dto);
            var result = await _repo.UpdateAsync(entity);
            return _mapper.Map<CursoDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
