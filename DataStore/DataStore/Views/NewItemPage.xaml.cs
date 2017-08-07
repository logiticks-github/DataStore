using System;

using DataStore.Models;

using Xamarin.Forms;
using DataStore.ViewModels;

namespace DataStore.UI.Views
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemViewModel ItemViewModel { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            ItemViewModel = new NewItemViewModel(Navigation);

            BindingContext = ItemViewModel;
        }
    }
}