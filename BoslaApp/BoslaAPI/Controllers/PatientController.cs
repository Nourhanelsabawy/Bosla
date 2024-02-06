using BoslaAPI.Data;
using BoslaAPI.Models;
using BoslaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BoslaAPI.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly BoslaDbContext _context;

        public PatientController(BoslaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Patients()
        {
            var patients = _context.Patients;
            return Ok(patients);
        }

        // Retrieve A User By Id
        //[Route("Patient")]
        [HttpGet("{id:int}", Name = "Patient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Patient(int id)
        {
            if (id <= 0)
                return BadRequest();

            var patient = _context.Patients.FirstOrDefault(x => x.Id == id);
            if(patient == null) 
                return NotFound();

            var patientDTO = new PatientDTO
            {
                PatientId = patient.Id,
                Name = patient.Name,
                Gender = patient.Gender,
                Age = patient.Age,
                Address = patient.Address,
                Phone = patient.Phone,
                ProfileImageName = patient.ProfileImage,
                DrName = _context.Doctors.First(x => x.Id == patient.DrId).Name,
                DrPhone = _context.Doctors.First(x => x.Id == patient.DrId).Phone,
                RelativeName = patient.RelativeName,
                RelativePhone = patient.RelativePhone,
                BloodType = patient.BloodType,
                Disease = patient.Disease,
                AllergicFoods = patient.AllergicFoods
            };

            return Ok(patientDTO);
        }

        // Create A New User
        //[Route("CreatePatient")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePatient([FromForm]PatientDTO patient)
        {
            if(patient == null) return BadRequest();

            // Custom Validation
            var ph = _context.Patients.FirstOrDefault(x => x.Phone == patient.Phone);
            if(ph != null)
            {
                ModelState.AddModelError("Phone", "This Phone already exists, try another one!");
                return BadRequest(ModelState);
            }
            var dr = _context.Doctors.FirstOrDefault(x => x.Phone == patient.DrPhone);
            if(dr == null)
            {
                ModelState.AddModelError("DrPhone", "Doctor Phone is not correct, try again!");
                return BadRequest(ModelState);
            }

            Patient pToInsert = new Patient()
            {
                Name = patient.Name,
                Gender = patient.Gender,
                Age = patient.Age,
                Address = patient.Address,
                Phone = patient.Phone,
                DrId = dr.Id,
                RelativeName = patient.RelativeName,
                RelativePhone = patient.RelativePhone,
                BloodType = patient.BloodType,
                Disease = patient.Disease,
                AllergicFoods = patient.AllergicFoods
            };
            // Upload Profile Image if found
            if (patient.ProfileImage != null)
            {
                string imgName = patient.ProfileImage.FileName;
                imgName = $"{Guid.NewGuid().ToString().Substring(0, 6)}-{Path.GetFileName(imgName)}";
                string imgMove = Path.Combine(Directory.GetCurrentDirectory(), $"Assets\\Patient", imgName);
                var stream = new FileStream(imgMove, FileMode.Create);
                patient.ProfileImage.CopyToAsync(stream);

                pToInsert.ProfileImage = imgName;
            }

            // Insert New Patient Into Database
            _context.Patients.Add(pToInsert);
            _context.SaveChanges();

            // Response Will Be 201 Created
            return CreatedAtRoute("Patient", new {id =  pToInsert.Id}, patient);
        }

        // Edit A User Using Http PUT
        //[Route("UpdatePatient")]
        [HttpPut("{id:int}", Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatient(int id, [FromForm]PatientDTO patient)
        {
            if (id <= 0 || patient == null) return BadRequest();

            var pat = _context.Patients.FirstOrDefault(x => x.Id == id);
            if(pat == null) return BadRequest();

            var drPhone = _context.Doctors.FirstOrDefault(x => x.Id == pat.DrId)!.Phone;
            var drId = pat.DrId;
            if(patient.DrPhone != drPhone)
            {
                var dr = _context.Doctors.FirstOrDefault(x => x.Phone == patient.DrPhone);
                if (dr == null)
                {
                    ModelState.AddModelError("DrPhone", "Doctor Phone is not correct, try again!");
                    return BadRequest(ModelState);
                }
                drId = dr.Id; // Update The Doctor Data
            }
            // Update All Data
            pat.Name = patient.Name;
            pat.Gender = patient.Gender;
            pat.Age = patient.Age;
            pat.Address = patient.Address;
            pat.Phone = patient.Phone;
            pat.DrId = drId;
            pat.RelativeName = patient.RelativeName;
            pat.RelativePhone = patient.RelativePhone;
            pat.BloodType = patient.BloodType;
            pat.Disease = patient.Disease;
            pat.AllergicFoods = patient.AllergicFoods;

            // Upload Profile Image if found
            if (patient.ProfileImage != null)
            {
                // Remove The Old Image
                string imgPath = $"Assets\\Patient\\{pat.ProfileImage}";
                Thread.Sleep(2000);
                System.IO.File.Delete(imgPath);
                // Add New Image
                string imgName = patient.ProfileImage.FileName;
                imgName = $"{Guid.NewGuid().ToString().Substring(0, 6)}-{Path.GetFileName(imgName)}";
                string imgMove = Path.Combine(Directory.GetCurrentDirectory(), $"Assets\\Patient", imgName);
                var stream = new FileStream(imgMove, FileMode.Create);
                patient.ProfileImage.CopyToAsync(stream);

                pat.ProfileImage = imgName;
            }

            // Update Data in the DB
            _context.Patients.Update(pat);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
