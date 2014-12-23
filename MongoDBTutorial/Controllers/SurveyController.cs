using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;
using Core.Domain;
using Core.Services;
using MongoDBTutorial.Helpers;
using MongoDB.Bson;

namespace MongoDBTutorial.Controllers
{
    public class SurveyController : Controller
    {

        private readonly RespondentService _respondentService;
        private readonly QuestionResponseService _questionResponseService;
        
        // instantiate services for communicating with MongoDB
        public SurveyController()
        {
            _respondentService = new RespondentService();
            _questionResponseService = new QuestionResponseService();
        }

        //
        // GET: /Survey/ThankYou
        public ActionResult ThankYou()
        {
            return View();
        }

        //
        // GET: /Survey/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.RedirectModel model)
        {
            return Redirect(Request.Url.ToString() + '/' + model.redirect) ;
        }

        [HttpGet]
        public ActionResult Survey1()
        {
            Debug.WriteLine("Got to Survey1");
            return View();
        }

        // Handles posting of a Survey1Model to Survey/Survey1
        // Survey1Model is a hardcoded set of data that will be included in the post
        // need to update with PRG Pattern http://sampathloku.blogspot.com/2013/05/how-to-use-prg-pattern-with-aspnet-mvc-4.html
        // Post: /Survey/Survey1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Survey1(MongoDBTutorial.Models.Survey1Model model)
        {
            string[] keys = new string[5] {"favColor", "gatechColors", "", "", "" };
            Debug.WriteLine("Got to Respond Post");
            if (ModelState.IsValid)
            {
                Debug.WriteLine("");
                Debug.WriteLine(model.Name);
                Debug.WriteLine(model.Email);
                Debug.WriteLine("orgtype " + model.OrganizationType);
                Debug.WriteLine("phone number " +  model.PhoneNumber);
                Debug.WriteLine("title "  + model.Title);
                Debug.WriteLine("comp " + model.Company);
               
                //Build respondent from the personal info
                var newRespondent = new Respondent()
                {
                    RespondentID = ObjectId.GenerateNewId(),
                    Name = model.Name,
                    Email = model.Email,
                    OrganizationType = model.OrganizationType,
                    PhoneNumber = model.PhoneNumber,
                    Title = model.Title,
                    Company = model.Company,
                    CreationTime = DateTime.UtcNow

                };
                //add Respondent to database 
                _respondentService.AddRespondent(newRespondent);
                //add QuestionResponses to appropriate Questions (first 2)
                _questionResponseService.makeAndAddQuestionResponse(model.Question1, keys[0]);
                _questionResponseService.makeAndAddQuestionResponse(model.Question2, keys[1]);

                //build url with recommendation info
                ViewBag.url = Request.Url.GetLeftPart(UriPartial.Authority) + "/Survey1?r=" + newRespondent.RespondentID;

                return RedirectToAction("ThankYou");
            }
            else
            {
                Debug.WriteLine("An error occurred");
            }
            // If we got this far, something failed, redisplay form
            return Survey1();
        }

    }
}
