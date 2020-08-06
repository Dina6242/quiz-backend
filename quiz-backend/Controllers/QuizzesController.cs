using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuizzesController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<quiz>>> Getquiz()
        {
            return await _context.quiz.ToListAsync();
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<quiz>> Getquiz(int id)
        {
            var quiz = await _context.quiz.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // PUT: api/Quizzes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putquiz(int id, quiz quiz)
        {
            if (id != quiz.ID)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!quizExists(id))
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

        // POST: api/Quizzes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<quiz>> Postquiz(quiz quiz)
        {
            _context.quiz.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getquiz", new { id = quiz.ID }, quiz);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<quiz>> Deletequiz(int id)
        {
            var quiz = await _context.quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.quiz.Remove(quiz);
            await _context.SaveChangesAsync();

            return quiz;
        }

        private bool quizExists(int id)
        {
            return _context.quiz.Any(e => e.ID == id);
        }
    }
}
