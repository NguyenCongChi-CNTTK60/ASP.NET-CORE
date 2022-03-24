using Start_ASP_Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Start_ASP_Core.Data
{   

    // Building a data Access Service
    public interface IRestaurantsData
    {

        // Vậy IEnumerable giúp một đối tượng có thể thực hiện duyệt các phần tử bằng foreach. CuisinType

        // IEnumerable <Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantByName(string Name);

        // Fetching Restaurants by ID
        Restaurant GetbyID(int id);


        // Model Binding an HTTP POST Operation
        Restaurant Update(Restaurant updateRestaurant);
        int Commit();  
    }


    public class InMemoryRestaurantData : IRestaurantsData
    {
         private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant  { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant  { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant  { Id = 3, Name = "La Costa", Location = "Califonia", Cuisine = CuisineType.Mexian }
            };
        }

        public int Commit()
        {
            // throw new NotImplementedException();
            return 0;
        }


        // implement interface

        /*  SingleOrDefault
        Giải thích: Tìm trong danh sách L một phần tử đơn duy nhất thỏa điều kiện C:

        Nếu không tìm thấy: (4)
        Trả về giá trị mặc định của kiểu dữ liệu phần tử cần tìm(xem phụ lục ở cuối bài)
        Done.
        Nếu tìm thấy:
        Tìm thấy duy nhất một phần tử: (5)
        Trả về phần tử đó
        Done
        Tìm thấy nhiều hơn một phần tử: (6)
        Throw exception –> Sequence contains more than one matching element 
        Done */

        public Restaurant GetbyID(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }


        // Binding to Query String 
        public IEnumerable <Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            //  throw new NotImplementedException();
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }



        /* public IEnumerable<Restaurant> GetAll()
         {
             return from r in restaurants
                    orderby r.Name
                    select r;
         } */



    }



}
