using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.ProjectClient.Api.Data;
using TodoList.ProjectClient.Api.Models;

namespace TodoList.ProjectClient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProjectsController : ControllerBase
    {
        private readonly TodoListProjectClientApiContext _context;

        public ClientProjectsController(TodoListProjectClientApiContext context)
        {
            _context = context;
        }
        // GET: api/ClientProjects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetClientProjects(int id)
        {
            var projects = await _context.Project.Where(p => p.Client.Id == id).ToListAsync();

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }
        //POST: api/ClientProjects/{id}
        [HttpPost("{id}")]
        public async Task<ActionResult<Client>> AddProjectToClient(int id, Project project)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            project.Client = client;
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        //PUT: api/ClientProjects/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteProjectFromClient(int id, Project project)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            project.Client = null;
            _context.Entry(project).Property("ClientId").IsModified = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        //PUT: api/ClientProjects/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> EditProjectClient(int id, Client client)
        {
            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            if (!ClientExists(client.Id))
            {
                return NotFound();
            }

            project.Client = client;
            _context.Entry(project).Property("ClientId").IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
