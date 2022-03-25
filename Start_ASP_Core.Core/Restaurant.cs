using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Start_ASP_Core.Core
{
    
   
   public class Restaurant 
    {  
        
        public int Id { get; set; }

        // adding validaton checks 

        [Required, StringLength(60)]  // Kiểm tra khoảng trắng hoặc các lỗi thường gặp sử dụng Model State
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

      //  [Required, StringLength(60)]
        public CuisineType Cuisine { get; set; }
             
    }
}
