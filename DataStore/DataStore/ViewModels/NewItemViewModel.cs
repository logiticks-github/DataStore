using DataStore.Models;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataStore.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {

        #region Feilds

        protected ICommand submitCommand;
        private Item model;
        private INavigation navigation;
        #endregion

        #region Constructor
        public NewItemViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            this.model = new Item
            {
                Text = "Item name",
                Description = "This is a nice description"
            };
            this.Text = model.Text;
            this.Description = model.Description;
        }

        #endregion

        #region Properties

        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        #endregion

        #region Function
        public Item GetItem()
        {
            if (model == null)
            {
                model = new Item();
            }
            model.Text = this.Text;
            model.Description = this.Description;
            return model;
        }

        #endregion

        #region Commands
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new Command(async () =>
                    {
                        MessagingCenter.Send(this, "AddItem", model);
                        if (navigation != null)
                        {
                            await navigation.PopToRootAsync();
                        }
                        

                    });
                }
                return submitCommand;

            }
        }

        #endregion

    }
}
