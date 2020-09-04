using photoviewer.Domain.Dao;
using photoviewer.Domain.models;

namespace photoviewer.Convertors
{
    public class PhotoReponseConvertor
    {
        public static PhotoDao ConvertPhotoToPhotoDao(Photo photo)
        {
            var photoDao = new PhotoDao();
            photoDao.Id = photo.Id;
            photoDao.CreateDate = photo.Create;
            photoDao.UpdateDate = photo.Update;
            photoDao.LikedByUser = photo.LikedByUser;
            photoDao.Likes = photo.Likes;
            photoDao.Description = photo.Description;
            photoDao.AltDescription = photo.AltDescription;
            photoDao.UserId = photo.User?.Id;

            return photoDao;
        }

        public static UserDao ConvertUserToUserDao(Photo photo)
        {
            if (photo.User == null) return null;

            var userDao = new UserDao();
            userDao.Id = photo.User.Id;
            userDao.Name = photo.User.Name;
            userDao.Bio = photo.User.Bio;

            return userDao;
        }

        public static UserImageUrlDao ConvertUserPhotoToUserImageUrlDao(Photo photo)
        {
            if (photo.User == null) return null;

            var userDao = new UserImageUrlDao();
            userDao.Id = photo.User.Id;

            if (photo.User.ProfileImages != null)
            {
                userDao.Large = photo.User.ProfileImages.Large;
                userDao.Medium = photo.User.ProfileImages.Medium;
                userDao.Small = photo.User.ProfileImages.Small;
            }

            return userDao;
        }

        public static PhotoUrlDao ConvertPhotoToPhotoUrlDao(Photo photo)
        {
            var photoUrlDao = new PhotoUrlDao();
            photoUrlDao.Id = photo.Id;

            if (photo.Urls != null)
            {
                photoUrlDao.Raw = photo.Urls.Raw;
                photoUrlDao.Regular = photo.Urls.Regular;
                photoUrlDao.Small = photo.Urls.Small;
                photoUrlDao.Thumb = photo.Urls.Thumb;
            }

            return photoUrlDao;
        }

        public static Photo ConvertDataToPhoto(PhotoDao photo, UserDao user, UserImageUrlDao imgUrls, PhotoUrlDao urls)
        {
            var photoData = new Photo();

            photoData.Id = photo.Id;
            photoData.Create = photo.CreateDate;
            photoData.Update = photo.UpdateDate;
            photoData.LikedByUser = photo.LikedByUser;
            photoData.Likes = photo.Likes;
            photoData.Description = photo.Description;
            photoData.AltDescription = photo.AltDescription;

            if (user != null)
            {
                var userData = new User();
                userData.Id = user.Id;
                userData.Name = user.Name;
                userData.Bio = user.Bio;

                if (imgUrls != null)
                {
                    var profileImgData = new ProfileImageModel();
                    profileImgData.Large = imgUrls.Large;
                    profileImgData.Medium = imgUrls.Medium;
                    profileImgData.Small = imgUrls.Small;

                    userData.ProfileImages = profileImgData;
                }

                photoData.User = userData;
            }

            if (urls != null)
            {
                var photoUrlData = new Url();
                photoUrlData.Raw = urls.Raw;
                photoUrlData.Regular = urls.Regular;
                photoUrlData.Small = urls.Small;
                photoUrlData.Thumb = urls.Thumb;

                photoData.Urls = photoUrlData;
            }

            return photoData;
        }
    }
}
