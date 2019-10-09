using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouHavn.Web.Model
{
    public partial class Berth
    {
        public Berth()
        {
            Boats = new HashSet<Boat>();
        }

        [Display(Name = "Båd plads nummer")]
        [Required(ErrorMessage = "Der skal indtastes et nummer")]
        public int BerthId { get; set; }

        [Display(Name = "Bro nummer")]
        [Required(ErrorMessage = "Der skal indtastes et nummer")]
        public int Bridge { get; set; }

        public virtual ICollection<Boat> Boats { get; set; }
    }
}