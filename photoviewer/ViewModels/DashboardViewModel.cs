using MvvmCross.Commands;
using MvvmCross.Navigation;
using photoviewer.core.Collections;
using photoviewer.core.Services;
using photoviewer.Domain.models;
using photoviewer.Providers;
using photoviewer.Services;
using System;

namespace photoviewer.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly IPhotoService _photoService;
        private readonly IProgressDialogService _progressDialogService;
        private readonly IRestApiService _restApiService;
        private AsyncVirtualizingCollection<Photo> _photos;
        private MvxCommand<Photo> _selectPhotoCommand;
        private MvxCommand<Photo> _likeCommand;

        public DashboardViewModel(IMvxNavigationService navigationService, IConnectionService connectionService, IDialogService dialogService, IPhotoService photoService,
            IProgressDialogService progressDialogService, IRestApiService restApiService)
        {
            _navigationService = navigationService;
            _connectionService = connectionService;
            _dialogService = dialogService;
            _photoService = photoService;
            _progressDialogService = progressDialogService;
            _restApiService = restApiService;
        }

        #region Binding

        public AsyncVirtualizingCollection<Photo> Photos
        {
            get => _photos;
            set
            {
                _photos = value;
                RaisePropertyChanged(() => Photos);
            }
        }

        public MvxCommand<Photo> SelectPhotoCommand
        {
            get
            {
                _selectPhotoCommand = _selectPhotoCommand ?? new MvxCommand<Photo>(SelectPhoto);
                return _selectPhotoCommand;
            }
        }

        public MvxCommand<Photo> LikeCommand
        {
            get
            {
                _likeCommand = _likeCommand ?? new MvxCommand<Photo>(SetLikeAndUnLike);
                return _likeCommand;
            }
        }

        public Action UpdateCollectionAction;

        #endregion

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            Photos = new AsyncVirtualizingCollection<Photo>(new PhotoProvider(SortModel.Default), 10);
        }

        public async void SelectPhoto(Photo photo)
        {
            await _navigationService.Navigate<PhotoDetailsViewModel, Photo>(photo);
        }

        public async void SetLikeAndUnLike(Photo photo)
        {
            if (photo == null || string.IsNullOrEmpty(photo.Id) || string.IsNullOrWhiteSpace(photo.Id)) return;

            Photo tmpPhoto = null;

            if (!photo.LikedByUser)
            {
                var likeResult = await _restApiService.Request().SetLike(photo.Id);
                if (likeResult.Photo != null)
                    tmpPhoto = likeResult.Photo;
            }
            else
            {
                var unLikeResult = await _restApiService.Request().UnLike(photo.Id);
                if (unLikeResult.Photo != null)
                    tmpPhoto = unLikeResult.Photo;
            }

            if (tmpPhoto == null) return;

            photo.LikedByUser = tmpPhoto.LikedByUser;

            await _photoService.UpdatePhotoData(tmpPhoto);

            if (UpdateCollectionAction != null)
                UpdateCollectionAction.Invoke();
        }
    }
}
