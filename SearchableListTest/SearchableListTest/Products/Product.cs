using System;
using System.Collections.Generic;
using System.Text;

namespace SearchableListTest.Products
{
    public class Product// : BindableBase
    {
        #region PROPERTIES
        public int ID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public double TotalPrice { get; set; }
        public int InventoryQuantity { get; set; }
        public string SKU { get; set; }
        public int IncomingQuantity { get; set; }
        public ProductType ProductType { get; set; }
        #endregion
    }

    public enum ProductType
    {
        Snacks,
        BathroomItem,
        Miscellaneous
    }
}
