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
    
    public partial class BULLETIN_DE_PAIE
    {
        public string REF_BULL { get; set; }
        public string MATRECULE { get; set; }
        public double SALAIRE_BASE { get; set; }
        public double SALARE_BRUT { get; set; }
        public double NET_APAYER { get; set; }
        public string DATE_ENTRE { get; set; }
        public string STATUS { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
