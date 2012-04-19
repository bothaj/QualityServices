using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcContrib.Pagination;
using System.Configuration;

namespace QualityServices.ViewModels
{
    public abstract class ListBaseViewModel<I> : BaseViewModel, IListBaseViewModel
        where I : ListItemBaseViewModel
    {
        public string ReplaceDivName
        {
            get
            {
                return string.Concat("divResults", this.ViewModelName);
            }
        }

        public abstract IPagination<I> List { get; set; }

        private int? _pageNo = null;
        public int? Page
        {
            get
            {
                if (_pageNo == null || _pageNo == 0)
                    _pageNo = 1;

                return _pageNo;
            }
            set { _pageNo = value; }
        }

        public int PageNumber
        {
            get { return this.List.PageNumber; }
        }

        public int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        public virtual int TotalItems
        {
            get { return this.List.TotalItems; }
            set { }
        }

        public virtual int TotalPages
        {
            get { return this.List.TotalPages; }
        }

        public virtual bool HasPreviousPage
        {
            get { return this.List.HasPreviousPage; }
        }

        public virtual bool HasNextPage
        {
            get { return this.List.HasNextPage; }
        }
    }
}
