using DoCeluNaCzasMobile.Models.General;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Database
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public void Delete(StopModel objectToDelete)
        {
            using (var db = new SQLiteConnection(App.DATABASE_LOCATION))
            {
                db.Delete(objectToDelete);
            }
        }

        public void SaveStopModel(StopModel stopModel)
        {
            using (var db = new SQLiteConnection(App.DATABASE_LOCATION))
            {
                db.CreateTable<StopModel>();

                var oldStopModel = db.Table<StopModel>().SingleOrDefault(stop => stop.StopId == stopModel.StopId);

                if (oldStopModel != null && oldStopModel.StopId >= 0) return;

                db.CreateTable<StopModel>();
                db.Insert(stopModel);
            }
        }

        public ObservableCollection<StopModel> GetUserBusStopObservableCollection()
        {
            using (var db = new SQLiteConnection(App.DATABASE_LOCATION))
            {
                db.CreateTable<StopModel>();
                var modelsToReturn = db.Table<StopModel>().ToList();

                return new ObservableCollection<StopModel>(modelsToReturn);
            }
        }
    }
}
