using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.Mappings
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO()
        {
            CreateMap<ProjP3.Domain.Models.Aluno, ProjP3.Application.DTOs.AlunoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Cursa, ProjP3.Application.DTOs.CursaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, ProjP3.Application.DTOs.CursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Disciplina, ProjP3.Application.DTOs.DisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Instituicao, ProjP3.Application.DTOs.InstituicaoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Professor, ProjP3.Application.DTOs.ProfessorDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoCurso, ProjP3.Application.DTOs.TipoCursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, ProjP3.Application.DTOs.TipoDisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Titulo, ProjP3.Application.DTOs.TituloDTO>().ReverseMap();
        }
    }
}
