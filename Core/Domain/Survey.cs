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
    public class Survey
    {
        /* Contains a list of Questions, list can be any size */
        [BsonId]
        public ObjectId SurveyID { get; set; }

        public IList<Question> Questions { get; set; }

    }
}
