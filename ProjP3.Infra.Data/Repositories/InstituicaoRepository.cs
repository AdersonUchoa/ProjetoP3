using Microsoft.EntityFrameworkCore;
using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Domain.Models;
using ProjP3.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Infra.Data.Repositories
{
    public class InstituicaoRepository : Repository<Instituicao>, IInstituicaoRepository
    {
        public InstituicaoRepository(P3DbContext context) : base(context)
        {
        }
        
        public async Task<List<Instituicao>> GetInstituicaoBySiglaAsync(string sigla)
        {
            return await _context.Instituicaos
                .Where(i => i.TxSigla.Contains(sigla.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Instituicao>> GetInstituicaoByDescricaoAsync(string descricao)
        {
            return await _context.Instituicaos
                .Where(i => i.TxDescricao.Contains(descricao.ToLower()))
                .ToListAsync();
        }

        //public async Task<bool> JaExisteCursoNaInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        //{
        //    return await _context.Instituicaos
        //        .Where(i => i.IdInstituicao == idInstituicao)
        //        .AnyAsync(i => i.Cursos.Any(c => c.IdCurso == idCurso));
        //}

        public async Task<List<Instituicao>> GetInstituicoesByCursoAsync(ulong idCurso)
        {
            return await _context.Instituicaos
                .Where(i => i.Cursos.Any(c => c.IdCurso == idCurso))
                .ToListAsync();
        }

        public async Task<bool> ExistsByDescricaoAsync(string descricao)
        {
            return await _context.Instituicaos
                .AnyAsync(i => i.TxDescricao.Equals(descricao.ToLower()));
        }

        //public async Task<Curso?> GetCursoNaInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        //{
        //    return await _context.Instituicaos
        //        .Where(i => i.IdInstituicao == idInstituicao)
        //        .SelectMany(i => i.Cursos)
        //        .FirstOrDefaultAsync(c => c.IdCurso == idCurso);
        //}

        //public void RemoverCursoNaInstituicao(Curso curso)
        //{
        //    _context.Cursos.Remove(curso);
        //}
    }
}
