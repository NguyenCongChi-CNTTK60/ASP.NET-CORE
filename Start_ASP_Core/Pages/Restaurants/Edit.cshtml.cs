using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Start_ASP_Core.Core;
using Start_ASP_Core.Data;

namespace Start_ASP_Core.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        [BindProperty]    
        public Restaurant Restaurant { get; set; }     // chua cac thuoc tinh name, id ...

        // Fetching restaurants by ID 

        private readonly IRestaurantsData restaurantsData;   // 


        // Building an Edit Form with Tag Helpers 
        private readonly IHtmlHelper htmlHelper;

       // public Restaurant Restaurant { get; set; }

        public IEnumerable <SelectListItem> Cuisines { get; set; }


       public EditModel (IRestaurantsData restaurantsData,
                         IHtmlHelper htmlHelper)
        {
            this.restaurantsData = restaurantsData;
            this.htmlHelper = htmlHelper;
        }


        // Linking to details 
        public IActionResult OnGet(int restaurantsID)
        {
            //  Restaurant = new Restaurant();
            //  Restaurant.Id = restaurantsID;

            // Building an Edit Form with Tag Helpers
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurantsData.GetbyID(restaurantsID);


            // Handing bad requests
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");   // chuyen den trang notfound 
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                Restaurant = restaurantsData.Update(Restaurant);
                restaurantsData.Commit();
                return RedirectToPage("./Details", new { restaurantsID = Restaurant.Id });
            }

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();  // load again data in selection
            return Page();
           // return 0;
            
        }
    }
}