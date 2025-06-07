using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.EstudianteDTO;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repo;
        private readonly IMapper _mapper;

        public EstudianteService(IEstudianteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EstudianteDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EstudianteDto>>(list);
        }

        public async Task<EstudianteDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<EstudianteDto>(entity);
        }

        public async Task<EstudianteDto> CreateAsync(EstudianteDto dto)
        {
            var entity = _mapper.Map<Estudiante>(dto);
            var result = await _repo.AddAsync(entity);
            return _mapper.Map<EstudianteDto>(result);
        }

        public async Task<EstudianteDto> UpdateAsync(int id, EstudianteDto dto)
        {
            var entity = _mapper.Map<Estudiante>(dto);
            var result = await _repo.UpdateAsync(entity);
            return _mapper.Map<EstudianteDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
