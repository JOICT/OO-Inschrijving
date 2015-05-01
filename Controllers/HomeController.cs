using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OO_Inschrijving.Core.Interfaces.Repository;
using OO_Inschrijving.Infrastructure.DAL;
using OO_Inschrijving.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OO_Inschrijving.Models;
using OO_Inschrijving.Core.Models;

namespace OO_Inschrijving.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly ITrainingRepository trainingRepository;


        public HomeController()
        {
            //this.taskService = new SchedulerTaskService();
            //this.meetingService = new SchedulerMeetingService();

            subscriptionRepository = new SubscriptionRepository(new TrainingContext());
            trainingRepository = new TrainingRepository(new TrainingContext());
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(trainingRepository.GetCourses().ToDataSourceResult(request));
        }

       

      
    }
}
