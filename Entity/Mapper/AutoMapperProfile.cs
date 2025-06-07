using AutoMapper;
using Entity.Model;
using Entity.Dtos.CursoDTO;
using Entity.Dtos.EstudianteDTO;
using Entity.Dtos.MatriculaDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Estudiante
            CreateMap<Estudiante, EstudianteDto>().ReverseMap();

            // Curso
            CreateMap<Curso, CursoDto>().ReverseMap();

            // Matrícula
            CreateMap<Matricula, MatriculaDto>().ReverseMap();
        }
    }
}
