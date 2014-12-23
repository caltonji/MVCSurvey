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
    public class QuestionResponse
    {
        [BsonId]
        public ObjectId QuestionResponseID { get; set; }

        /* size 1 if free response  */
        public string[] Answers { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
