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
    
    public partial class ABSENCE
    {
        public int ID_ABS { get; set; }
        public string MATRECULE { get; set; }
        public string DATE { get; set; }
        public int NB_JOUR { get; set; }
        public string JUSTIFIER { get; set; }
        public string RAIS_ABS { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}