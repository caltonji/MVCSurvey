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
    public class QuestionResponseService
    {
        private readonly MongoHelper<QuestionResponse> _questionResponses;
        private readonly MongoHelper<Question> _questions;

        public QuestionResponseService()
        {
            _questionResponses = new MongoHelper<QuestionResponse>();
            _questions = new MongoHelper<Question>();
        }

        /* create and add new QuestionResponse from a string[] answers */
        public ObjectId makeAndAddQuestionResponse(string[] answers, string key)
        {
            var newQuestionResponse = new QuestionResponse()
            {
                QuestionResponseID = ObjectId.GenerateNewId(),
                Answers = answers,
                CreationDate = DateTime.UtcNow
            };
            addQuestionResponse(newQuestionResponse, key);

            return newQuestionResponse.QuestionResponseID;
        }

        // Create and add new QuestionResponse from bool[] answers for
        // used for multi check boxes
        public ObjectId makeAndAddQuestionResponse(bool[] answers, string key)
        {
            string[] str = new string[answers.Length];
            for (int i = 0; i < answers.Length; i++)
            {
                str[i] = answers[i].ToString();
            }
            return makeAndAddQuestionResponse(str, key);
        }

        // Add Question Response by pushing the Question Response to the appropriate
        // Question based off of the Key
        public void addQuestionResponse(QuestionResponse qResp, string key)
        {
            _questions.Collection.Update(Query.EQ("UniqueKey", key),
                Update.PushWrapped("Responses", qResp).Inc("TotalResponses", 1));
        }
    }
}
