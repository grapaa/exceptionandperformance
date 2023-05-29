using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers;

[ApiController]
[Route("[controller]")]
public class ExceptionController : ControllerBase
{
   

    private readonly ILogger<ExceptionController> _logger;
    private readonly IFoo _foo;

    public ExceptionController(ILogger<ExceptionController> logger,IFoo foo)
    {
        _logger = logger;
        _foo = foo;
    }

    [HttpGet("Original")]
    public IActionResult GetOriginal()
    {
        try
        {
            return Ok(_foo.Original());
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Bad thing happened!");
            return StatusCode(500);
        }
    }
    [HttpGet("Functional")]
    public IActionResult GetFunctional()
    {

        var result = _foo.Functional();

        return result.Match<IActionResult>(
            good => Ok(good), 
            bad =>
        {
            _logger.LogError(bad, "Bad thing happened!");
            return StatusCode(500);
        });

       
    }

}

