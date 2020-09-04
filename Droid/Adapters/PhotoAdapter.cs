using Android.Views;
using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using photoviewer.Droid.Holders;
using photoviewer.Droid.Listeners;

namespace photoviewer.Droid.Adapters
{
    public class PhotoAdapter : MvxRecyclerAdapter
    {
        private IPhotoListener _listener;

        public PhotoAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }

        public override MvxRecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoHolder, parent, false);
            var holder = new PhotoHolder(itemView, itemBindingContext);
            holder.SetItemClickListener(_listener);

            return holder;
        }

        public void SetItemClickListener(IPhotoListener listener)
        {
            _listener = listener;
        }

        public override int GetItemViewType(int position)
        {
            return 0;
        }
    }
}
