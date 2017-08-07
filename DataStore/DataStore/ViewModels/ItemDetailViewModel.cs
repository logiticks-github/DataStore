using DataStore.Models;
using Mobility.Infrastructure.ViewModels;

namespace DataStore.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        #region Constructor
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }
        #endregion

        #region Properties

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public Item Item { get; set; }

        #endregion

    }
}