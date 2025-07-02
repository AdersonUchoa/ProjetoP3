using AutoMapper;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
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
            CreateMap<ProjP3.Domain.Models.Aluno, AlunoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Aluno, AlunoCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Aluno, AlunoUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Cursa, CursaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, CursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, CursoCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Curso, CursoUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoCreateDTO>();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaCreateDTO>();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloCreateDTO>();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloUpdateDTO>();
            CreateMap<ProjP3.Domain.Models.Leciona, LecionaDTO>().ReverseMap();
        }
    }
}
