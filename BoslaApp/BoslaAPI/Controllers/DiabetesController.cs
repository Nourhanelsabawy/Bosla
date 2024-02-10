using BoslaAPI.Models.AIModels;
using BoslaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Python.Runtime;

namespace BoslaAPI.Controllers
{
    [Route("api/diabetes")]
    [ApiController]
    public class DiabetesController : ControllerBase
    {
        private const string ModelPath = "Models/AIModels/Diseases/diabetes.joblib";

        public DiabetesController()
        {
            PythonEngine.Initialize();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Prediction([FromForm] DiabetesInput input)
        {
            // We Use 'using' here to dispose the code in it after ending
            using (Py.GIL())
            {
                // Import required Python modules
                dynamic numpy = Py.Import("numpy");
                dynamic joblib = Py.Import("joblib");

                // Load the SVM model using joblib (Python)
                dynamic svmModel = joblib.load(ModelPath);

                // Prepare input data as a NumPy array
                dynamic inputData = numpy.array(new object[] { input.Pregnancies, input.Glucose, input.BloodPressure, input.SkinThickness, input.Insulin, input.BMI.ToString(), input.DiabetesPedigreeFunction.ToString(), input.Age});

                // Make predictions using Python interop
                dynamic prediction = svmModel.predict(inputData.reshape(1, -1));
                
                // The Prediction
                DiabetesOutput.Result = prediction[0].ToString();
            }

            // Shutting down the python engine
            PythonEngine.Shutdown();

            if (DiabetesOutput.Result == "No")
            {
                var msg = "In the symphony of managing diabetes, your proactive approach harmonizes with health and vitality. 🎵";
                return Ok(new { Result = msg });
            }
            else
            {
                var msg = "Unfortunately, You are diabetic 😢";
                return Ok(new { Result = msg });
            }
        }
    }
}
