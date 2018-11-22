using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iOSSpecialFeatures.Views;
using iOSSpecialFeatures.Repositories;
using iOSSpecialFeatures.Shared.Realms;

namespace iOSSpecialFeatures.ViewModels
{


    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private ContactRepository _realmRepo;

        public ItemsViewModel()
        {
            //_realmRepo = new ContactRepository();

            //Title = "Browse";
            //Items = new ObservableCollection<Contact>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Contact>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Contact;
            //    //await contactRepository.AddContact(newItem);
            //    Items.Add(newItem);
            //    //await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            //if (IsBusy)
            //    return;

            //IsBusy = true;

            //try
            //{

            //    //repo.CreateContact();
            //    var contacts = await _realmRepo.GetActiveContacts();

            //    Items.Clear();
            //    //var items = await DataStore.GetItemsAsync(true);
            //    foreach (var item in contacts)
            //    {
            //        Items.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }
    }
}