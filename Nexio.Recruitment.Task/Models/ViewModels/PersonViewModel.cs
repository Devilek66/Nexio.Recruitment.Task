using Nexio.Recruitment.Task.CustomDataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nexio.Recruitment.Task.Models.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [DisplayName("Imię")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Data Ur.")]
        [AgeValidator(ErrorMessage ="Nie masz 18 lat!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Wzrost")]
        [Range(1,300)]
        public int Height { get; set; }

        public EyeColorEnum EyeColor { get; set; }
    }
}