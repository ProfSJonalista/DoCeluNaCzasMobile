using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DoCeluNaCzasMobile.Models.Delay;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Database
{
    public interface IDatabaseRepository
    {
        void InsertToDb<T>(T objectToInsert);
        void Delete<T>(T objectToDelete);
        void SaveStopModel(ChooseBusStopModel stopModel);
        ObservableCollection<ChooseBusStopModel> GetUserBusStopObservableCollection();
    }
}
