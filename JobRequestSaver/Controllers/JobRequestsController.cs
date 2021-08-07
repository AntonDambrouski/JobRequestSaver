using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AboutFindingJob.Models;

namespace AboutFindingJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequestsController : ControllerBase
    {
        private readonly JobRequestContext _context;

        public JobRequestsController(JobRequestContext context)
        {
            _context = context;
        }

        // GET: api/JobRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobRequest>>> GetjobRequests()
        {
            return await _context.jobRequests.ToListAsync();
        }

        // GET: api/JobRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobRequest>> GetJobRequest(int id)
        {
            var jobRequest = await _context.jobRequests.FindAsync(id);

            if (jobRequest == null)
            {
                return NotFound();
            }

            return jobRequest;
        }

        // PUT: api/JobRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobRequest(int id, JobRequest jobRequest)
        {
            if (id != jobRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobRequests
        [HttpPost]
        public async Task<ActionResult<JobRequest>> PostJobRequest(JobRequest jobRequest)
        {
            _context.jobRequests.Add(jobRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobRequest", new { id = jobRequest.Id }, jobRequest);
        }

        // DELETE: api/JobRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobRequest(int id)
        {
            var jobRequest = await _context.jobRequests.FindAsync(id);
            if (jobRequest == null)
            {
                return NotFound();
            }

            _context.jobRequests.Remove(jobRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobRequestExists(int id)
        {
            return _context.jobRequests.Any(e => e.Id == id);
        }
    }
}
