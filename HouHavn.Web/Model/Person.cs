using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouHavn.Web.Model
{
    public partial class Person
    {
        public Person()
        {
            Boats = new HashSet<Boat>();
        }

        public int PersonId { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn skal udfyldes")]
        [MinLength(2, ErrorMessage = "Fornavn skal være mere end 1 bogstav")]
        public string FirstName { get; set; }

        [Display(Name = "Efternavn")]
        [Required(ErrorMessage = "Efternavn skal udfyldes")]
        [MinLength(2, ErrorMessage = "Efternavnet skal være mere end 1 bogstav")]
        public string LastName { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adressen skal udfyldes")]
        public string Address { get; set; }

        [Display(Name = "Post nummer")]
        [Required(ErrorMessage = "Post nummeret skal udfyldes")]
        public string PostalCode { get; set; }

        [Display(Name = "By")]
        [Required(ErrorMessage = "Byen skal udfyldes")]
        public string City { get; set; }

        [Display(Name = "Land")]
        [Required(ErrorMessage = "Landet skal udfyldes")]
        public string Country { get; set; }

        [Display(Name = "Tlf nummer")]
        [Required(ErrorMessage = "tlf nummeret skal udfyldes")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail skal udfyldes")]
        public string Email { get; set; }

        [Display(Name = "Kunde af havnen")]
        public int Member { get; set; }

        [Display(Name = "Bådlaug")]
        public int BoatGuild { get; set; }

        [Display(Name = "Jollelaug")]
        public int DingyGuild { get; set; }

        [Display(Name = "Noter")]
        public string Notes { get; set; }

        [Display(Name = "Kundens navn")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name = "Både")]
        public virtual ICollection<Boat> Boats { get; set; }
    }
}