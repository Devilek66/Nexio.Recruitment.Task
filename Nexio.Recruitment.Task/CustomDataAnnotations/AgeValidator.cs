using System;
using System.ComponentModel.DataAnnotations;

namespace Nexio.Recruitment.Task.CustomDataAnnotations
{
    public class AgeValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else
            {
                return false;
            }
            DateTime tmp = DateTime.Now.AddYears(-18);
            if (tmp >= date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}