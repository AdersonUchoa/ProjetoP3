using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    internal interface ProfessorIRepository : IRepository
    {
        Task<Professor> GetProfessorByNomeAsync(string nome);
        Task<Professor> GetDisciplinasByProfessorAsync(ulong idProfessor);
        Task<List<Professor>> GetProfessoresByTituto(ulong idTitulo);
    }
}
