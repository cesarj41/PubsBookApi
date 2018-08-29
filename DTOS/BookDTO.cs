using System;
using System.Collections.Generic;

namespace CaribeMediaApi.DTOS
{
    public class BookDTO
    {
        public string author { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public DateTime publishedOn { get; set; }
    }
}