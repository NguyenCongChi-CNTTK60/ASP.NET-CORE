using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Start_ASP_Core.Core;
using Start_ASP_Core.Data;

namespace Start_ASP_Core.Pages.Restaurants
{   
    //
    // 15/03/2022 Details Page 
    //

    // Contructor support new (khoi tao cac bien doi tuong, khi new doi tuong)


    public class DetailsModel : PageModel
    {  
        public Restaurant Restaurant { get; set; }

        // Fetching restaurants by ID 

        private readonly IRestaurantsData restaurantsData;

        public DetailsModel(IRestaurantsData restaurantsData)
        {
            this.restaurantsData = restaurantsData;
        }

        // Linking to details 
        public IActionResult OnGet(int restaurantsID)
        {
            //  Restaurant = new Restaurant();
            //  Restaurant.Id = restaurantsID;
            Restaurant = restaurantsData.GetbyID(restaurantsID);


            // Handing bad requests
            if(Restaurant == null)
            {
               return  RedirectToPage("./NotFound");   // chuyen den trang notfound 
            }

            return Page(); 
        }


    }
}
