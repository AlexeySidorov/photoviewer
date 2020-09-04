using photoviewer.Domain.models;

namespace photoviewer.Droid.Listeners
{
    public interface IPhotoListener
    {
        void ItemClick(Photo photo);

        void SetLike(Photo photo);
    }
}