using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.UI.Utilities
{
    public class ValidatorHelper
    {
        public static bool Validate(object model, List<string> messages)
        {
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);

            bool result = Validator.TryValidateObject(model, context, errors);

            foreach (var error in errors)
            {
                messages.Add(error.ErrorMessage);
            }

            return result;
        }

        public static string GetMessage(List<string> messages)
        {
            StringBuilder messageBuilder = new StringBuilder("There are errors: " + Environment.NewLine);

            messages.ForEach(m => messageBuilder.AppendLine(m));

            return messageBuilder.ToString();
        }
    }
}
