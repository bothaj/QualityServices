using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QualityServices.Models.Enums;

namespace QualityServices.ViewModels
{
    public class BeautyHairListItemViewModel : ListItemBaseViewModel
    {
        public Guid Id { get; set; }

        public Guid ServiceCategory { get; set; }

        public string CategoryName { get; set; }

        public string ServiceName { get; set; }

        public ActiveStatus StatusId { get; set; }
    }
}