//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolutionE_RH_v1._5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPART
    {
        public decimal ID_DEP { get; set; }
        public string MATRECULE { get; set; }
        public string DATE_DEP { get; set; }
        public string MOTIF_DEP { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}