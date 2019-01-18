using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int ID {get;set;}
        [Required]
        [Display(Name="Name of Dish: ")]
        [MinLength(3, ErrorMessage="That name isn't descriptive enough.")]
        public string Name{get;set;}
        [Required]
        [Display(Name="# of calories: ")]
        [MinValue(0, ErrorMessage="Negative Calories? I don't habeeb it!")]
        public int Calories{get;set;}

        [Required]
        [Display(Name="Description: ")]
        [MinLength(8)]
        [DataType(DataType.MultilineText)]
        public string Description{get;set;}

        [Required]
        [Display(Name="Tastiness")]
        [Range(1,6)]
        public int Tastiness{get;set;}
        public int CreatorID{get;set;}
        public Chef Creator{get;set;}
    }
    public class MinValueAttribute : ValidationAttribute
    {
        private int _minValue;
        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }
        public override bool IsValid(object value)
        {
            return (int)value >= _minValue;
        }
    }
}