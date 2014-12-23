using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Core.Domain;

namespace MongoDBTutorial.Models
{
    public class Survey1Model
    {

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address is a required field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Organization")]
        [Required(ErrorMessage = "Organization is a required field")]
        public OrgType OrganizationType { get; set; }
        /* Sponsor, CRO, Research Site, Other */

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(100)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Question 1")]
        public string[] Question1 { get; set; }

        [Display(Name = "Question 2")]
        public string[] Question2 { get; set; }

        [Display(Name = "Question 3")]
        public bool[] Question3 { get; set; }

        [Display(Name = "Question 4")]
        public string[] Question4 { get; set; }

        [Display(Name = "Question 5")]
        public string[] Question5 { get; set; }
    }
}