using System.ComponentModel.DataAnnotations;

namespace TodoAppCSharp.Attributes;

    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now; 
            //Dates less than today are valid (true)

        }
}