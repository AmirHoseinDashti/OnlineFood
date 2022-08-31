using System;
using System.Text.RegularExpressions;

namespace Online_food.Models
{
    public class pagingInfo
    {
        public int TotalItems { get; set; }

        public int ItemPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemPage);

        public string UrlParam { get; set; }
    }
}
