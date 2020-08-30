using Android.App;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android;
using photoviewer.core.Services;

namespace photoviewer.Droid.Infrastructure.Services
{
    public class ProgressDialogService : IProgressDialogService
    {
#pragma warning disable 618
        private ProgressDialog _dialog;
#pragma warning restore 618
        private readonly object _locker = new object();
        private bool _isBusy;
#pragma warning disable 169
        private ProgressBar _progressBar;
#pragma warning restore 169

        /// <summary>
        /// �������� ������ � �������� ����� 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [System.Obsolete]
        public void ShowDialog(string message)
        {
            if (_isBusy) return;

            lock (_locker)
            {
                if (_isBusy) return;

                var mvxTopActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
                _isBusy = true;
                mvxTopActivity.Activity.RunOnUiThread(() =>
                {
                    if (!_isBusy) return;
                    lock (_locker)
                    {
                        if (!_isBusy) return;
                        _dialog = new ProgressDialog(mvxTopActivity.Activity);
                        _dialog.SetMessage(message);
                        _dialog.SetCancelable(false);
                        _dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                        _dialog.Show();
                    }
                });
            }
        }

        public void ChangeTitle(string message)
        {
            _dialog.SetMessage(message);
        }

        /// <summary>
        /// ������� ������ � �������� ����� 
        /// </summary>
        /// <returns></returns>
        public void CloseDialog()
        {
            if (!_isBusy) return;

            lock (_locker)
            {
                if (!_isBusy) return;
                _isBusy = false;

                if (_dialog == null) return;

                var dialog = _dialog;
                _dialog = null;

                Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity.RunOnUiThread(() => { dialog.Dismiss(); });
            }
        }
    }
}