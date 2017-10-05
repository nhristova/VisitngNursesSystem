﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VNS.Web.Models.Visits
{
    public class VisitDetailsViewModel
    {
        private readonly int descriptionMaxLen = 200;
        private string description;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public string NurseName { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime LastModifiedOn { get; set; }

        // TODO: add other fields
    }
}