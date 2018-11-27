using System;
using FreshMvvm;
using iOSSpecialFeatures.Repositories;
using iOSSpecialFeatures.Shared.Realms;
using Xamarin.Forms;

namespace iOSSpecialFeatures.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ContactPageModel : FreshBasePageModel
    {
        private readonly IContactRepository contactRepository;
        private bool isNew = false;

        public Contact Item { get; set; }


        public ContactPageModel(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;

        }

        public override void Init(object initData)
        {
            if(initData != null)
            {
                Item = (Contact)initData;
            }
            else
            {
                Item = new Contact();
                isNew = true;
            }
        }

        public Command SaveCommand => new Command
        (
            () => 
            {
                if(isNew)
                {
                    Item.Audit.CreatedBy = "Ben";
                    contactRepository.AddContact(Item);
                }
                else
                {
                    Item.Audit.LastModifiedBy = "Ben";
                    Item.Audit.LastModifiedDate = DateTime.Now;
                    contactRepository.UpdateContact(Item);
                }
                CoreMethods.PopPageModel(Item);
            }
        );

        public Command CancelCommand => new Command(() => CoreMethods.PopPageModel());
    }
}
