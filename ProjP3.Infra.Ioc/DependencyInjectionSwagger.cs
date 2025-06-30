using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Infra.Ioc
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Projeto P3 API",
                    Version = "v1",
                    Description = "API para o projeto da disciplina de Programação 3.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Aderson Uchoa",
                        Email = "aderson.filho027@academico.ifs.edu.br"
                    }
                });

                var xmlFile = $"ProjP3.API.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
