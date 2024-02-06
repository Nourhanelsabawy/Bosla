using BoslaAPI.Data;
using BoslaAPI.Models;
using BoslaAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoslaAPI.Controllers
{
    [Route("api/MedicalHistories")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly BoslaDbContext _context;

        public MedicalHistoryController(BoslaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult MedicalHistories()
        {
            var mhs = _context.MedicalHistories;
            return Ok(mhs);
        }

        // Retrieve A Medical History By Patient Id
        //[Route("MedicalHistoryId")]
        [HttpGet("{patientId:int}", Name = "MedicalHistoryId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MedicalHistoryId(int patientId)
        {
            if (patientId <= 0)
                return BadRequest();

            var pat = _context.Patients.FirstOrDefault(x => x.Id == patientId);
            if (pat == null)
                return NotFound();

            var mhs = _context.MedicalHistories.Where(x => x.PatId == patientId).ToList();
            if (mhs.Count <= 0)
                return NotFound();

            List<MedicalHistoryDTO> hists = new List<MedicalHistoryDTO>();
            foreach (var m in mhs)
            {
                hists.Add(new MedicalHistoryDTO
                {
                    PatientName = pat.Name,
                    PatientAge = pat.Age,
                    PatientDisease = pat.Disease,
                    PatientPhone = pat.Phone,
                    DoctorPhone = _context.Doctors.FirstOrDefault(x => x.Id == pat.DrId)!.Phone,
                    Diagnose = m.Diagnose,
                    Prescription = m.Prescription
                });
            }

            return Ok(hists); // List of Patient Medical History
        }

        // Retrieve A Medical History By Patient Phone
        //[Route("MedicalHistoryPhone")]
        [HttpGet("{patientPh}", Name = "MedicalHistoryPhone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MedicalHistoryPhone(string patientPh)
        {
            var pat = _context.Patients.FirstOrDefault(x => x.Phone == patientPh);
            if (pat == null)
                return NotFound();

            var mhs = _context.MedicalHistories.Where(x => x.PatId == pat.Id).ToList();
            if (mhs.Count <= 0)
                return NotFound();

            List<MedicalHistoryDTO> hists = new List<MedicalHistoryDTO>();
            foreach (var m in mhs)
            {
                hists.Add(new MedicalHistoryDTO
                {
                    PatientName = pat.Name,
                    PatientAge = pat.Age,
                    PatientDisease = pat.Disease,
                    PatientPhone = pat.Phone,
                    DoctorPhone = _context.Doctors.FirstOrDefault(x => x.Id == pat.DrId)!.Phone,
                    Diagnose = m.Diagnose,
                    Prescription = m.Prescription
                });
            }

            return Ok(hists); // List of Patient Medical History
        }

        // Create A New User
        //[Route("Create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromForm] MedicalHistoryDTO medicalHistory)
        {
            if (medicalHistory == null) return BadRequest();

            // Check the phone of the user
            var ph = _context.Patients.FirstOrDefault(x => x.Phone ==  medicalHistory.PatientPhone);
            if(ph == null)
            {
                ModelState.AddModelError("PatientPhone", "Patient Phone is not correct, try again");
                return BadRequest(ModelState);
            }

            MedicalHistory mh = new MedicalHistory
            {
                PatId = ph.Id,
                Diagnose = medicalHistory.Diagnose,
                Prescription = medicalHistory.Prescription,
                CreatedAt = DateTime.Now
            };

            // Insert New Patient Into Database
            _context.MedicalHistories.Add(mh);
            _context.SaveChanges();

            // Response Will Be 201 Created
            return Created();
        }
    }
}
