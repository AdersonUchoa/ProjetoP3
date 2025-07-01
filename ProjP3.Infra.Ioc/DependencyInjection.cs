using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjP3.Application.InterfaceServices;
using ProjP3.Application.Mappings;
using ProjP3.Application.Services;
using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Infra.Data.Context;
using ProjP3.Infra.Data.Repositories;
using System.Text;

namespace ProjP3.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureSwagger();

            services.AddDbContext<P3DbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITipoCursoRepository, TipoCursoRepository>();
            services.AddScoped<ITipoDisciplinaRepository, TipoDisciplinaRepository>();
            services.AddScoped<ITituloRepository, TituloRepository>();

            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITipoCursoService, TipoCursoService>();
            services.AddScoped<ITipoDisciplinaService, TipoDisciplinaService>();
            services.AddScoped<ITituloService, TituloService>();

            services.AddAutoMapper(typeof(ModelToDTO));

            return services;
        }
    }
}
