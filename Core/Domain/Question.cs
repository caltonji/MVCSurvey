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
    public class Question
    {
        [BsonId]
        public ObjectId QuestionID { get; set; }

        [Required(ErrorMessage="You need a unique key for this question")]
        [StringLength(100)]
        public string UniqueKey { get; set; }
        
        [Required]
        public string Prompt { get; set; }

        /* -1 for free response */
        public int NumOptions { get; set; }

        /* NULL if free response */
        //public string[] PossibleResponses { get; set; }

        /* all responses are saved to the associated question */
        [ScaffoldColumn(false)]
        public int TotalResponses { get; set; }

        [ScaffoldColumn(false)]
        public IList<QuestionResponse> Responses { get; set; }
    }
}
