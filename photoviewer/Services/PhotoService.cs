
using MvvmCross.Binding.Extensions;
using photoviewer.Convertors;
using photoviewer.core.Data;
using photoviewer.core.DataBaseService;
using photoviewer.Domain.Dao;
using photoviewer.Domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace photoviewer.Services
{
    public interface IPhotoService : ICrudServiceAsync<PhotoDao>
    {
        Task AddPhotos(IList<Photo> photos);

        Task<IList<Photo>> GetPhotos(int skip, int count);

        Task UpdatePhotoData(Photo data);

        Task<Photo> GetPhoto(string id);

        Task<int> GetPhotoCount();
    }

    public class PhotoService : AsyncBaseDataService<PhotoDao>, IPhotoService
    {
        private readonly IAsyncRepository<PhotoDao> _repository;
        private readonly IAsyncRepository<UserDao> _userRepository;
        private readonly IAsyncRepository<UserImageUrlDao> _userImageUrlRepository;
        private readonly IAsyncRepository<PhotoUrlDao> _photoUrlRepository;

        public PhotoService(IAsyncRepository<PhotoDao> repository, IAsyncRepository<UserDao> userRepository,
            IAsyncRepository<UserImageUrlDao> userImageUrlRepository, IAsyncRepository<PhotoUrlDao> photoUrlRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _userImageUrlRepository = userImageUrlRepository;
            _photoUrlRepository = photoUrlRepository;
        }

        public async Task AddPhotos(IList<Photo> photos)
        {
            foreach (var photo in photos)
            {
                var photoData = PhotoReponseConvertor.ConvertPhotoToPhotoDao(photo);
                var userData = PhotoReponseConvertor.ConvertUserToUserDao(photo);
                var profileData = PhotoReponseConvertor.ConvertUserPhotoToUserImageUrlDao(photo);
                var photoUrlsData = PhotoReponseConvertor.ConvertPhotoToPhotoUrlDao(photo);

                await _repository.CreateOrUpdateAsync(photoData);

                if (userData != null)
                    await _userRepository.CreateOrUpdateAsync(userData);

                if (profileData != null)
                    await _userImageUrlRepository.CreateOrUpdateAsync(profileData);

                await _photoUrlRepository.CreateOrUpdateAsync(photoUrlsData);
            }
        }

        public async Task<Photo> GetPhoto(string id)
        {
            var photo = await _repository.GetAsync(id);
            if (photo == null) return null;

            UserDao user = null;
            UserImageUrlDao profileImgs = null;

            if (!string.IsNullOrEmpty(photo.UserId))
            {
                user = await _userRepository.GetAsync(photo.UserId);
                profileImgs = await _userImageUrlRepository.GetAsync(photo.UserId);
            }

            var photoUrls = await _photoUrlRepository.GetAsync(photo.Id);

            return PhotoReponseConvertor.ConvertDataToPhoto(photo, user, profileImgs, photoUrls);
        }

        public async Task<int> GetPhotoCount()
        {
            var photos = await _repository.FetchAsync();
            return photos.Count();
        }

        public async Task<IList<Photo>> GetPhotos(int skip, int count)
        {
            var photos = await _repository.FetchAsync(skip, count);
            if (photos == null || photos.Count == 0) return new List<Photo>();

            var photosList = new List<Photo>();

            foreach (var photo in photos)
            {
                UserDao user = null;
                UserImageUrlDao profileImgs = null;

                if (!string.IsNullOrEmpty(photo.UserId))
                {
                    user = await _userRepository.GetAsync(photo.UserId);
                    profileImgs = await _userImageUrlRepository.GetAsync(photo.UserId);
                }

                var photoUrls = await _photoUrlRepository.GetAsync(photo.Id);
                photosList.Add(PhotoReponseConvertor.ConvertDataToPhoto(photo, user, profileImgs, photoUrls));
            }

            return photosList;
        }

        public async Task UpdatePhotoData(Photo photo)
        {
            var photoData = PhotoReponseConvertor.ConvertPhotoToPhotoDao(photo);
            var userData = PhotoReponseConvertor.ConvertUserToUserDao(photo);
            var profileData = PhotoReponseConvertor.ConvertUserPhotoToUserImageUrlDao(photo);
            var photoUrlsData = PhotoReponseConvertor.ConvertPhotoToPhotoUrlDao(photo);

            await _repository.CreateOrUpdateAsync(photoData);

            if (userData != null)
                await _userRepository.CreateOrUpdateAsync(userData);

            if (profileData != null)
                await _userImageUrlRepository.CreateOrUpdateAsync(profileData);

            await _photoUrlRepository.CreateOrUpdateAsync(photoUrlsData);
        }
    }
}
