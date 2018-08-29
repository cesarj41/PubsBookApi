using System;
using System.Collections.Generic;

namespace CaribeMediaApi.Entities
{
    public class Sales
    {
        public string StorId { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public string TitleId { get; set; }

        public Stores Stor { get; set; }
        public Titles Title { get; set; }
    }
}
