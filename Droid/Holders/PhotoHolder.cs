using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using photoviewer.Domain.models;

namespace photoviewer.Droid.Holders
{
    public class PhotoHolder : MvxRecyclerViewHolder, View.IOnClickListener
    {
        public PhotoHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PhotoHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            var image = itemView.FindViewById<AppCompatImageView>(Resource.Id.image);
            var likeBlock = itemView.FindViewById<RelativeLayout>(Resource.Id.like_block);
            var likeCounter = itemView.FindViewById<AppCompatTextView>(Resource.Id.like_counter);

            itemView.SetOnClickListener(this);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PhotoHolder, Photo>();
                // set.Bind(image).To(x => x.Name);
                set.Bind(likeCounter).To(x => x.Likes);
                set.Apply();
            });
        }

        public void OnClick(View v)
        {
            throw new System.NotImplementedException();
        }
    }
}
