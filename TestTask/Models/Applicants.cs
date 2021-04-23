using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    /// <summary>
    /// Display model for Candidates entities
    /// </summary>
    public class Applicants
    {
        /// <summary>
        /// list of Candidate entities
        /// </summary>
        public List<Applicant> ApplicantsList { get; set; }
    }
}