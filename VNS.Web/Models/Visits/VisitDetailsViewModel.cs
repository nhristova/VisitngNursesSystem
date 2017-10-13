using System;
using System.ComponentModel.DataAnnotations;
using VNS.Data.Models;
using VNS.Data.Models.ValidationRules;
using Rules = VNS.Data.Models.ValidationRules.PropertiesConstraints;

namespace VNS.Web.Models.Visits
{
    public class VisitDetailsViewModel
    {
        //private readonly int descriptionMaxLen = 200;
        //private string description;

        public VisitDetailsViewModel()
        {

        }

        public VisitDetailsViewModel(Visit visit)
        {
            if (visit != null)
            {
                Id = visit.Id;
                Date = visit.Date;
                NurseName = visit.Nurse.UserName;
                Description = visit.Description;
                CreatedOn = visit.CreatedOn; //.Value,
                LastModifiedOn = visit.ModifiedOn;//.Value
            }
        }


        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [PastDate]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name ="Nurse name")]
        public string NurseName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(Rules.DescriptionMaxLength, ErrorMessage = Rules.StringLengthError, MinimumLength = Rules.DescriptionMinLength)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yy HH:mm}")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yy HH:mm}")]
        public DateTime? LastModifiedOn { get; set; }

        // TODO: add other fields
        // TODO: extract validation messages??
    }
}