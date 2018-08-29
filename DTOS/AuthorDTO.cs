using System.Collections.Generic;

namespace CaribeMediaApi.DTOS
{
    public class AuthorDTO
    {
        public string name { get; set; }
        public BookDTO TopBook { get; set; }
    }
}