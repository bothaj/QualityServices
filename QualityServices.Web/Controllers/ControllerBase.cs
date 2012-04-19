using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JBSoft.Dal.Models;
//using EventManagement.Bll;
//using EventManagement.Models.enums;
using JBSoft.Bll;
using System.Security.Cryptography;
using System.Text;
using JBSoft.Web.ViewModels;
using JBSoft.Web.Security;
using JBSoft.Dal.ResultHelpers;
using System.Drawing;
using System.Drawing.Imaging;
using JBSoft.Logging;
using System.Configuration;
using QualityServices.Bll;
using QualityServices.Models;
using QualityServices.Managers;

namespace QualityServices.Controllers
{
    public abstract class ControllerBase : Controller
    {
        #region Private Members

        private IUserGroupBll userGroupBll;
        private IUserBll userBll;
        private ILanguageBll languageBll;
        private ICurrencyBll currencyBll;
        private IModuleBll moduleBll;
        private IPersonBll personBll;
        //private IAttendeeBll _attendeeBll;
        //private ISubEventBll _subEventBll;
        //private IAttendeeGroupingBll _attendeeGroupingBll;
        //private IAttendeeSubEventBll _attendeeSubEventBll;
        //private IAttendeeFlightBll _attendeeFlightBll;
        //private IFlightBll _flightBll;
        //private IAccommodationSectionBll _accommodationSectionBll;
        //private ILocationBll _locationBll;
        //private ISubEventTypeBll _subeventtypeBll;
        //private IAccommodationBll _accommodationBll;
        //private IPersonalAssistantBll _personalAssistantBll;
        //private IEventBll _eventBll;
        //private IRoomBll _roomBll;
        //private ICityBll _cityBll;
        //private IFlightAllocationsBll _flightAllocationBll;
        //private IGolfInformationBll _golfInformationBll;
        //private IChildBll _childBll;
        //private IChildMinderBll _childMinderBll;
        //private IPrincipalBll _principalBll;
        //private IGroupingBll _groupingBll;
        //private IAttendeeRoomBll _attendeeRoomBll;
        //private IPartnerBll _partnerBll;

        #endregion

        #region Protected Members

        protected IUserGroupBll UserGroupBll
        {
            get
            {
                if (this.userGroupBll == null)
                    this.userGroupBll = new UserGroupBll();

                return userGroupBll;
            }
        }

        protected IUserBll UserBll
        {
            get
            {
                if (this.userBll == null)
                    this.userBll = new UserBll();

                return userBll;
            }
        }

        //protected IAttendeeBll AttendeeBll
        //{
        //    get
        //    {
        //        if (this._attendeeBll == null)
        //            this._attendeeBll = new AttendeeBll();

        //        return _attendeeBll;
        //    }
        //}

        protected ILanguageBll LanguageBll
        {
            get
            {
                if (this.languageBll == null)
                    this.languageBll = new LanguageBll();

                return languageBll;
            }
        }


        protected ICurrencyBll CurrencyBll
        {
            get
            {
                if (this.currencyBll == null)
                    this.currencyBll = new CurrencyBll();

                return currencyBll;
            }
        }

        protected IModuleBll ModuleBll
        {
            get
            {
                if (this.moduleBll == null)
                    this.moduleBll = new ModuleBll();

                return moduleBll;
            }
        }

        protected IPersonBll PersonBll
        {
            get
            {
                if (this.personBll == null)
                    this.personBll = new PersonBll();

                return personBll;
            }
        }


        //protected ISubEventBll SubEventBll
        //{
        //    get
        //    {
        //        if (this._subEventBll == null)
        //            this._subEventBll = new SubEventBll();

        //        return _subEventBll;
        //    }
        //}

        //protected IAttendeeGroupingBll AttendeeGroupingBll
        //{
        //    get
        //    {
        //        if (this._attendeeGroupingBll == null)
        //            this._attendeeGroupingBll = new AttendeeGroupingBll();

