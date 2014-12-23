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
    public class Respondent
    {
        [BsonId]
        public ObjectId RespondentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public OrgType OrganizationType { get; set; }
        /* Sponsor, CRO, Research Site, Other */

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public DateTime CreationTime { get; set;  }

        public string RecommendedBy { get; set; }
    }

    public enum OrgType
    {
        Sponsor = 0,
        CRO = 1,
        ResearchSite = 2,
        Other = 3
    }
}
