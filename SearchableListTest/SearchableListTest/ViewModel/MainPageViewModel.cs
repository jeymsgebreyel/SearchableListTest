using SearchableListTest.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SearchableListTest.ViewModel
{
    public class MainPageViewModel :BaseViewModel
    {
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _staticList;

        public ObservableCollection<Product> Products { get => _products;set => _products = value; }
        public ObservableCollection<Product> StaticList { get => _products; set => _staticList = value; }

        public MainPageViewModel()
        {
            Products = new ObservableCollection<Product>();
            GenerateMockData();
        }

        /// <summary>
        /// To remove. Generate Mock data
        /// </summary>
        void GenerateMockData()
        {

            StaticList = new ObservableCollection<Product>();
            if (Products.Count == 0)
            {
                
                Random rand = new Random(10);
                for (int i = 0; i < 10; i++)
                {
                    Product prod = new Product
                    {
                        Name = $"Item {i + 1}",
                        IncomingQuantity = rand.Next(50),
                        SKU = RandomString(10),
                        InventoryQuantity = rand.Next(10, 100),
                        ProductType = (ProductType)(rand.Next(3)),
                        Barcode = RandomString(10)
                    };
                    Products.Add(prod);
                    
                };
            }
            StaticList = new ObservableCollection<Product>(Products);
        }

        /// <summary>
        /// Randomize string for Mock data
        /// </summary>
        /// <param name="length">String length</param>
        /// <returns>string</returns>
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
