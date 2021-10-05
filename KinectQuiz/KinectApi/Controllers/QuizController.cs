using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KinectApi.Models;
using KinectApi.Services;

namespace KinectApi.Controllers
{
    public class QuizController : ApiController
    {
        // GET: api/Quiz
        public async Task<IEnumerable<Quiz>> GetQuizzes()
        {
            return await new SharePointService().GetQuizzes(SharePointSecurity.GetAccessToken());
        }

        // GET: api/Quiz/{id}
        [ResponseType(typeof(Quiz))]
        public async Task<IHttpActionResult> GetQuiz(int id)
        {
            Quiz quiz = await db.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT: api/Quiz/{id}
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuiz(int id, Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.Id)
            {
                return BadRequest();
            }

            db.Entry(quiz).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Quiz
        [ResponseType(typeof(Quiz))]
        public async Task<IHttpActionResult> PostQuiz(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quizzes.Add(quiz);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quiz.Id }, quiz);
        }

        // DELETE: api/Quiz/{id}
        [ResponseType(typeof(Quiz))]
        public async Task<IHttpActionResult> DeleteQuiz(int id)
        {
            Quiz quiz = await db.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            db.Quizzes.Remove(quiz);
            await db.SaveChangesAsync();

            return Ok(quiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizExists(int id)
        {
            return db.Quizzes.Count(e => e.Id == id) > 0;
        }

        private KinectApiContext db = new KinectApiContext();
    }
}