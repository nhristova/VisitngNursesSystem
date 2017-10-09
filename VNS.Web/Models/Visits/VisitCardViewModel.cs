using System;
using System.ComponentModel.DataAnnotations;

namespace VNS.Web.Models.Visits
{
    public class VisitCardViewModel
    {
        private readonly int descriptionMaxLen = 200;
        private string description;

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