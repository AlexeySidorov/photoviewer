using MvvmCross;
using photoviewer.Domain.Dao;
using photoviewer.Services;
using System;
using System.Threading.Tasks;

namespace photoviewer.Syncronizer
{
    public class Syncronizer
    {
        private static readonly Lazy<Syncronizer> Instance = new Lazy<Syncronizer>(() => new Syncronizer());
        public static Syncronizer Current => Instance.Value;

        private static int _delayHour = 1;

        private static int _maxCountRequest = 50;

        public async Task<bool> IsAvailableRequest()
        {
            var syncService = Mvx.IoCProvider.Resolve<ISyncService>();
            var data = await syncService.GetSyncData();
            if (data == null)
            {
                var syncData = new SyncDao();
                syncData.Id = Guid.NewGuid().ToString();
                syncData.FirstSync = DateTime.Now;
                syncData.Count = 1;

                await syncService.AddOrUpdateSyncData(syncData);

                return true;
            }
            else
            {
                if (data.Count == _maxCountRequest && DateTime.Now.CompareTo(data.FirstSync.AddHours(_delayHour)) <= 0)
                    return false;
                else if (data.Count <= _maxCountRequest && DateTime.Now.CompareTo(data.FirstSync.AddHours(_delayHour)) > 0)
                {
                    data.Count = 1;
                    data.FirstSync = DateTime.Now;
                    await syncService.AddOrUpdateSyncData(data);

                    return true;
                }
                else
                {
                    data.Count++;
                    await syncService.AddOrUpdateSyncData(data);

                    return true;
                }
            }
        }
    }
}
