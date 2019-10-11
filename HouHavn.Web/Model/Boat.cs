using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouHavn.Web.Model
{
    public partial class Boat
    {
        public int BoatId { get; set; }

        [Display(Name = "Bådens navn")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Båd type")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Længde")]
        [Required]
        public double Length { get; set; }

        [Display(Name = "Bredde")]
        [Required]
        public double Width { get; set; }

        [Display(Name = "Dybte")]
        [Required]
        public double Dept { get; set; }

        [Display(Name = "Fremdrifts Type")]
        [Required]
        public string PropulsionType { get; set; }

        [Display(Name = "Ejer")]
        [Required]
        public int Person { get; set; }

        [Display(Name = "Båd plads")]
        [Required]
        public int Berth { get; set; }

        [Display(Name = "Noter")]
        public string Notes { get; set; }
        public virtual Berth BerthNavigation { get; set; }
        public virtual Person PersonNavigation { get; set; }
    }
}