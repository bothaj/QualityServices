using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualityServices.ViewModels
{
    public class BeautyHairDetailsViewModel : BaseViewModel
    {
        public Guid Id {get; set;}

        public Guid ServiceCategory { get; set; }

		[DisplayName("Description")]
		[StringLength(255, ErrorMessage = "Service Name must be less then 200 characters")]
        [Required(ErrorMessage = "Required: Service Name")]
        public string ServiceName { get; set; }



        public BeautyHairDetailsViewModel()
        {
            this.ViewModelName = "BeautyHairDetails";
        }
    }
}