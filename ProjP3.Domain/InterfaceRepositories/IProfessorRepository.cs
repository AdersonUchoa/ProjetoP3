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
        Task<Professor?> GetProfessoresByNomeAsync(string nome);
        Task<List<Professor>> GetProfessoresByTituloAsync(int idTitulo);
        Task<Titulo?> GetTituloByProfessorAsync(int idProfessor);
        Task<List<Professor>> GetProfessoresByDisciplinaAsync(int idDisciplina);
        Task<bool> ExistsByNomeAsync(string nome);
    }
}
