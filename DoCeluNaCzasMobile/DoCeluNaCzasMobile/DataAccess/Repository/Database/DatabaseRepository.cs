using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.General;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Database
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public void Delete(ChooseBusStopModel objectToDelete)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.Delete(objectToDelete);
            }
        }

        public void SaveStopModel(ChooseBusStopModel stopModel)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.CreateTable<StopModel>();

                var oldStopModel = db.Table<ChooseBusStopModel>().SingleOrDefault(stop => stop.StopId == stopModel.StopId);

                if (oldStopModel != null && oldStopModel.StopId >= 0) return;

                db.CreateTable<ChooseBusStopModel>();
                db.Insert(stopModel);
            }
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStopObservableCollection()
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.CreateTable<ChooseBusStopModel>();
                var modelsToReturn = db.Table<ChooseBusStopModel>().ToList();

                return new ObservableCollection<ChooseBusStopModel>(modelsToReturn);
            }
        }
    }
}
