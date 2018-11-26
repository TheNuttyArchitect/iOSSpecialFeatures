using System;
using FreshMvvm;
using iOSSpecialFeatures.PageModels;
using Xamarin.Forms;

namespace iOSSpecialFeatures
{
    public class LaunchPage : ContentPage
    {
        public LaunchPage(App app)
        {
            var page = FreshPageModelResolver.ResolvePageModel<ContactsPageModel>();
            app.MainPage = new FreshNavigationContainer(page);
        }
    }
}

