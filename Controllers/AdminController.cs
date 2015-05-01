using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OO_Inschrijving.Core.Interfaces.Repository;
using OO_Inschrijving.Core.Models;
using OO_Inschrijving.Infrastructure.DAL;
using OO_Inschrijving.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OO_Inschrijving.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly ITrainingRepository trainingRepository;
        //
        // GET: /Admin/
   public AdminController()
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

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, Training training)
        {
            if (ModelState.IsValid)
            {
                trainingRepository.DeleteTraining(training.ID);
                trainingRepository.Save();
            }

            return Json(new[] { training }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, Training training)
        {
            if (ModelState.IsValid)
            {
                trainingRepository.InsertTraining(training);
                trainingRepository.Save();
            }

            return Json(new[] { training }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, Training training)
        {
            if (ModelState.IsValid)
            {
                trainingRepository.UpdateTraining(training);
                trainingRepository.Save();
            }

            return Json(new[] { training }.ToDataSourceResult(request, ModelState));
        }
	}
}