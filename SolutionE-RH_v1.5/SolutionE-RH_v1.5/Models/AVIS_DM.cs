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
    
    public partial class AVIS_DM
    {
        public decimal ID_DEMANDE { get; set; }
        public decimal ID_AVIS { get; set; }
        public string AVIS { get; set; }
        public string RAIS_AVIS { get; set; }
        public byte[] DATE_AVIS { get; set; }
    
        public virtual DEMANDE_CONGE DEMANDE_CONGE { get; set; }
    }
}