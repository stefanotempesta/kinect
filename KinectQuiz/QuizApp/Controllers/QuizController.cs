using KinectApi.Models;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            var quizzes = new QuizService().GetQuizzes();

            return View(quizzes);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include="Name")]Quiz item)
        {
            if (ModelState.IsValid)
            {
                await new QuizService().CreateQuiz(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Quiz/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")]Quiz item)
        {
            if (ModelState.IsValid)
            {
                await new QuizService().UpdateQuiz(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Quiz/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include = "Id,Name")]Quiz item)
        {
            try
            {
                await new QuizService().DeleteQuiz(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
