//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpCareers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Hours { get; set; }
        public decimal Salary { get; set; }
        public string DateCreated { get; set; }
        public string TimeCreated { get; set; }
        public string DateClosed { get; set; }
        public string TimeClosed { get; set; }
        public int AuthorID { get; set; }
    }
}