        //        return _attendeeGroupingBll;
        //    }
        //}

        //protected IAttendeeSubEventBll AttendeeSubEventBll
        //{
        //    get
        //    {
        //        if (this._attendeeSubEventBll == null)
        //            this._attendeeSubEventBll = new AttendeeSubEventBll();

        //        return _attendeeSubEventBll;
        //    }
        //}

        //protected IPartnerBll PartnerBll
        //{
        //    get
        //    {
        //        if (this._partnerBll == null)
        //            this._partnerBll = new PartnerBll();

        //        return _partnerBll;
        //    }
        //}

        //protected IAttendeeRoomBll AttendeeRoomBll
        //{
        //    get
        //    {
        //        if (this._attendeeRoomBll == null)
        //            this._attendeeRoomBll = new AttendeeRoomBll();

        //        return _attendeeRoomBll;
        //    }
        //}

        //protected IPersonalAssistantBll PersonalAssistantBll
        //{
        //    get
        //    {
        //        if (this._personalAssistantBll == null)
        //            this._personalAssistantBll = new PersonalAssistantBll();

        //        return _personalAssistantBll;
        //    }
        //}

        //protected IGroupingBll GroupingBll
        //{
        //    get
        //    {
        //        if (this._groupingBll == null)
        //            this._groupingBll = new GroupingBll();

        //        return _groupingBll;
        //    }
        //}

        //protected IChildBll ChildBll
        //{
        //    get
        //    {
        //        if (this._childBll == null)
        //            this._childBll = new ChildBll();

        //        return _childBll;
        //    }
        //}

        //protected IChildMinderBll ChildMinderBll
        //{
        //    get
        //    {
        //        if (this._childMinderBll == null)
        //            this._childMinderBll = new ChildMinderBll();

        //        return _childMinderBll;
        //    }
        //}

        //protected IAttendeeFlightBll AttendeeFlightBll
        //{
        //    get
        //    {
        //        if (this._attendeeFlightBll == null)
        //            this._attendeeFlightBll = new AttendeeFlightBll();

        //        return _attendeeFlightBll;
        //    }
        //}

        //protected IFlightBll FlightBll
        //{
        //    get
        //    {
        //        if (this._flightBll == null)
        //            this._flightBll = new FlightBll();

        //        return _flightBll;
        //    }
        //}

        //protected IAccommodationSectionBll AccomodationSectionBll
        //{
        //    get
        //    {
        //        if (this._accommodationSectionBll == null)
        //            this._accommodationSectionBll = new AccommodationSectionBll();

        //        return _accommodationSectionBll;
        //    }
        //}

        //protected IEventBll EventBll
        //{
        //    get
        //    {
        //        if (this._eventBll == null)
        //            this._eventBll = new EventBll();

        //        return _eventBll;
        //    }
        //}

        //protected ISubEventTypeBll SubEventTypeBll
        //{
        //    get
        //    {
        //        if (this._subeventtypeBll == null)
        //            this._subeventtypeBll = new SubEventTypeBll();

        //        return _subeventtypeBll;
        //    }
        //}

        //protected IGolfInformationBll GolfInformationBll
        //{
        //    get
        //    {
        //        if (this._golfInformationBll == null)
        //            this._golfInformationBll = new GolfInformationBll();

        //        return _golfInformationBll;
        //    }
        //}

        //protected ILocationBll LocationBll
        //{
        //    get
        //    {
        //        if (this._locationBll == null)
        //            this._locationBll = new LocationBll();

        //        return _locationBll;
        //    }
        //}

        //protected IAccommodationBll AccommodationBll
        //{
        //    get
        //    {
        //        if (this._accommodationBll == null)
        //            this._accommodationBll = new AccommodationBll();

        //        return _accommodationBll;
        //    }
        //}

        //protected IRoomBll RoomBll
        //{
        //    get
        //    {
        //        if (this._roomBll == null)
        //            this._roomBll = new RoomBll();

