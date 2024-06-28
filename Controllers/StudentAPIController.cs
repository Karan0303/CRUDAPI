using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SqltrainingContext context;

        public StudentAPIController(SqltrainingContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<KStudent>>> GetStudents()
        {
            var data = await context.KStudents.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<KStudent>> GetStudentById(int id)
        {
            var student = await context.KStudents.FindAsync(id);
            if (student==null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<KStudent>> CreateStudent(KStudent std)
        {
            await context.KStudents.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<KStudent>> UpdateStudent(int id,KStudent std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<KStudent>> DeleteStudent(int id)
        {
            var std = await context.KStudents.FindAsync(id);
            if(std == null)
            {
                return NotFound();

            }
            context.KStudents.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }
    }
}

// this is test message for git
