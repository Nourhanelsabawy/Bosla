using BoslaAPI.Models.AIModels;
using BoslaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Python.Runtime;

namespace BoslaAPI.Controllers
{
    [Route("api/heart")]
    [ApiController]
    public class HeartController : ControllerBase
    {
        private const string ModelPath = "Models/AIModels/Diseases/heart.joblib";

        public HeartController()
        {
            PythonEngine.Initialize();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Prediction([FromForm] HeartInput input)
        {
            using (Py.GIL())
            {
                // Import required Python modules
                dynamic numpy = Py.Import("numpy");
                dynamic joblib = Py.Import("joblib");

                // Load the SVM model using joblib (Python)
                dynamic svmModel = joblib.load(ModelPath);

                // Prepare input data as a NumPy array
                dynamic inputData = numpy.array(new object[] { input.age, input.sex, input.cp, input.trestbps, input.chol, input.fbs, input.restecg, input.thalach, input.exang, input.oldpeak.ToString(), input.slope, input.ca, input.thal });

                // Make predictions using Python interop
                dynamic prediction = svmModel.predict(inputData.reshape(1, -1));
                
                // The Prediction
                HeartOutput.Result = prediction[0].ToString();
            }

            // Shutting down the python engine
            PythonEngine.Shutdown();

            if (HeartOutput.Result == "0")
                return Ok("Fantastic news! Your heart's health deserves a standing ovation! 🌟");
            else
                return Ok("Unfortunately, You have a heart disease 😢");
        }
    }
}
