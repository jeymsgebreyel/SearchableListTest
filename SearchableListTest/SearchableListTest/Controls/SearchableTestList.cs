using SearchableListTest.Products;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SearchableListTest.Controls
{
    [Preserve(AllMembers = true)]
    public class SearchableTestList :SearchableListView
    {
        #region Method

        public SearchableTestList()
        {
            AllList = new System.Collections.ObjectModel.ObservableCollection<Product>();
        }

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool FilterItems(object obj)
        {
            if (base.FilterItems(obj))
            {
                var taskInfo = obj as Product;

                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.Name) || string.IsNullOrEmpty(taskInfo.Barcode) || string.IsNullOrEmpty(taskInfo.SKU))
                {
                    return false;
                }

                return taskInfo.Name.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())|| taskInfo.Barcode.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant()) || taskInfo.SKU.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }

            return false;
        }
        

        
        #endregion
    }
}
