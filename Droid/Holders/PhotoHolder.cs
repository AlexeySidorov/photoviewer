using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using FFImageLoading.Cross;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using photoviewer.Domain.models;
using static Android.Widget.ImageView;

namespace photoviewer.Droid.Holders
{
    public class PhotoHolder : MvxRecyclerViewHolder, View.IOnClickListener
    {
        public PhotoHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PhotoHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            var image = itemView.FindViewById<MvxCachedImageView>(Resource.Id.image);
            var likeBlock = itemView.FindViewById<RelativeLayout>(Resource.Id.like_block);
            var likeCounter = itemView.FindViewById<AppCompatTextView>(Resource.Id.like_counter);

            itemView.SetOnClickListener(this);

            this.DelayBind(() =>
            {
                image.ErrorPlaceholderImagePath = "res:no_img.png";
                image.TransformPlaceholders = true;
                image.SetScaleType(ScaleType.CenterCrop);

                var set = this.CreateBindingSet<PhotoHolder, Photo>();
                set.Bind(likeCounter).To(x => x.Likes);
                set.Bind(image).For(v => v.ImagePath).To(vm => vm.Urls.Regular);
                set.Apply();
            });
        }

        public void OnClick(View v)
        {
            throw new System.NotImplementedException();
        }
    }
}
