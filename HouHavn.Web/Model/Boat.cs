using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouHavn.Web.Model
{
    public partial class Boat
    {
        public int BoatId { get; set; }

        [Display(Name = "Bådens navn")]
        [Required(ErrorMessage ="Bådens navn skal udfyldes")]
        public string Name { get; set; }

        [Display(Name = "Båd type")]
        [Required(ErrorMessage = "Bådens type skal udfyldes")]
        public string Type { get; set; }

        [Display(Name = "Længde")]
        [Required(ErrorMessage = "Bådens længde skal udfyldes")]
        public string Length { get; set; }

        [Display(Name = "Bredde")]
        [Required(ErrorMessage = "Bådens bredde skal udfyldes")]
        public string Width { get; set; }

        [Display(Name = "Dybte")]
        [Required(ErrorMessage = "Bådens dybte skal udfyldes")]
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