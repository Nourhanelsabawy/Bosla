using Python.Runtime;

namespace BoslaAPI.Services
{
    // This is The Singleton Design Pattern which we create only one instance from this class during RunTime
    public class PyService
    {
        private static PyService _instance;
        
        private PyService()
        {
            //Runtime.PythonDLL = "C:\\Users\\BnAdel\\AppData\\Local\\Programs\\Python\\Python312\\python312.dll";
            Runtime.PythonDLL = "C:\\Users\\BnAdel\\AppData\\Local\\Programs\\Python\\Python38\\python38.dll";
            PythonEngine.Initialize();
        }

        public static void GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PyService();
            }
        }
    }
}
