using System;
using System.Collections.Generic;

#nullable disable

namespace cloudApi.Models.DB
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
