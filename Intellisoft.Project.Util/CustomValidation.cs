using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intellisoft.Project.Util
{
    public class CustomValidation : IValidator
    {

        private CustomValidation(string strMessage)
        {
            ErrorMessage = strMessage;
            IsValid = false;
        }

        public string ErrorMessage { get; set; }

        public bool IsValid { get; set; }

        public void Validate() { }

        public static void Display(string strmessage, Page oPage)
        {
            oPage.Validators.Add(new CustomValidation(strmessage));
        }

        public static void AddError(string strError, FormViewMode oFormViewMode, Page oPage)
        {
            CustomValidator oCustomValidator = new CustomValidator();
            oCustomValidator.IsValid = false;
            oCustomValidator.ErrorMessage = strError;
            oCustomValidator.ValidationGroup = (oFormViewMode == FormViewMode.Edit) ? "Update" : "Insert";

            oPage.Validators.Add(oCustomValidator);
        }

        public static void AddError(string strError, string sValidationGroup, Page oPage)
        {
            CustomValidator oCustomValidator = new CustomValidator();
            oCustomValidator.IsValid = false;
            oCustomValidator.ErrorMessage = strError;
            oCustomValidator.ValidationGroup = sValidationGroup;

            oPage.Validators.Add(oCustomValidator);
        }

        public static void AddErrors(string strError, string sValidationGroup, System.Web.UI.UserControl oPage)
        {
            CustomValidator oCustomValidator = new CustomValidator();
            oCustomValidator.IsValid = false;
            oCustomValidator.ErrorMessage = strError;
            oCustomValidator.ValidationGroup = sValidationGroup;

            oPage.Page.Validators.Add(oCustomValidator);
        }

    }
}
