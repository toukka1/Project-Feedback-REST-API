#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFeedbackAPI.Model;

namespace ProjectFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly MyProjectDatabase _context;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(MyProjectDatabase context, ILogger<ProjectsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {   
            var projects = await _context.Projects.ToListAsync();
            _logger.LogInformation("Made a GET request to the REST API to fetch all projects.");
            return projects;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                _logger.LogError("Project not found with GET request to the REST API. [project id={}]", id);
                return NotFound();
            }
            _logger.LogInformation("Made a GET request to fetch a project. [project id={}]", id);
            return project;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                _logger.LogError("Id does not match the project id. [id={}, project id={}]", id, project.Id);
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Project data invalid.");
                return BadRequest(ModelState);
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    _logger.LogError("Project does not exist. [id={}]", id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Updated a project with a PUT request. [project id={}]", project.Id);
            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Project data invalid.");
                return BadRequest(ModelState);
            }

            _context.Projects.Add(project);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.Id))
                {
                    _logger.LogError("Attempted to add a project, but a project with this id already exists. [id={}]", project.Id);
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Added a new project to the database with a POST request. [id={}]", project.Id);
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                _logger.LogError("Project not found. [id={}]", id);
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Deleted a project with a DELETE request. [id={}]", id);
            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
