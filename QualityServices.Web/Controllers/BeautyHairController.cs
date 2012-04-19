using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualityServices.ViewModels;
using QualityServices.Bll;
using QualityServices.Models;
using JBSoft.Dal.Models;
using MvcContrib.Pagination;
using JBSoft.Web.ViewModels;
using JBSoft.Web.Security;

namespace QualityServices.Controllers
{
    public class BeautyHairController : ControllerBase
    {
        //
        // GET: /BeautyHair/

        //[Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            ////ServiceBll serviceBll = new Bll.ServiceBll();

            var viewModel = new ManageBeautyHairViewModel();
            ////var items = serviceBll.SelectAll(null, null, (int?)ActiveStatus.Active);

            ////viewModel.ListViewModel.NonpagedList = GetPagedList(page, items);

            return View(viewModel);
            
            //var viewModel = new ManageBeautyHairViewModel();
            //var items = LocationBll.SelectAll(ActiveStatus.Active, null, false, CurrentUser.UserId);

            //viewModel.ListViewModel.List = GetPagedList(page, items);

            //SelectListViewData(null);
            //this.ActiveStatusSelectListViewData(null);
            //base.LoadLocationsIntoViewData(null, false);
            //return PartialView("Index", viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RefreshItems(BeautyHairListViewModel viewModel)
        {
            ServiceBll serviceBll = new ServiceBll();

            //if (String.IsNullOrEmpty(viewModel.SearchBarCode))
            //{
            //    barcode = null;
            //}
            //else
            //{
            //    barcode = viewModel.SearchBarCode;
            //}



            var items = serviceBll.SelectAll(null, null, (int?)ActiveStatus.Active);
            if (items.Count > 0)
                viewModel.TotalItems = items[0].RowCount;

            viewModel.NonpagedList = GetPagedList(viewModel.Page, items);
            viewModel.SearchDescription = viewModel.SearchDescription;
            viewModel.Page = viewModel.Page;

            var jsonViewModel = new JsonViewModel();
            //ActiveStatusSelectListViewData(null);
            
            jsonViewModel.Html = base.RenderPartialViewToString("List", viewModel);
            jsonViewModel.HasErrors = false;
            jsonViewModel.IsValid = true;

            return Json(jsonViewModel);
        }

        private List<BeautyHairListItemViewModel> GetPagedList(int? page, IEnumerable<Service> list)
        {
            int pageNumber = page ?? 1;

            var results = new List<BeautyHairListItemViewModel>();
            foreach (var item in list)
            {
                var result = new BeautyHairListItemViewModel();
                result.Id = item.Id;
                result.CategoryName = item.CategoryName;
                if (item.ServiceName != null)
                {
                    if (item.ServiceName.Length > 20)
                    {
                        result.ServiceName = item.ServiceName.Substring(0, 20) + "...";
                    }
                    else
                    {
                        result.ServiceName = item.ServiceName;
                    }
                }

                results.Add(result);
            }

            return results;//.AsPagination(pageNumber, PageSize);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult LoadExistingDetail(Guid id)
        {
            var viewModel = new BeautyHairDetailsViewModel();
            ServiceBll serviceBll = new ServiceBll();

            if (id != Guid.Empty)
            {
                var service = serviceBll.SelectById(id, CurrentUser.UserId);

                if (service != null)
                {
                    viewModel.Id = service.Id;

                    //var ServiceType = this.serviceBll.SelectById(service.ServiceTypeId, CurrentUser.UserId);
                    //if (ServiceType != null)
                    //{
                    //    viewModel.ServiceServiceType = ServiceType.Description;
                    //    var group = this.ServiceGroupBll.SelectById(ServiceType.ServiceGroupId, CurrentUser.UserId);
                    //    if (group != null)
                    //        viewModel.ServiceServiceClass = group.Description;
                    //}

                    //var location = this.LocationBll.SelectById(Service.LocationId, CurrentUser.UserId);
                    //if (location != null)
                    //{
                    //    viewModel.ServiceLocationDescription = location.Description;
                    //}                    
                }
                else
                {
                    throw new Exception("Service not found for Id passed through");
                }
            }
            else
            {
                //SelectListViewData(null);
                //this.LoadServiceTypesIntoViewData(null, "ServiceTypeId", false, null);
                //this.LoadServiceRoomIntoViewData(null, "ServiceRoomId", false);
                //this.LoadStocktakeIntoViewData(null, "StocktakeId", false);
            }

            var jsonViewModel = new JsonViewModel();

            jsonViewModel.Html = base.RenderPartialViewToString("Details", viewModel);
            jsonViewModel.HasErrors = false;
            jsonViewModel.IsValid = true;

            return Json(jsonViewModel);

            //return PartialView("Details", viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult ManageDetail(BeautyHairDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceBll serviceBll = new ServiceBll();

                try
                {
                    var item = new Service();

                    if (viewModel.Id != Guid.Empty)
                        item = serviceBll.SelectById(viewModel.Id, CurrentUser.UserId);

                    item.Id = viewModel.Id;
                    item.ServiceCategory = viewModel.ServiceCategory;
                    item.ServiceName = viewModel.ServiceName;

                    if (viewModel.Id == Guid.Empty)
                        serviceBll.Insert(item, CurrentUser.UserId);
                    else
                    {
                        serviceBll.Update(item, CurrentUser.UserId);
                    }
                }
                catch (Exception ex)
                {
                    viewModel.AddModelError("SYSTEM ERROR - " + ex.Message);
                    //Logger.Instance.Log.Error("Service Controller - ManageDetail (POST) - " + ex.Message);
                }
            }

            //SelectListViewData(viewModel.Id);
            //this.LoadServiceTypesIntoViewData(viewModel.ServiceTypeId, "ServiceTypeId", false, null);
            //this.LoadServiceRoomIntoViewData(viewModel.ServiceRoomId, "ServiceRoomId", false);
            //this.LoadServiceTypesIntoViewData(null, "SearchServiceTypeId", false, null);
            //this.LoadServiceRoomIntoViewData(null, "SearchServiceRoomId", false);
            return PartialView("Details", viewModel);
        }
    }
}
