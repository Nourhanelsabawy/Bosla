using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Python.Runtime;

namespace BoslaAPI.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult TestPy()
        {
            Runtime.PythonDLL = "C:\\Users\\BnAdel\\AppData\\Local\\Programs\\Python\\Python312\\python312.dll";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                return Ok($"Python version: {sys.version}");

                //var pyScript = Py.Import("simplescript");
                //var res = pyScript.InvokeMethod("say_hello");
                //PythonEngine.Shutdown();
                //return Ok(res);
            }
        }
    }
}
