using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    internal interface AlunoIRepository : IRepository
    {
        Task<Aluno> GetAlunoByNome(string nome);
        Task<Aluno> GetDisciplinasByAluno (ulong idAluno);
    }
}
