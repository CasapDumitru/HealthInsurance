using System;
using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Core.Models
{
    public class Is16YearsOld : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var enteredDate = (DateTime)value;
            var age = (DateTime.Now - enteredDate).TotalDays / 365;

            return true;
        }
    }
}
