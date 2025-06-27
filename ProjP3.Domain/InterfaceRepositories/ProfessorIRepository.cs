using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface ProfessorIRepository : IRepository<Professor>
    {
        Task<Professor?> GetProfessorByNomeAsync(string nome);
        Task<List<Disciplina>> GetDisciplinasByProfessorAsync(ulong idProfessor);
        Task<List<Professor>> GetProfessoresByTitulo(ulong idTitulo);
    }
}
