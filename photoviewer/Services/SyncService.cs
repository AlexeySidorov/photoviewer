using MvvmCross.Binding.Extensions;
using photoviewer.core.Data;
using photoviewer.core.DataBaseService;
using photoviewer.Domain.Dao;
using System.Linq;
using System.Threading.Tasks;

namespace photoviewer.Services
{

    public interface ISyncService : ICrudServiceAsync<SyncDao>
    {
        Task AddOrUpdateSyncData(SyncDao data);
        Task<SyncDao> GetSyncData();
    }

    public class SyncService : AsyncBaseDataService<SyncDao>, ISyncService
    {
        private readonly IAsyncRepository<SyncDao> _repository;

        public SyncService(IAsyncRepository<SyncDao> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task AddOrUpdateSyncData(SyncDao data)
        {
            var listData = await _repository.FetchAsync();
            if (listData == null || listData.Count() == 0)
                await _repository.CreateAsync(data);
            else
                await _repository.UpdateAsync(data);
        }

        public async Task<SyncDao> GetSyncData()
        {
            var listData = await _repository.FetchAsync();
            if (listData == null || listData.Count() == 0) return null;

            return listData.ToList()[0];
        }
    }
}
