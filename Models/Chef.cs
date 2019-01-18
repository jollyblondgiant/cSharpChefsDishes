using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ID {get;set;}
        [Required(ErrorMessage="All Name Fields required")]
        [MinLength(3, ErrorMessage="A real name, please...")]
        [Display(Name="First Name: ")]
        public string FirstName {get;set;}
        [Required(ErrorMessage="All Name Field required")]
        [MinLength(3, ErrorMessage="A real name, please...")]
        [Display(Name="Last Name: ")]
        public string LastName {get;set;}
        [Required(ErrorMessage="Please input date of birth")]
        [DataType(DataType.Date)]
        [Display(Name="Date of Birth: ")]
        public DateTime DOB{get;set;}
        public List<Dish> ChefsDishes{get;set;}
    }
}