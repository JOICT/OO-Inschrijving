using Kendo.Mvc.UI;
using OO_Inschrijving.Core.Interfaces.Model;
using OO_Inschrijving.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Inschrijving.Models
{
    public class TrainingViewModel : ITrainingModel, ISchedulerEvent
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }
        public string Trainer { get; set; } //D-nummer

        public string Description { get; set; }
        public DateTime End { get; set; }
        public string EndTimezone { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceRule { get; set; }
        public DateTime Start { get; set; }
        public string StartTimezone { get; set; }
        public string Title { get; set; }

       // public EntryDate EntryDate { get; set; } 

        public virtual IEnumerable<Subscription> Subscriptions { get; set; }
        public virtual IEnumerable<Category> Categories { get; set; }
    }
}