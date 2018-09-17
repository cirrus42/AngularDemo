using AngularWebApplication.Data;
using AngularWebApplication.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AngularWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private ApplicationDbContext _dbContext;

        public QuizController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quiz = _dbContext.Quizzes.FirstOrDefault(q => q.Id == id);
            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings{Formatting = Formatting.Indented});
        }

        [HttpPut]
        public IActionResult Put(QuizViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post(QuizViewModel model)
        {
            throw new NotImplementedException();
        }

     
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
      
        [HttpGet("Latest/{num:int?}")]
        public IActionResult Latest(int num = 10)
        {
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
