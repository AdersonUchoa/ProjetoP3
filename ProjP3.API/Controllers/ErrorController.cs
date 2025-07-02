using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("/error")]
    public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature == null)
        {
            return Problem();
        }

        _logger.LogError(exceptionHandlerFeature.Error, "Ocorreu uma exceção não tratada.");

        if (!hostEnvironment.IsDevelopment())
        {
            return Problem(
                title: "Ocorreu um erro interno no servidor.",
                statusCode: StatusCodes.Status500InternalServerError
            );
        }

        return Problem(
            title: "Ocorreu um erro inesperado. (Ambiente de Desenvolvimento)",
            detail: exceptionHandlerFeature.Error.StackTrace,
            instance: exceptionHandlerFeature.Path,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}