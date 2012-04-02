
namespace EFCodeFirstValidation.Helpers
{
    using System.Linq;
    using System.Text;
    using System.Data.Entity.Validation;
    using System.Collections.Generic;

    class DbEntityValidationMessageParser
    {
        internal static string GetErrorMessage(DbEntityValidationException validationException)
        {
            StringBuilder messageBuilder = new StringBuilder("Validation Errors").AppendLine();

            var messages = from validationResult in validationException.EntityValidationErrors
                           select GetErrorMessage(validationResult);

            messages.ToList<string>().ForEach(m => messageBuilder.AppendLine(m));

            return messageBuilder.ToString();
        }

        internal static string GetErrorMessage(IEnumerable<DbEntityValidationResult> validationResults)
        {
            StringBuilder errorMessagBuilder = new StringBuilder();

            validationResults.ToList<DbEntityValidationResult>()
                .ForEach(result => errorMessagBuilder.AppendLine(GetErrorMessage(result)));

            return errorMessagBuilder.ToString();
        }

        internal static string GetErrorMessage(DbEntityValidationResult validationResult)
        {
            return GetErrorMessage(validationResult.ValidationErrors);
        }

        internal static string GetErrorMessage(ICollection<DbValidationError> validationErrors)
        {
            StringBuilder errorMessageBuilder = new StringBuilder();

            List<string> errorMessages = (from validationError in validationErrors
                                          select string.Format(
                                              "Property: {0}, Error Message: {1}",
                                              validationError.PropertyName,
                                              validationError.ErrorMessage)).ToList<string>();

            errorMessages.ToList<string>().ForEach(m => errorMessageBuilder.AppendLine(m));

            return errorMessageBuilder.ToString();
        }
    }
}
