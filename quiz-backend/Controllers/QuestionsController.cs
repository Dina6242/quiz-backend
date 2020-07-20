﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly QuizContext context;
        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return new Models.Question[]
            {
                new Models.Question(){Text = "Hello"},
                new Models.Question(){ Text = "Hi" }
            };
        }
        [HttpPost]
        public void Post([FromBody] Models.Question question)
        {
            context.Questions.Add(new Models.Question() { Text = "test" });
            context.SaveChanges();
        }
    }
}
