using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iOSSpecialFeatures.Models;
using iOSSpecialFeatures.Views;
using iOSSpecialFeatures.Shared.Repositories;
using iOSSpecialFeatures.Shared.Models;

namespace iOSSpecialFeatures.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private IContactRepository contactRepository;

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Contact>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            contactRepository = DependencyService.Get<IContactRepository>();

            MessagingCenter.Subscribe<NewItemPage, Contact>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Contact;
                await contactRepository.AddContact(newItem);
                Items.Add(newItem);
                //await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var contacts = await contactRepository.GetAllContacts();


                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                foreach (var item in contacts)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}