using System.Collections.Generic;
using System.Threading.Tasks;
using photoviewer.Domain.models;
using photoviewer.Domain.Responses;
using Refit;

namespace photoviewer.Services.Rest
{
    public interface IRestMetodsRequest
    {
        //Get photos
        [Get("/photos?page={page}&per_page={count}&order_by={sort}")]
        Task<IList<Photo>> GetPhotos([AliasAs("page")] int page,
            [AliasAs("count")] int count, [AliasAs("sort")] SortModel sortType);
        //Post llike
        [Post("/photos/{id}/like")]
        Task<PhotoResponse> SetLike([AliasAs("id")] int imageId);

        //Delete unlike
        [Post("/photos/{id}/like")]
        Task<PhotoResponse> UnLike([AliasAs("id")] int imageId);
    }
}
