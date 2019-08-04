using DoCeluNaCzasMobile.Models.General;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Database
{
    public interface IDatabaseRepository
    {
        void Delete(StopModel objectToDelete);
        void SaveStopModel(StopModel stopModel);
        ObservableCollection<StopModel> GetUserBusStopObservableCollection();
    }
}
