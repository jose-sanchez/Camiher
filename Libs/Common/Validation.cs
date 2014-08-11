using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Common
{
    public class Validation
    {
        /// <summary>
        /// Validate the email format
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmailAllowed(string text)
        {
            bool blnValidEmail = true;
            var regEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (text.Length > 0)
            {
                blnValidEmail = regEMail.IsMatch(text);
            }

            return blnValidEmail;
        }



        private void txtEmail_LostFocus(string email)
        {


        }
    }
}
