using System;
using System.Collections.Generic;
//using QualityServices.ViewModels.BeautyHair;

namespace QualityServices.ViewModels
{
    public class ManageBeautyHairViewModel : BaseViewModel
    {
        #region Properties

        public List<BeautyHairListItemViewModel> NonpagedList { get; set; }

        public BeautyHairListViewModel ListViewModel { get; set; }

        public BeautyHairDetailsViewModel DetailsViewModel { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManageBeautyHairViewModel()
        {
            ListViewModel = new BeautyHairListViewModel();
            DetailsViewModel = new BeautyHairDetailsViewModel();
        }

        #endregion
    }
}

