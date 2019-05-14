//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AWPO_WebMobile.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_OfficersVacanciesMaster
    {
        public int OfficersVacancyID { get; set; }
        public string TypOfVacancy { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "No Of Post")]
        public string NoOfPost { get; set; }
        public string Post { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string QR { get; set; }
        [Display(Name = "Date Of Application")]
        public string PostedDate { get; set; }
        [Display(Name = "Last Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> LastDate { get; set; }
        [Display(Name = "Exam/Interview Date")]
        public string Exam_InterviewDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}