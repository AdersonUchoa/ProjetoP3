using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjP3.Domain.Models;

namespace ProjP3.Infra.Data.Context;

public partial class P3DbContext : DbContext
{
    public P3DbContext()
    {
    }

    public P3DbContext(DbContextOptions<P3DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Cursa> Cursas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Disciplina> Disciplinas { get; set; }

    public virtual DbSet<Instituicao> Instituicaos { get; set; }

    public virtual DbSet<Leciona> Lecionas { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<TipoCurso> TipoCursos { get; set; }

    public virtual DbSet<TipoDisciplina> TipoDisciplinas { get; set; }

    public virtual DbSet<Titulo> Titulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=projeto_p3", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.IdAluno).HasName("PRIMARY");

            entity.ToTable("aluno");

            entity.HasIndex(e => e.IdAluno, "id_aluno").IsUnique();

            entity.Property(e => e.IdAluno).HasColumnName("id_aluno");
            entity.Property(e => e.DtNascimento).HasColumnName("dt_nascimento");
            entity.Property(e => e.TxNome)
                .HasMaxLength(100)
                .HasColumnName("tx_nome");
            entity.Property(e => e.TxSexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("tx_sexo");
        });

        modelBuilder.Entity<Cursa>(entity =>
        {
            entity.HasKey(e => new { e.IdAluno, e.IdDisciplina, e.InAno, e.InSemestre })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("cursa");

            entity.HasIndex(e => e.IdDisciplina, "id_disciplina");

            entity.Property(e => e.IdAluno).HasColumnName("id_aluno");
            entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");
            entity.Property(e => e.InAno).HasColumnName("in_ano");
            entity.Property(e => e.InSemestre).HasColumnName("in_semestre");
            entity.Property(e => e.BlAprovado).HasColumnName("bl_aprovado");
            entity.Property(e => e.InFaltas).HasColumnName("in_faltas");
            entity.Property(e => e.NmNota1)
                .HasPrecision(4, 2)
                .HasColumnName("nm_nota1");
            entity.Property(e => e.NmNota2)
                .HasPrecision(4, 2)
                .HasColumnName("nm_nota2");
            entity.Property(e => e.NmNota3)
                .HasPrecision(4, 2)
                .HasColumnName("nm_nota3");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Cursas)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("cursa_ibfk_1");

            entity.HasOne(d => d.IdDisciplinaNavigation).WithMany(p => p.Cursas)
                .HasForeignKey(d => d.IdDisciplina)
                .HasConstraintName("cursa_ibfk_2");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PRIMARY");

            entity.ToTable("curso");

            entity.HasIndex(e => e.IdCurso, "id_curso").IsUnique();

            entity.HasIndex(e => e.IdTipoCurso, "id_tipo_curso");

            entity.HasIndex(e => new { e.IdInstituicao, e.IdTipoCurso, e.TxDescricao }, "uq_curso_instituicao_tipo_descricao").IsUnique();

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdInstituicao).HasColumnName("id_instituicao");
            entity.Property(e => e.IdTipoCurso).HasColumnName("id_tipo_curso");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");

            entity.HasOne(d => d.IdInstituicaoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdInstituicao)
                .HasConstraintName("curso_ibfk_1");

            entity.HasOne(d => d.IdTipoCursoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdTipoCurso)
                .HasConstraintName("curso_ibfk_2");
        });

        modelBuilder.Entity<Disciplina>(entity =>
        {
            entity.HasKey(e => e.IdDisciplina).HasName("PRIMARY");

            entity.ToTable("disciplina");

            entity.HasIndex(e => e.IdCurso, "id_curso");

            entity.HasIndex(e => e.IdDisciplina, "id_disciplina").IsUnique();

            entity.HasIndex(e => e.IdTipoDisciplina, "id_tipo_disciplina");

            entity.HasIndex(e => e.TxDescricao, "uq_disciplina_descricao").IsUnique();

            entity.HasIndex(e => e.TxSigla, "uq_disciplina_sigla").IsUnique();

            entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdTipoDisciplina).HasColumnName("id_tipo_disciplina");
            entity.Property(e => e.InCargaHoraria).HasColumnName("in_carga_horaria");
            entity.Property(e => e.InPeriodo).HasColumnName("in_periodo");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");
            entity.Property(e => e.TxSigla)
                .HasMaxLength(10)
                .HasColumnName("tx_sigla");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("disciplina_ibfk_2");

            entity.HasOne(d => d.IdTipoDisciplinaNavigation).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.IdTipoDisciplina)
                .HasConstraintName("disciplina_ibfk_1");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.HasKey(e => e.IdInstituicao).HasName("PRIMARY");

            entity.ToTable("instituicao");

            entity.HasIndex(e => e.IdInstituicao, "id_instituicao").IsUnique();

            entity.HasIndex(e => e.TxDescricao, "uq_instituicao_descricao").IsUnique();

            entity.HasIndex(e => e.TxSigla, "uq_instituicao_sigla").IsUnique();

            entity.Property(e => e.IdInstituicao).HasColumnName("id_instituicao");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");
            entity.Property(e => e.TxSigla)
                .HasMaxLength(15)
                .HasColumnName("tx_sigla");
        });

        modelBuilder.Entity<Leciona>(entity =>
        {
            entity.HasKey(e => new { e.IdProfessor, e.IdDisciplina, e.InPeriodo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("leciona");

            entity.HasIndex(e => e.IdDisciplina, "id_disciplina");

            entity.Property(e => e.IdProfessor).HasColumnName("id_professor");
            entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");
            entity.Property(e => e.InPeriodo).HasColumnName("in_periodo");

            entity.HasOne(d => d.IdDisciplinaNavigation).WithMany(p => p.Lecionas)
                .HasForeignKey(d => d.IdDisciplina)
                .HasConstraintName("leciona_ibfk_2");

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.Lecionas)
                .HasForeignKey(d => d.IdProfessor)
                .HasConstraintName("leciona_ibfk_1");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.IdProfessor).HasName("PRIMARY");

            entity.ToTable("professor");

            entity.HasIndex(e => e.IdProfessor, "id_professor").IsUnique();

            entity.HasIndex(e => e.IdTitulo, "id_titulo");

            entity.Property(e => e.IdProfessor).HasColumnName("id_professor");
            entity.Property(e => e.DtNascimento).HasColumnName("dt_nascimento");
            entity.Property(e => e.IdTitulo).HasColumnName("id_titulo");
            entity.Property(e => e.TxEstadoCivil)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .IsFixedLength()
                .HasColumnName("tx_estado_civil");
            entity.Property(e => e.TxNome)
                .HasMaxLength(50)
                .HasColumnName("tx_nome");
            entity.Property(e => e.TxSexo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'M'")
                .IsFixedLength()
                .HasColumnName("tx_sexo");
            entity.Property(e => e.TxTelefone)
                .HasMaxLength(13)
                .HasColumnName("tx_telefone");

            entity.HasOne(d => d.IdTituloNavigation).WithMany(p => p.Professors)
                .HasForeignKey(d => d.IdTitulo)
                .HasConstraintName("professor_ibfk_1");
        });

        modelBuilder.Entity<TipoCurso>(entity =>
        {
            entity.HasKey(e => e.IdTipoCurso).HasName("PRIMARY");

            entity.ToTable("tipo_curso");

            entity.HasIndex(e => e.IdTipoCurso, "id_tipo_curso").IsUnique();

            entity.HasIndex(e => e.TxDescricao, "uq_tipo_curso_descricao").IsUnique();

            entity.Property(e => e.IdTipoCurso).HasColumnName("id_tipo_curso");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");
        });

        modelBuilder.Entity<TipoDisciplina>(entity =>
        {
            entity.HasKey(e => e.IdTipoDisciplina).HasName("PRIMARY");

            entity.ToTable("tipo_disciplina");

            entity.HasIndex(e => e.IdTipoDisciplina, "id_tipo_disciplina").IsUnique();

            entity.HasIndex(e => e.TxDescricao, "uq_tipo_disciplina_descricao").IsUnique();

            entity.Property(e => e.IdTipoDisciplina).HasColumnName("id_tipo_disciplina");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");
        });

        modelBuilder.Entity<Titulo>(entity =>
        {
            entity.HasKey(e => e.IdTitulo).HasName("PRIMARY");

            entity.ToTable("titulo");

            entity.HasIndex(e => e.IdTitulo, "id_titulo").IsUnique();

            entity.HasIndex(e => e.TxDescricao, "uq_titulo_descricao").IsUnique();

            entity.Property(e => e.IdTitulo).HasColumnName("id_titulo");
            entity.Property(e => e.TxDescricao)
                .HasMaxLength(150)
                .HasColumnName("tx_descricao");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
