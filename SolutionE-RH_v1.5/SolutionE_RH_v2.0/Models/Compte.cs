using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolutionE_RH_v2._0.Models
{
    public class Compte
    {
        [Key]
        public decimal ID_COMPTE { get; set; }
        [Required(ErrorMessage = "Please enter  login.")]
        [Display(Name = "Login")]
        [StringLength(30)]
        public string LOGIN { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(10)]
        public string PASSWORD { get; set; }
        public string CATEG { get; set; }
    }
}