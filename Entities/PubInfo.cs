using System;
using System.Collections.Generic;

namespace CaribeMediaApi.Entities
{
    public class PubInfo
    {
        public string PubId { get; set; }
        public byte[] Logo { get; set; }
        public string PrInfo { get; set; }

        public Publishers Pub { get; set; }
    }
}
