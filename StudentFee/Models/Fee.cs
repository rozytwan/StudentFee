//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentFee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Fee
    {
        public int Id { get; set; }
        [Display(Name="1st Installment")]
        public double First_Installment { get; set; }
        [Display(Name = "2st Installment")]
        public double Second_Installment { get; set; }
        [Display(Name = "Total")]
        public double Total_Payment { get; set; }
        public int Subject_Id { get; set; }
    
        public virtual Subject Subject { get; set; }
    }
}
