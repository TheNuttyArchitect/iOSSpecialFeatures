using System;
using iOSSpecialFeatures.Shared.Realms;

namespace iOSSpecialFeatures.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Contact Item { get; set; }
        public ItemDetailViewModel(Contact item = null)
        {
            Title = (item?.NickName ?? item.FirstName) + " " + item.LastName;
            Item = item;
        }
    }
}