        //        return _roomBll;
        //    }
        //}

        //protected ICityBll CityBll
        //{
        //    get
        //    {
        //        if (this._cityBll == null)
        //            this._cityBll = new CityBll();

        //        return _cityBll;
        //    }
        //}

        //protected IFlightAllocationsBll FlightAllocationsBll
        //{
        //    get
        //    {
        //        if (this._flightAllocationBll == null)
        //            this._flightAllocationBll = new FlightAllocationsBll();

        //        return _flightAllocationBll;
        //    }
        //}

        //protected IPrincipalBll PrincipalBll
        //{
        //    get
        //    {
        //        if (this._principalBll == null)
        //            this._principalBll = new PrincipalBll();

        //        return _principalBll;
        //    }
        //}


        #endregion

        #region Properties

        protected int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        protected string SAPConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["SAP"].ToString();
            }
        }

        #endregion

        #region Private Methods

        private void SaveJPG100(Bitmap bmp, string filename)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            bmp.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #endregion

        #region Protected Methods

        protected string TranslateError(string errorMessage)
        {
            return errorMessage.Contains("FK_User__UserGroup") ? "You cannot delete this User Group because there are users assigned to this User Group. Please remove these users first." : errorMessage;
        }

        /// <summary>
        /// Returns a sensible error message from a potential list of errors passed in from the dal result helpers
        /// </summary>
        protected string ErrorMessage(List<EntityError> entityErrors)
        {
            string errorMessage = "";

            int counter = 0;
            foreach (var errMsg in entityErrors)
            {
                if (counter++ > 0)
                    errorMessage = string.Concat(errorMessage, "<br/>");

                errorMessage = string.Concat(errorMessage, errMsg.ErrorMessage);
            }

            return errorMessage;
        }

        /// <summary>
        /// List Factory method.
        /// Used when when to create lists from anonymous objects.
        /// </summary>
        protected List<T> MakeList<T>(T itemOftype)
        {
            List<T> newList = new List<T>();
            return newList;
        }

        /// <summary>
        /// Logic to gracefully handle an unhandled exception and the manner it should be displayed.
        /// </summary>
        protected override void OnException(ExceptionContext filterContext)
        {
            ViewData["ClientAlert_Message"] = filterContext.Exception.Message;

            //Logger.Instance.Log.ErrorException("Unhandled Error", filterContext.Exception);
            //Logger.Instance.Log.Trace("Unhandled Error - ", filterContext.Exception.Message);
            //Logger.Instance.Log.Trace("Unhandled Error - ", filterContext.Exception.StackTrace);

            if (CurrentUser.UserId == Guid.Empty)
                Response.Redirect("~/Error/UnhandledException");
            else
                Response.Redirect("~/Error/UnhandledSecureException");
        }

        /// <summary>
        /// Resizes an image and writes to a temporary storage location on disk.
        /// </summary>
        protected void ResizeImageAndSave(HttpPostedFileBase file, string type)
        {
            Bitmap bmpResized = null;
            System.Drawing.Image imgInput = null;

            try
            {
                int intNewWidth;
                int intNewHeight;
                imgInput = System.Drawing.Image.FromStream(file.InputStream);

                //Determine image format 
                ImageFormat fmtImageFormat = imgInput.RawFormat;

                //get image original width and height 
                int intOldWidth = imgInput.Width;
                int intOldHeight = imgInput.Height;

                //determine if landscape or portrait 
                int intMaxSide;

                if (intOldWidth >= intOldHeight)
                {
                    intMaxSide = intOldWidth;
                }
                else
                {
                    intMaxSide = intOldHeight;
                }

                if (intMaxSide > 250)
                {
                    //set new width and height	
                    double dblCoef = 250 / (double)intMaxSide;
                    intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                    intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
                }
                else
                {
                    intNewWidth = intOldWidth;
                    intNewHeight = intOldHeight;
                }

                //determine the fileName
                var fileName = file.FileName.Remove(file.FileName.LastIndexOf('.'));

                //create new bitmap 
                bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);
                //if (VariableManager.DBPics)
                if (true)
                {
                    TempData["DBImage"] = null;
                    ImageConverter converter = new ImageConverter();
                    TempData["DBImage"] = (byte[])converter.ConvertTo(bmpResized, typeof(byte[]));
                }
                else
                {
                    this.SaveJPG100(bmpResized, String.Format("{0}Uploads/{1}_{2}.jpg",
                                                              VariableManager.ContentStoragePath, type, fileName));
                }
            }
            finally
            {
                //release used resources 
                if (imgInput != null)
                    imgInput.Dispose();

                if (bmpResized != null)
                    bmpResized.Dispose();
            }
        }

        /// <summary>
        /// Retuns the string password into a encrypted hash
        /// </summary>
        protected byte[] GetPasswordHash(string password)
        {
            using (MD5 csp = new MD5CryptoServiceProvider())
            {
                return csp.ComputeHash(new ASCIIEncoding().GetBytes(password));
            }
        }

        /// <summary>
        /// Renders a partial view as an string. Used when returning Json
        /// </summary>
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        #endregion

        #region ViewData Methods

        protected void LoadUsersIntoViewData(Guid? selectedValue, bool loadEmpty)
        {
            var resultsList = new List<DescriptionGuidPair>();

            //Load the default entry
            var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
            resultsList.Add(defaultObj);

            if (!loadEmpty)
            {
                //Load the selected data
                foreach (var item in this.UserBll.SelectAll(CurrentUser.UserId))
                    resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.FullName });
            }

            //Create the select list
            this.ViewData["UserId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        }


        protected void LoadLanguagesIntoViewData(string selectedValue, bool loadEmpty)
        {
            var resultsList = new List<DescriptionTextPair>();

            //Load the default entry
            var defaultObj = new DescriptionTextPair() { TextId = string.Empty, Description = "Select" };
            resultsList.Add(defaultObj);

            if (!loadEmpty)
            {
                //Load the selected data
                foreach (var item in this.LanguageBll.SelectAll(CurrentUser.UserId))
                    resultsList.Add(new DescriptionTextPair() { TextId = item.Code, Description = item.Code });
            }

            //Create the select list
            this.ViewData["LanguageCode"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        }


        protected void LoadUserGroupsIntoViewData(string name, Guid? selectedValue, bool loadEmpty)
        {
            var resultsList = new List<DescriptionGuidPair>();

            //Load the default entry
            var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
            resultsList.Add(defaultObj);

            if (!loadEmpty)
            {
                //Load the selected data
                foreach (var item in this.UserGroupBll.SelectAll(CurrentUser.UserId))
                    resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
            }

            //Create the select list
            this.ViewData[name] = new SelectList(resultsList, "Id", "Description", selectedValue);
        }

        //protected void LoadTimeSlotsIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(TimeSlots)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(TimeSlots), value).Replace("h", "").Replace("m", ":") });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData[id] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadRegiseterdEnumIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(Registered)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(Registered), value).Replace("_", " ") });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData[id] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadLanguagesIntoViewData(string selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionTextPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionTextPair() { TextId = string.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.LanguageBll.SelectAll(CurrentUser.UserId))
        //            resultsList.Add(new DescriptionTextPair() { TextId = item.Code, Description = item.Code });
        //    }

        //    //Create the select list
        //    this.ViewData["LanguageCode"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        //}

        protected void LoadCurrenciesIntoViewData(string selectedValue, bool loadEmpty)
        {
            var resultsList = new List<DescriptionTextPair>();

            //Load the default entry
            var defaultObj = new DescriptionTextPair() { TextId = string.Empty, Description = "Select" };
            resultsList.Add(defaultObj);

            if (!loadEmpty)
            {
                //Load the selected data
                foreach (var item in this.CurrencyBll.SelectAll(CurrentUser.UserId))
                    resultsList.Add(new DescriptionTextPair() { TextId = item.Code, Description = item.Name });
            }

            //Create the select list
            this.ViewData["CurrencyCode"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        }

        //protected void LoadModulesIntoViewData(string selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in CacheManager.Instance.Modules)
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["ModuleId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadAttendeeTypesIntoViewData(string name, int? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(AttendeeTypes)))
        //        {
        //            if ((int)value != (int)AttendeeTypes.Crew && (int)value != (int)AttendeeTypes.Staff)
        //            {
        //                resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(AttendeeTypes), value) });
        //            }
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData[name] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadFlightTypesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(FlightTypes)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(FlightTypes), value).Replace("_", " ").Replace("0", "-") });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["FlightTypeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadGuestTypesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(GuestTypes)))
        //        {
        //            if ((int)value != (int)GuestTypes.Crew)
        //            {
        //                resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(GuestTypes), value) });
        //            }
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["GuestTypeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["PartnerGuestTypeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SearchGuestTypeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);

        //}

        //protected void LoadPaymentsIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(Payments)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(Payments), value).Replace("_", " ") });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["Paid"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadRouteIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    //var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(Payments)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(FlightRoute), value) });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["SearchRoute"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadPartnerShirtSizesesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(ShirtSize)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(ShirtSize), value) });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["PartnerShirtSizeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadShirtSizesesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(ShirtSize)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(ShirtSize), value) });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["ShirtSizeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadGuidEventsIntoViewData(string[] names, Guid? selectedValue, bool loadEmpty)
        //{

        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in CacheManager.Instance.Events)
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    }
        //}

        //protected void LoadGuidSubEventsIntoViewData(string[] names, Guid? selectedValue, bool loadEmpty)
        //{

        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.LocationBll.SelectAll(ActiveStatus.Active, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    }
        //}

        //protected void LoadGuidGroupingsIntoViewData(string[] names, Guid? subEvent, Guid? selectedValue, bool loadEmpty)
        //{

        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        if (subEvent != null)
        //        {
        //            SubEvent sub_Event = SubEventBll.SelectById((Guid)subEvent, CurrentUser.UserId);

        //            if (sub_Event != null)
        //            {
        //                foreach (var item in this.GroupingBll.SelectAll(ActiveStatus.Active, null, sub_Event.EventId, subEvent, CurrentUser.UserId))
        //                    resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in this.GroupingBll.SelectAll(ActiveStatus.Active, null, null, null, CurrentUser.UserId))
        //                resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //        }
        //    }

        //    //Create the select list
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    }
        //}

        //protected void LoadCustomGuidGroupingsIntoViewData(string[] names, Guid? subEvent, Guid? selectedValue, bool loadEmpty)
        //{

        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        if (subEvent != null)
        //        {
        //            SubEvent sub_Event = SubEventBll.SelectById((Guid)subEvent, CurrentUser.UserId);

        //            if (sub_Event != null)
        //            {
        //                foreach (
        //                    var item in
        //                        this.GroupingBll.SelectAll(ActiveStatus.Active, null, sub_Event.EventId, subEvent,
        //                                                   CurrentUser.UserId))
        //                {
        //                    if (item.Description == "Not Allocated")
        //                    {
        //                        resultsList.Add(new DescriptionGuidPair
        //                        {
        //                            Description =
        //                                item.Description,
        //                            Id = item.Id
        //                        });
        //                    }
        //                    else if (item.GroupingDate == null)
        //                    {
        //                        resultsList.Add(new DescriptionGuidPair
        //                        {
        //                            Description =
        //                                item.Description + " - " + " UnSpecified",
        //                            Id = item.Id
        //                        });
        //                    }
        //                    else
        //                    {
        //                        resultsList.Add(new DescriptionGuidPair
        //                        {
        //                            Description =
        //                                item.Description + " - " +
        //                                Convert.ToDateTime(item.GroupingDate).ToString("dd/MM/yyyy"),
        //                            Id = item.Id
        //                        });
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (
        //                var item in
        //                    this.GroupingBll.SelectAll(ActiveStatus.Active, null, null, null, CurrentUser.UserId))
        //            {
        //                if (item.Description == "Not Allocated")
        //                {
        //                    resultsList.Add(new DescriptionGuidPair
        //                    {
        //                        Description =
        //                            item.Description,
        //                        Id = item.Id
        //                    });
        //                }
        //                else if (item.GroupingDate == null)
        //                {
        //                    resultsList.Add(new DescriptionGuidPair
        //                    {
        //                        Description =
        //                            item.Description,
        //                        Id = item.Id
        //                    });
        //                }
        //                else
        //                {
        //                    resultsList.Add(new DescriptionGuidPair
        //                    {
        //                        Description =
        //                            item.Description + " - " +
        //                            Convert.ToDateTime(item.GroupingDate).ToString("dd/MM/yyyy"),
        //                        Id = item.Id
        //                    });
        //                }
        //            }
        //        }

        //        //Create the select list
        //        for (int i = 0; i < names.Length; i++)
        //        {
        //            this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //        }
        //    }
        //}

        //protected void LoadSubEventTypesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(SubEventTypes)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(SubEventTypes), value) });
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["SubEventType"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SubEventTypeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SearchSubEventType"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadLocationsIntoViewData(string[] names, Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.LocationBll.SelectAll(ActiveStatus.Active, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    }
        //}

        //protected void LoadGuidCityIntoViewData(string name, Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.CityBll.SelectAll(ActiveStatus.Active, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData[name] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        protected void ActiveStatusSelectListViewData(int? selectedValue)
        {
            var list = new List<DescriptionIdPair>();

            var firstItem = new DescriptionIdPair() { Id = 1, Description = "Active" };
            list.Add(firstItem);
            var secondItem = new DescriptionIdPair() { Id = 0, Description = "InActive" };
            list.Add(secondItem);

            this.ViewData["StatusId"] = new SelectList(list, "Id", "Description", selectedValue);
        }

        //protected void LoadSubEventsIntoViewData(string[] names, Guid? eventID, Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.SubEventBll.Search(ActiveStatus.Active, null, eventID, null, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        this.ViewData[names[i].ToString()] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    }
        //}

        //protected void LoadSubEventsForGroupingIntoViewData(Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.SubEventBll.SelectAllForGroupedEvent(ActiveStatus.Active, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["SubEventId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadAccommodationsIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.AccommodationBll.SelectAll(ActiveStatus.Active, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["AccommodationId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SearchAccommodationId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadFlightsIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.FlightBll.SelectAll(ActiveStatus.Active, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description + "(" + item.FlightDate.Date.ToShortDateString() + ")" + "-" + item.FlightTypeDesc });
        //    }

        //    //Create the select list
        //    this.ViewData["FlightId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SearchFlightId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadFlightsAllocationsIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.FlightAllocationsBll.SelectAll(ActiveStatus.Active, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.FlightNo });
        //    }

        //    //Create the select list
        //    this.ViewData["FlightAllocationsId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadFilteredFlightsAllocationsIntoViewData(Guid? flightId, Guid? selectedValue)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();
        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);
        //    //Load the selected data
        //    foreach (var item in this.FlightAllocationsBll.SelectByFlightId(flightId, CurrentUser.UserId))
        //        resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.FlightNo });


        //    //Create the select list
        //    this.ViewData["FlightAllocationsId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadRoomsIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (resultsList.Count <= 0)
        //    {
        //        resultsList.Add(new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" });
        //    }

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.RoomBll.SelectAll(ActiveStatus.Active, null, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["RoomId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadAccommodationSectionsIntoViewData(Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (resultsList.Count <= 0)
        //    {
        //        resultsList.Add(new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" });
        //    }

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.AccomodationSectionBll.SelectAll(ActiveStatus.Active, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["AccommodationSectionId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //    this.ViewData["SearchAccommodationSectionId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadEnumDietaryRequirementsIntoViewData(int? selectedPrincipalDietValue, int? selecetedPartnerDiet, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(DietaryRequirements)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(DietaryRequirements), value) });
        //        }
        //    }
        //    //Create the select list
        //    this.ViewData["DietaryRequirement"] = new SelectList(resultsList, "Id", "Description", selectedPrincipalDietValue);
        //    this.ViewData["PartnerDietaryRequirement"] = new SelectList(resultsList, "Id", "Description", selecetedPartnerDiet);
        //    this.ViewData["ChildRequirement"] = new SelectList(resultsList, "Id", "Description", selectedPrincipalDietValue);
        //}

        //protected void LoadAttendeeAllocationIntoViewData(int? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionIdPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionIdPair() { Id = 0, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        foreach (var value in Enum.GetValues(typeof(AttendeeAllocations)))
        //        {
        //            resultsList.Add(new DescriptionIdPair() { Id = (int)value, Description = Enum.GetName(typeof(AttendeeAllocations), value).Replace("_", " ") });
        //        }
        //    }
        //    //Create the select list
        //    this.ViewData["AttendeeAllocations"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadFlightsIntoViewData(Guid? selectedValue, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    //Load the default entry
        //    var defaultObj = new DescriptionGuidPair() { Id = Guid.Empty, Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.FlightBll.SelectAll(ActiveStatus.Active, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description + "(" + item.FlightDate.Date.ToShortDateString() + ")" + "-" + item.FlightTypeDesc });
        //    }

        //    //Create the select list
        //    this.ViewData["FlightId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadHandicapsIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionTextPair>();

        //    var defaultObj = new DescriptionTextPair() { TextId = "", Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        resultsList.Add(new DescriptionTextPair() { TextId = "37", Description = "N/A" });

        //        //Load the selected data
        //        for (int i = 0; i <= 24; i++)
        //        {
        //            if (i.ToString().Length == 1)
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //            else
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["Handicap"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        //    this.ViewData["SearchHandicap"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        //}

        //protected void LoadPartnerHandicapsIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionTextPair>();

        //    var defaultObj = new DescriptionTextPair() { TextId = "", Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        resultsList.Add(new DescriptionTextPair() { TextId = "37", Description = "N/A" });

        //        //Load the selected data
        //        for (int i = 0; i <= 24; i++)
        //        {
        //            if (i.ToString().Length == 1)
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //            else
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["PartnerHandicap"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        //}

        //protected void LoadNumberOfAttendeesIntoViewData(int? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionTextPair>();

        //    var defaultObj = new DescriptionTextPair() { TextId = "0", Description = "Select" };
        //    resultsList.Add(defaultObj);

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        for (int i = 0; i <= 15; i++)
        //        {
        //            if (i.ToString().Length == 1)
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //            else
        //            {
        //                resultsList.Add(new DescriptionTextPair() { TextId = i.ToString(), Description = i.ToString() });
        //            }
        //        }
        //    }

        //    //Create the select list
        //    this.ViewData["NumberOfAttendees"] = new SelectList(resultsList, "TextId", "Description", selectedValue);
        //}

        //protected void LoadGolfInfoAttendeesIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.AttendeeBll.SelectAll(ActiveStatus.Active, null, null, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["AttendeeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        //protected void LoadAttendeesIntoViewData(Guid? selectedValue, string id, bool loadEmpty)
        //{
        //    var resultsList = new List<DescriptionGuidPair>();

        //    if (!loadEmpty)
        //    {
        //        //Load the selected data
        //        foreach (var item in this.AttendeeBll.SelectAll(ActiveStatus.Active, null, null, null, null, null, CurrentUser.UserId))
        //            resultsList.Add(new DescriptionGuidPair() { Id = item.Id, Description = item.Description });
        //    }

        //    //Create the select list
        //    this.ViewData["AttendeeId"] = new SelectList(resultsList, "Id", "Description", selectedValue);
        //}

        #endregion
    }
}