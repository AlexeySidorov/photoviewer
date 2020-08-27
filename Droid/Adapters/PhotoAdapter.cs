using Android.Views;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using photoviewer.Droid.Holders;

namespace photoviewer.Droid.Adapters
{
    public class PhotoAdapter : MvxRecyclerAdapter
    {
        public PhotoAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }

        public override MvxRecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoHolder, parent, false);
            var holder = new PhotoHolder(itemView, itemBindingContext);

            return holder;
        }

        public override int GetItemViewType(int position)
        {
            return 0;
        }
    }
}
