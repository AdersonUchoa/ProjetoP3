using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<Professor?> GetProfessorByNomeAsync(string nome);
        Task<List<Professor>> GetProfessoresByTituloAsync(ulong idTitulo);
        Task<Titulo?> GetTituloByProfessorAsync(ulong idProfessor);
        Task<List<Professor>> GetProfessoresByDisciplinaAsync(ulong idDisciplina);
    }
}
