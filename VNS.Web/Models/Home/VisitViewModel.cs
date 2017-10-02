using System;
using System.ComponentModel.DataAnnotations;

namespace VNS.Web.Models.Home
{
    public class VisitViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Date { get; set; }

        public string NurseName { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy HH:mm}")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy HH:mm}")]
        public DateTime LastModifiedOn { get; set; }
    }
}