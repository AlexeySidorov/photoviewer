using MvvmCross;
using photoviewer.core.Collections;
using photoviewer.Domain.models;
using photoviewer.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace photoviewer.Providers
{
    public class PhotoProvider : ItemsProvider<Photo>
    {
        private IRestApiService _restService;
        private IPhotoService _photoService;
        private SortModel _sort;
        public event EventHandler LoadingStart;
        public event EventHandler LoadingStop;
        public event EventHandler NotLoad;
        public event EventHandler<string> Error;

        public PhotoProvider(SortModel sort)
        {
            _restService = Mvx.IoCProvider.Resolve<IRestApiService>();
            _photoService = Mvx.IoCProvider.Resolve<IPhotoService>();
        }

        public async Task<int> FetchCount()
        {
            var isAvailableRequest = await Syncronizer.Syncronizer.Current.IsAvailableRequest();
            if (!isAvailableRequest) return await _photoService.GetPhotoCount();

            var countPhotoModel = await _restService.Request().GetCountPhoto();
            if (countPhotoModel == null) return 0;

            return countPhotoModel.Photos;
        }

        private int _page { get; set; } = 0;
        public async Task<IList<Photo>> FetchRange(int startIndex, int count)
        {
            var isAvailableRequest = await Syncronizer.Syncronizer.Current.IsAvailableRequest();
            if (!isAvailableRequest) 
                return await _photoService.GetPhotos(startIndex, count);

            if (_page != startIndex)
                _page++;

            var result = await _restService.Request().GetPhotos(_page, count, _sort);
            if(result == null || result.Count == 0) return new List<Photo>();

            await _photoService.AddPhotos(result);

            return result;
        }
    }
}