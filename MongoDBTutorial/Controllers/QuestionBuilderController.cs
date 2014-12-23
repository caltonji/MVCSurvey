using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Domain;
using Core.Services;

namespace MongoDBTutorial.Controllers
{
    public class QuestionBuilderController : Controller
    {
        //
        // GET: /QuestionBuilder/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Question q)
        {
            //q.TotalResponses = 0;
            //q.Responses = new List<QuestionResponse>();
            QuestionService qServ = new QuestionService();
            qServ.addQuestion(q.Prompt, q.UniqueKey);
            q.Prompt = "";
            q.UniqueKey = "";
            return Index();
        }

    }
}
