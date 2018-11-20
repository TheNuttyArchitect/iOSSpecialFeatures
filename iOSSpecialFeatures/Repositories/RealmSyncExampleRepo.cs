using System;
using System.Threading.Tasks;
using Realms.Sync;

namespace iOSSpecialFeatures.Repositories
{
    public class RealmSyncExampleRepo
    {
        private const string ServerURL = "https://devtownbenplayground.us1a.cloud.realm.io";
        public RealmSyncExampleRepo()
        {

            //var user = 
            //var syncConfigruation = new SyncConfiguration()
        }

        public async Task Initialize()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("bchesnut@developertown.com", "welcome@1", false), new Uri(ServerURL));
            var syncConfig = new FullSyncConfiguration(new Uri(ServerURL), user, "/iosplayground") { SchemaVersion = 1 };


        }
    }
}
