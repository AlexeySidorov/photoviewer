using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using FFImageLoading.Cross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using photoviewer.Domain.models;
using photoviewer.Droid.Extensions;
using photoviewer.Droid.Listeners;
using static Android.Widget.ImageView;

namespace photoviewer.Droid.Holders
{
    public class PhotoHolder : MvxRecyclerViewHolder, View.IOnClickListener
    {
        private IPhotoListener _listener;
        private RelativeLayout _likeBlock;
        private MvxCachedImageView _image;

        public PhotoHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PhotoHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            _image = itemView.FindViewById<MvxCachedImageView>(Resource.Id.image);
            _likeBlock = itemView.FindViewById<RelativeLayout>(Resource.Id.like_block);
            var likeCounter = itemView.FindViewById<AppCompatTextView>(Resource.Id.like_counter);

            this.DelayBind(() =>
            {
                _image.ErrorPlaceholderImagePath = "res:no_img.png";
                _image.TransformPlaceholders = true;
                _image.SetScaleType(ScaleType.CenterCrop);

                var set = this.CreateBindingSet<PhotoHolder, Photo>();
                set.Bind(likeCounter).To(x => x.Likes);
                set.Bind(_image).For(v => v.ImagePath).To(vm => vm.Urls.Regular);
                set.Apply();

                var photo = context.DataContext as Photo;
                _likeBlock.SetTag(Resource.Layout.PhotoHolder, photo.ToJavaObject());
                _image.SetTag(Resource.Layout.PhotoHolder, photo.ToJavaObject());
            });

            _likeBlock.SetOnClickListener(this);
            _image.SetOnClickListener(this);
        }

        public void SetItemClickListener(IPhotoListener listener)
        {
            _listener = listener;
        }

        public void OnClick(View v)
        {
            var obj = v.GetTag(Resource.Layout.PhotoHolder);
            if (obj == null) return;

            var photo = (obj as JavaHolder)?.Instance as Photo;
            if (photo == null) return;

            switch (v.Id)
            {
                case Resource.Id.like_block:
                    if (_listener != null)
                        _listener.SetLike(photo);

                    break;
                case Resource.Id.image:
                    if (_listener != null)
                        _listener.ItemClick(photo);

                    break;
            }
        }
    }
}
