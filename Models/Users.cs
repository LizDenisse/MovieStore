using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieStore.Controllers;

namespace MovieStore.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }

       
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
