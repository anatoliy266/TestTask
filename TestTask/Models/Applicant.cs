using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    /// <summary>
    /// Model explained Candidate entity
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// Candidate fio
        /// </summary>
        /// 
        [Required]
        [Display(Name = "Candidate FIO")]
        public string Name { get; set; }
        /// <summary>
        /// Candidate phone
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Position candidate interviewed for
        /// </summary>
        /// 
        [Required]
        [Display(Name = "Candidate position")]
        public string Position { get; set; }
        /// <summary>
        /// Interviewer
        /// </summary>
        /// 
        [Required]
        [Display(Name = "Interviewer")]
        public string Employee { get; set; }
        /// <summary>
        /// Interviewer position
        /// </summary>
        public string EmployeePosition { get; set; }
        /// <summary>
        /// Interview date
        /// </summary>
        /// 
        [Required]
        [RegularExpression(@"[0-9]{2}.[0-9]{2}.[0-9]{4}\s[0-9]{1,2}:[0-9]{2}:[0-9]{2}", ErrorMessage = "Incorrect date")]
        [Display(Name = "Interview date")]
        public DateTime InterviewDate { get; set; }
        /// <summary>
        /// End of time for complete test task, set by candidate
        /// </summary>
        /// 
        [Required]
        [RegularExpression(@"[0-9]{2}.[0-9]{2}.[0-9]{4}\s[0-9]{1,2}:[0-9]{2}:[0-9]{2}", ErrorMessage = "Incorrect date")]
        [Display(Name = "Test task end date")]
        public DateTime TestTaskEndDate { get; set; }
        /// <summary>
        /// Date, when candidate end test task in fact
        /// </summary>
        /// 
        [RegularExpression(@"[0-9]{2}.[0-9]{2}.[0-9]{4}\s[0-9]{1,2}:[0-9]{2}:[0-9]{2}", ErrorMessage = "Incorrect date")]
        public DateTime TestTaskEndDateFact { get; set; }
        /// <summary>
        /// Employee confirmed candidate's test task ended
        /// </summary>
        public int ConfirmedEmployee { get; set; }
        /// <summary>
        /// Identificator for db record
        /// </summary>
        public int Id { get; set; }
    }
}