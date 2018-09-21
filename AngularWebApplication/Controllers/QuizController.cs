using AngularWebApplication.Data;
using AngularWebApplication.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using AngularWebApplication.Data.Models;

namespace AngularWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quiz = _dbContext.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null) return NotFound(new {Error = string.Format($"Quiz ID {id} has not been found")});
            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings{Formatting = Formatting.Indented});
        }

        [HttpPut]
        public IActionResult Put([FromBody]QuizViewModel model)
        {
            if (model == null) return new StatusCodeResult(500);
            var quiz = _dbContext.Quizzes.First(q => q.Id == model.Id);
            if (quiz == null) return NotFound(new { Error = string.Format($"Quiz ID {model.Id} has not been found") });

            quiz.Title = model.Title;
            quiz.Description = model.Description;
            quiz.Text = model.Text;
            quiz.Notes = model.Notes;
            quiz.LastModifiedDate = DateTime.Now;

            _dbContext.SaveChanges();

            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [HttpPost]
        public IActionResult Post([FromBody]QuizViewModel model)
        {       
            if (model == null) return new StatusCodeResult(500);

            var quiz = new Quiz
            {
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Notes = model.Notes,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                UserId = _dbContext.Users.First(u => u.UserName == "Admin").Id
            };
            _dbContext.Quizzes.Add(quiz);
            _dbContext.SaveChanges();

            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

     
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quiz = _dbContext.Quizzes.First(q => q.Id == id);
            if (quiz == null) return NotFound(new { Error = string.Format($"Quiz ID {id} has not been found") });

            _dbContext.Remove(quiz);
            _dbContext.SaveChanges();
            return new OkResult();
        }
      
        [HttpGet("Latest/{num:int?}")]
        public IActionResult Latest(int num = 10)
        {
            var x = _dbContext.Quizzes.OrderByDescending(q => q.CreatedDate).ToList();
            var latest = _dbContext.Quizzes.OrderByDescending(q => q.CreatedDate).Take(num).ToList();
            return new JsonResult(latest.Adapt<QuizViewModel[]>(), new JsonSerializerSettings{Formatting = Formatting.Indented});
        }

  
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var byTitle = _dbContext.Quizzes.OrderBy(q => q.Title).Take(num).ToList();
            return new JsonResult(byTitle.Adapt<QuizViewModel[]>(), new JsonSerializerSettings{Formatting = Formatting.Indented});
        }


        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var random = _dbContext.Quizzes.OrderBy(q => Guid.NewGuid()).Take(num).ToList();
            return new JsonResult(random.Adapt<QuizViewModel[]>(), new JsonSerializerSettings{Formatting = Formatting.Indented});
        }
    }
}
