using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Start_ASP_Core.Core;
using Start_ASP_Core.Data;

namespace Start_ASP_Core.Pages.Restaurants
{
    public class ListModel : PageModel
    {   
        public string Message { get; set; }

        // Injecting and using configuration 

        private readonly IConfiguration config;

        private readonly IRestaurantsData restaurantData;
         
        // Building a Page Model
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel (IConfiguration config, IRestaurantsData restaurantsData)
        {
            this.config = config;
            this.restaurantData = restaurantsData;
        }


        public void OnGet(string searchTearm)
        {
            // Message = "Hello world!";
            Message = config["Message"];
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantByName(searchTearm);

        }
    }
}
