using BoslaAPI.Data;
using BoslaAPI.Models;
using BoslaAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoslaAPI.Controllers
{
    [Route("api/Children")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly BoslaDbContext _context;

        public ChildController(BoslaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Children()
        {
            var children = _context.Children;
            return Ok(children);
        }

        // Retrieve A User By Id
        //[Route("Child")]
        [HttpGet("{id:int}", Name = "Child")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Child(int id)
        {
            if (id <= 0)
                return BadRequest();

            var child = _context.Children.FirstOrDefault(x => x.Id == id);
            if (child == null)
                return NotFound();

            var childDTO = new ChildDTO
            {
                ChildId = child.Id,
                Name = child.Name,
                Gender = child.Gender,
                Age = child.Age,
                Address = child.Address,
                ProfileImageName = child.ProfileImage,
                RelativeName = child.RelativeName,
                RelativePhone = child.RelativePhone,
            };

            return Ok(childDTO);
        }

        // Create A New User
        //[Route("CreateChild")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateChild([FromForm] ChildDTO child)
        {
            if (child == null) return BadRequest();

            Child cToInsert = new Child()
            {
                Name = child.Name,
                Gender = child.Gender,
                Age = child.Age,
                Address = child.Address,
                RelativeName = child.RelativeName,
                RelativePhone = child.RelativePhone,
            };
            // Upload Profile Image if found
            if (child.ProfileImage != null)
            {
                string imgName = child.ProfileImage.FileName;
                imgName = $"{Guid.NewGuid().ToString().Substring(0, 6)}-{Path.GetFileName(imgName)}";
                string imgMove = Path.Combine(Directory.GetCurrentDirectory(), $"Assets\\Child", imgName);
                var stream = new FileStream(imgMove, FileMode.Create);
                child.ProfileImage.CopyToAsync(stream);

                cToInsert.ProfileImage = imgName;
            }

            // Insert New Patient Into Database
            _context.Children.Add(cToInsert);
            _context.SaveChanges();

            // Response Will Be 201 Created
            return CreatedAtRoute("Child", new { id = cToInsert.Id }, child);
        }

        // Edit A User Using Http PUT
        //[Route("UpdateChild")]
        [HttpPut("{id:int}", Name = "UpdateChild")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateChild(int id, [FromForm]ChildDTO child)
        {
            if (id <= 0 || child == null) return BadRequest();

            var ch = _context.Children.FirstOrDefault(x => x.Id == id);
            if (ch == null) return BadRequest();

            // Update All Data
            ch.Name = child.Name;
            ch.Gender = child.Gender;
            ch.Age = child.Age;
            ch.Address = child.Address;
            ch.RelativeName = child.RelativeName;
            ch.RelativePhone = child.RelativePhone;

            // Upload Profile Image if found
            if (child.ProfileImage != null)
            {
                // Remove The Old Image
                string imgPath = $"Assets\\Child\\{ch.ProfileImage}";
                Thread.Sleep(2000);
                System.IO.File.Delete(imgPath);
                // Add New Image
                string imgName = child.ProfileImage.FileName;
                imgName = $"{Guid.NewGuid().ToString().Substring(0, 6)}-{Path.GetFileName(imgName)}";
                string imgMove = Path.Combine(Directory.GetCurrentDirectory(), $"Assets\\Child", imgName);
                var stream = new FileStream(imgMove, FileMode.Create);
                child.ProfileImage.CopyToAsync(stream);

                ch.ProfileImage = imgName;
            }

            // Update Data in the DB
            _context.Children.Update(ch);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
