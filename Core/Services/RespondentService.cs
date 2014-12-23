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
    public class RespondentService
    {
        private readonly MongoHelper<Respondent> _respondents;

        public RespondentService()
        {
            _respondents = new MongoHelper<Respondent>();
        }

        public void AddRespondent(Respondent respondent)
        {
            _respondents.Collection.Save(respondent);
        }
    }
}
