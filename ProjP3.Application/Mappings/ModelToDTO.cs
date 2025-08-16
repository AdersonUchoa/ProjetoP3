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
            CreateMap<ProjP3.Domain.Models.Aluno, AlunoCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Aluno, AlunoUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Cursa, CursaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, CursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, CursoCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Curso, CursoUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Disciplina, DisciplinaUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Instituicao, InstituicaoUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Professor, ProfessorUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoCurso, TipoCursoUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.TipoDisciplina, TipoDisciplinaUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloCreateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Titulo, TituloUpdateDTO>().ReverseMap();
            CreateMap<ProjP3.Domain.Models.Leciona, LecionaDTO>().ReverseMap();
        }
    }
}
