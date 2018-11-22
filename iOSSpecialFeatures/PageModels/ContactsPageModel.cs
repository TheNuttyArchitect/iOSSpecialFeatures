using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using iOSSpecialFeatures.Repositories;
using iOSSpecialFeatures.Shared.Realms;
using Xamarin.Forms;

namespace iOSSpecialFeatures.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ContactsPageModel : FreshBasePageModel
    {
        private readonly ContactRepository _contactRepository;
        private Contact _selectedItem { get; set; }

        public ContactsPageModel(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ObservableCollection<Contact> Items { get; set; }

        public override void Init(object initData)
        {
            var contacts = _contactRepository.GetActiveContacts();

            Items = new ObservableCollection<Contact>(contacts);
        }

        public override void ReverseInit(object returnedData)
        {
            var newItem = returnedData as Contact;
            if(!Items.Contains(newItem))
            {
                Items.Add(newItem);
            }
        }

        public Contact SelectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                // TODO: Wire in ItemSelected Command
            }
        }

        public Command AddItem
        {
            get => new Command(() => CoreMethods.DisplayAlert("Test", "Hello World", "Close"));
        } 
    }
}
