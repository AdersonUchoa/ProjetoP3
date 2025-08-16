using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno?> GetAlunoByNomeAsync(string nome);
        Task<bool> ExistsByNomeAsync(string nome);
        Task<List<Aluno>> GetAlunosByDisciplinaAsync(int idDisciplina);
    }
}
