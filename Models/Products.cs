using System;
using System.Collections.Generic;
using MovieStore.Controllers;

namespace MovieStore.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }
        //public static implicit operator List<object>(Products v)
        //{
        //    throw new NotImplementedException();
        //}
    }

  
}
