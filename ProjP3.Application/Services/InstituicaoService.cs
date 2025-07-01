using AutoMapper;
using ProjP3.Application.InterfaceServices;
using ProjP3.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;
        private readonly IMapper _mapper;

        public InstituicaoService(IInstituicaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
