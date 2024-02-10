using BoslaAPI.Models.AIModels;
using BoslaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Python.Runtime;

namespace BoslaAPI.Controllers
{
    [Route("api/alzheimer")]
    [ApiController]
    public class AlzheimerController : ControllerBase
    {
        private const string ModelPath = "Models/AIModels/Diseases/alzheimer.joblib";

        public AlzheimerController()
        {
            PythonEngine.Initialize();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Prediction([FromForm] AlzheimerInput input)
        {
            using (Py.GIL())
            {
                // Import required Python modules
                dynamic numpy = Py.Import("numpy");
                dynamic joblib = Py.Import("joblib");

                // Load the SVM model using joblib (Python)
                dynamic svmModel = joblib.load(ModelPath);

                // Prepare input data as a NumPy array
                dynamic inputData = numpy.array(new object[] { input.Age.ToString(), input.SES.ToString(), input.MMSE.ToString(), input.CDR.ToString(), input.eTIV.ToString(), input.nWBV.ToString(), input.ASF.ToString(), input.Visit.ToString(), input.MRDelay.ToString() });

                // Make predictions using Python interop
                dynamic prediction = svmModel.predict(inputData.reshape(1, -1));
                
                // The Prediction
                AlzheimerOutput.Result = prediction[0].ToString();
            }

            // Shutting down the python engine
            PythonEngine.Shutdown();

            if (AlzheimerOutput.Result == "0.0")
            {
                var msg = "Your mind shines with resilience, lighting up paths of hope and strength. ✨";
                return Ok(new { Result = msg });
            }
            else
            {
                var msg = "Unfortunately, You suffer from Alzheimer 😢";
                return Ok(new { Result = msg });
            }
        }
    }
}
