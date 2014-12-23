using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Domain
{
    public class Response
    {
        /* contains a list of the individual QuestionResponses */
        public IList<QuestionResponse> QuestionResponses { get; set; }

        public Respondent Responder { get; set; }

    }
}
