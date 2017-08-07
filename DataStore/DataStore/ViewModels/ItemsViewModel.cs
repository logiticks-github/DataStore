using System;
using System.Diagnostics;
using System.Threading.Tasks;

using DataStore.Models;
using DataStore.Views;

using Xamarin.Forms;
using Infrastructure.ViewModels;
using Infrastructure.Helpers;
using Infrastructure.Services;

namespace DataStore.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        #region Properties
        public ObservableRangeCollection<Item> Items { get; set; }

        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> ItemDataStore => DependencyService.Get<IDataStore<Item>>();

        #endregion

        #region Constructor
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await ItemDataStore.AddItemAsync(newItem);
            });
        }

        #endregion

        #region Commands
        /// <summary>
        /// Command to load the items
        /// </summary>
        public Command LoadItemsCommand { get; set; }

        #endregion

        #region Function
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ItemDataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}