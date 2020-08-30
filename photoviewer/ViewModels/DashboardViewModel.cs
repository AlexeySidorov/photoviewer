
using photoviewer.core.Collections;
using photoviewer.core.Services;
using photoviewer.Domain.models;
using photoviewer.Providers;
using photoviewer.Services;

namespace photoviewer.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly IPhotoService _photoService;
        private readonly IProgressDialogService _progressDialogService;
        private readonly IRestApiService _restApiService;
        private AsyncVirtualizingCollection<Photo> _photos;

        public DashboardViewModel(IConnectionService connectionService, IDialogService dialogService, IPhotoService photoService, IProgressDialogService progressDialogService, IRestApiService restApiService)
        {
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

        #endregion

        public override async void ViewAppeared()
        {
            base.ViewAppeared();

            Photos = new AsyncVirtualizingCollection<Photo>(new PhotoProvider(SortModel.Default), 10);
        }
    }
}
