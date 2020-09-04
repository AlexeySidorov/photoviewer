
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using photoviewer.Domain.models;
using System.Collections.Generic;

namespace photoviewer.ViewModels
{
    public class PhotoDetailsViewModel : BaseViewModel<Photo>
    {
        private string _likeCount;
        private string _userName;
        private string _description;
        private string _avatarUrl;
        private string _imageUrl;
        private string _userDescription;

        #region Binding

        public string LikeCount
        {
            get => _likeCount;
            set
            {
                _likeCount = value;
                RaisePropertyChanged(() => LikeCount);
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string UserDescription
        {
            get => _userDescription;
            set
            {
                _userDescription = value;
                RaisePropertyChanged(() => UserDescription);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public string AvatarUrl
        {
            get => _avatarUrl;
            set
            {
                _avatarUrl = value;
                RaisePropertyChanged(() => AvatarUrl);
            }
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                RaisePropertyChanged(() => ImageUrl);
            }
        }

        public List<ITransformation> Transformations => new List<ITransformation> { new CircleTransformation() };

        #endregion

        public override void Prepare(Photo parameter)
        {
            base.Prepare(parameter);

            if (parameter == null) return;

            ImageUrl = parameter.Urls == null ? "" : parameter.Urls.Regular;
            AvatarUrl = parameter.User == null || parameter.User.ProfileImages == null ? "" : parameter.User.ProfileImages.Small;
            UserName = parameter.User == null ? null : parameter.User.Name;
            UserDescription = parameter.User == null ? null : parameter.User.Bio;
            Description = string.IsNullOrEmpty(parameter.Description) || string.IsNullOrWhiteSpace(parameter.Description) ?
                parameter.AltDescription : parameter.Description;
            LikeCount = parameter.Likes.ToString();
        }
    }
}
