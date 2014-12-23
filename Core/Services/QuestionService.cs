using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;
using Core.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Core.Services
{
    public class QuestionService
    {
        private readonly MongoHelper<Question> _questions;

        public QuestionService()
        {
            _questions = new MongoHelper<Question>();
        }

        public void addQuestion(string prompt, string key)
        {
            var q = new Question()
            {
                QuestionID = ObjectId.GenerateNewId(),
                UniqueKey = key,
                Prompt = prompt,
                TotalResponses = 0,
                Responses = new List<QuestionResponse>()
            };
            _questions.Collection.Save(q);
        }

    }
}
