using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.MatriculaDTO;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repo;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatriculaDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<MatriculaDto>>(list);
        }

        public async Task<MatriculaDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<MatriculaDto>(entity);
        }

        public async Task<MatriculaDto> CreateAsync(MatriculaDto dto)
        {
            var entity = _mapper.Map<Matricula>(dto);
            var result = await _repo.AddAsync(entity);
            return _mapper.Map<MatriculaDto>(result);
        }

        public async Task<MatriculaDto> UpdateAsync(int id, MatriculaDto dto)
        {
            var entity = _mapper.Map<Matricula>(dto);
            var result = await _repo.UpdateAsync(entity);
            return _mapper.Map<MatriculaDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
