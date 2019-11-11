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
        public string Length { get; set; }

        [Display(Name = "Bredde")]
        [Required]
        public string Width { get; set; }

        [Display(Name = "Dybte")]
        [Required]
        public string Depth { get; set; }

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

        [Display(Name = "Bådplads")]
        public virtual Berth BerthNavigation { get; set; }

        [Display(Name = "Ejer")]
        public virtual Person PersonNavigation { get; set; }
    }
}