using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JBSoft.Web.ViewModels;

namespace QualityServices.ViewModels
{
    public class BaseViewModel : JBSoftBaseViewModel
    {
        public int PageSize = 20;

        protected const string DESCRIPTION_ERROR = "Please enter a description";
        protected const string DESCRIPTION_DISPLAY = "Description";
        protected const string PA_DESCRIPTION_ERROR = "Please enter PA Description";
        protected const string PARTNER_DESCRIPTION_ERROR = "Please enter partner Description";
        protected const string UTCMODIFIEDDATE_ERROR = "Please enter a utcmodifieddate";
        protected const string UTCMODIFIEDDATE_DISPLAY = "UtcModifiedDate";



        //protected const string EMAIL_REGULAR_EXPRESSION = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        protected const string EMAIL_REGULAR_EXPRESSION = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        protected const string PASSWORD_REGULAR_EXPRESSION = @"^(?!password$).*$";
        protected const string SACELLNUMBER_REGULAR_EXPRESSION = @"^[1-9]{9}$";
        protected const string SACELLNUMBERFULL_REGULAR_EXPRESSION = @"^[+][2][7][1-9]{9}$";

        private const string DECIMAL_FORMAT = "{0:#,###,###.##}";

        private const string DATETIME_FORMAT_DEFAULTDATE = "dd MMM yyyy";
        private const string DATETIME_FORMAT_DEFAULTDATETIME = "dd MMM yyyy - HH:mm:ss";

        protected const string SACELLNUMBER_REGULAR_EXPRESSION_ERROR = "Please enter a correct mobile number (eg: +27 821234567)";

    }
}