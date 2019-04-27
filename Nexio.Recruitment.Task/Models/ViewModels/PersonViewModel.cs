using System;

namespace Nexio.Recruitment.Task.Models.ViewModels
{
    public class PersonViewModel
    {
        public GenderEnum Gender { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public EyeColorEnum EyeColor { get; set; }
    }
}