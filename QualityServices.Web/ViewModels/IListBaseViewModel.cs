using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualityServices.ViewModels
{
    public interface IListBaseViewModel
    {
        string ReplaceDivName { get; }

        int? Page { get; set; }

        int PageNumber { get; }

        int PageSize { get; }

        int TotalItems { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
