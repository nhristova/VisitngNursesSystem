using System;
using System.ComponentModel.DataAnnotations;
using VNS.Data.Models;

namespace VNS.Web.Models.Visits
{
    public class VisitCardViewModel
    {
        private readonly int descriptionMaxLen = 200;
        private string description;

        public VisitCardViewModel()
        {

        }

        public VisitCardViewModel(Visit visit)
        {
            this.Id = visit.Id;
            this.Date = visit.Date;
            this.NurseName = visit.UserName;
            this.Description = visit.Description;
        }

        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}")]
        public DateTime Date { get; set; }

        public string NurseName { get; set; }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value.Length > this.descriptionMaxLen
                    ? value.Substring(0, this.descriptionMaxLen) + "..."
                    : value;
            }
        }
    }
}