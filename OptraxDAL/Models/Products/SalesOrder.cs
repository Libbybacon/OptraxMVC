﻿namespace OptraxDAL.Models.Products
{
    public class SalesOrder
    {

        public SalesOrder() { }

        public int ID { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual ICollection<ProductItem> Items { get; set; } = [];
    }
}
