using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iOSSpecialFeatures.Services;
using iOSSpecialFeatures.Views;
using iOSSpecialFeatures.Repositories;
using FreshMvvm;
using iOSSpecialFeatures.PageModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace iOSSpecialFeatures
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //public static string BackendUrl = "http://localhost:5000";
        //public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<ContactRepository>();
            FreshIOC.Container.Register<IContactRepository, ContactRepository>();
            var page = FreshPageModelResolver.ResolvePageModel<ContactsPageModel>();
            MainPage = new FreshNavigationContainer(page);


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
