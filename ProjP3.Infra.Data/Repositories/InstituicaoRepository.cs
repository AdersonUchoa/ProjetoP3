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
    public class InstituicaoRepository : Repository<Instituicao>, InstituicaoIRepository
    {
        public InstituicaoRepository(P3DbContext context) : base(context)
        {
        }
        
        public async Task<List<Instituicao>> GetInstituicaoBySiglaAsync(string sigla)
        {
            return await _context.Instituicaos
                .Where(i => i.TxSigla.Contains(sigla, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<List<Instituicao>> GetInstituicaoByDescricaoAsync(string descricao)
        {
            return await _context.Instituicaos
                .Where(i => i.TxDescricao.Contains(descricao, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<List<Curso>> GetCursosByInstituicaoAsync(ulong idInstituicao)
        {
            return await _context.Cursos
                .Where(c => c.IdInstituicao == idInstituicao)
                .ToListAsync();
        }

        public async Task<Instituicao> AdicionarCursoAInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        {
            var instituicao = await _context.Instituicaos.FindAsync(idInstituicao);

            if (instituicao == null)
            {
                throw new Exception("Instituição não encontrada.");
            }

            var curso = await _context.Cursos.FindAsync(idCurso);

            if (curso == null)
            {
                throw new Exception("Curso não encontrado.");
            }

            instituicao.Cursos.Add(curso);
            
            return instituicao;
        }

        public async Task<Instituicao> RemoverCursoDeInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        {
            var instituicao = await _context.Instituicaos.FindAsync(idInstituicao);

            if (instituicao == null)
            {
                throw new Exception("Instituição não encontrada.");
            }

            var curso = await _context.Cursos.FindAsync(idCurso);

            if (curso == null || !instituicao.Cursos.Contains(curso))
            {
                throw new Exception("Curso não encontrado.");
            }

            instituicao.Cursos.Remove(curso);
          
            return instituicao;
        }
    }
}
