using BoslaAPI.Models.AIModels;
using BoslaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Python.Runtime;

namespace BoslaAPI.Controllers
{
    [Route("api/autism")]
    [ApiController]
    public class AutismController : ControllerBase
    {
        private const string ModelPath = "Models/AIModels/Diseases/autism.joblib";

        public AutismController()
        {
            PythonEngine.Initialize();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Prediction([FromForm] AutismInput input)
        {
            using (Py.GIL())
            {
                // Import required Python modules
                dynamic numpy = Py.Import("numpy");
                dynamic joblib = Py.Import("joblib");

                // Load the SVM model using joblib (Python)
                dynamic svmModel = joblib.load(ModelPath);

                // Prepare input data as a NumPy array
                dynamic inputData = numpy.array(new object[] { input.age, input.jaundice, input.austim, input.result });

                // Make predictions using Python interop
                dynamic prediction = svmModel.predict(inputData.reshape(1, -1));

                // The Prediction
                AutismOutput.Result = prediction[0].ToString();
            }

            // Shutting down the python engine
            PythonEngine.Shutdown();

            if (AutismOutput.Result == "0")
                return Ok("Your uniqueness is a kaleidoscope of strengths, painting a canvas of extraordinary potential. 💪");
            else
                return Ok("Unfortunately, You are autistic 😢");
        }
    }
}
