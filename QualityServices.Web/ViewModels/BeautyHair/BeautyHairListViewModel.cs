using System.Collections.Generic;
using System.ComponentModel;
using MvcContrib.Pagination;
using QualityServices.ViewModels;
using JBSoft.Web.ViewModels;

namespace QualityServices.ViewModels
{
    public class BeautyHairListViewModel : ListBaseViewModel<BeautyHairListItemViewModel>
    {
        public List<BeautyHairListItemViewModel> NonpagedList { get; set; }

        [DisplayName("Description")]
        public string SearchDescription { get; set; }

        [DisplayName("Status:")]
        public int StatusId { get; set; }

        public override IPagination<BeautyHairListItemViewModel> List { get; set; }

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BeautyHairListViewModel()
        {
            var tmpList = new List<BeautyHairListItemViewModel>();
            this.List = tmpList.AsPagination(1, PageSize);

            this.ViewModelName = "BeautyHairList";
        }

        #endregion
    }
}

