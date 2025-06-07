using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factory
{
    public class ServiceFactory
    {
        public static IEstudianteService CreateEstudianteService(IEstudianteRepository repo, IMapper mapper)
        {
            return new EstudianteService(repo, mapper);
        }

        public static ICursoService CreateCursoService(ICursoRepository repo, IMapper mapper)
        {
            return new CursoService(repo, mapper);
        }

        public static IMatriculaService CreateMatriculaService(IMatriculaRepository repo, IMapper mapper)
        {
            return new MatriculaService(repo, mapper);
        }
    }
}
