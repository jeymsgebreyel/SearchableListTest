using SearchableListTest.Products;
using SearchableListTest.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SearchableListTest.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableListView : ListView
    {
        #region Field

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        public static readonly BindableProperty SearchTextProperty =
            BindableProperty.Create(nameof(SearchText), typeof(string), typeof(SearchableListView), null, BindingMode.Default, null, OnSearchTextChanged);





        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        private string searchText;

        

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        public string SearchText
        {
            get { return (string)this.GetValue(SearchTextProperty); }
            set { this.SetValue(SearchTextProperty, value); }
        }

        

        #endregion

        #region Method

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public virtual bool FilterItems(object obj)
        {
            if (this.SearchText == null)
            {
                return false;
            }

            return true;
        }

        public virtual List<T> SearchQuery<T>(List<T> all)
        {
            return all;
        }

        /// <summary>
        /// Invoked when the search text is changed.
        /// </summary>
        /// <param name="bindable">The SfListView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        public static void OnSearchTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var listView = bindable as SearchableListView;
            if (newValue != null && listView.ItemsSource != null)
            {
                listView.searchText = (string)newValue;
                var all = (listView.BindingContext as MainPageViewModel).Products;
                if (string.IsNullOrEmpty(listView.searchText))
                {
                    listView.ItemsSource = all;
                }
                else
                {
                    var filteredData = all.Where(x => x.Name.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant()) || x.SKU.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant()) || x.Barcode.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant())).ToList();
                    listView.ItemsSource = filteredData;
                }
                

            }

            //listView.BeginRefresh();//listView.RefreshView();
        }

        ///// <summary>
        ///// Invoked when the search text is changed.
        ///// </summary>
        ///// <param name="bindable">The SfListView</param>
        ///// <param name="oldValue">The old value</param>
        ///// <param name="newValue">The new value</param>
        //private static void OnSearchTextChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var listView = bindable as SearchableListView;
        //    if (newValue != null && listView.ItemsSource != null)
        //    {
        //        listView.searchText = (string)newValue;
        //        var all = (listView.BindingContext as MainPageViewModel).Products;
        //        if (string.IsNullOrEmpty(listView.searchText))
        //        {
        //            listView.ItemsSource = all;
        //        }
        //        else
        //        {
        //            var filteredData = all.Where(x => x.Name.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant()) || x.SKU.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant()) || x.Barcode.ToUpperInvariant().Contains(listView.searchText.ToUpperInvariant())).ToList();
        //            listView.ItemsSource = filteredData;
        //        }
        //        //listView.ItemsSource.Filter = listView.FilterContacts;
        //        //Query 
        //        //listView.ItemsSource.RefreshFilter();

        //    }

        //    //listView.BeginRefresh();//listView.RefreshView();
        //}






        #endregion
    }
}
