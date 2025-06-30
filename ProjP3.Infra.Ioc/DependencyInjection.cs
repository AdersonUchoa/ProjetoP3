using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjP3.Application.Mappings;
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

            services.AddScoped<AlunoIRepository, AlunoRepository>();
            services.AddScoped<CursoIRepository, CursoRepository>();
            services.AddScoped<DisciplinaIRepository, DisciplinaRepository>();
            services.AddScoped<InstituicaoIRepository, InstituicaoRepository>();
            services.AddScoped<ProfessorIRepository, ProfessorRepository>();
            services.AddScoped<ITipoCursoRepository, TipoCursoRepository>();
            services.AddScoped<ITipoDisciplinaRepository, TipoDisciplinaRepository>();
            services.AddScoped<ITituloRepository, TituloRepository>();

            // A ser adicionado: services.AddScoped dos InterfacesServices e Services.
            // services.AddScoped<AlunoIService, AlunoService>(); etc

            services.AddAutoMapper(typeof(ModelToDTO));

            return services;
        }
    }
}
