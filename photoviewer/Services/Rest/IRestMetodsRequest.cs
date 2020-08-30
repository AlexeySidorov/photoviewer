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
        [Get("/photos?client_id={clineId}&page={page}&per_page={count}&order_by={sort}")]
        Task<IList<Photo>> GetPhotos([AliasAs("page")] int page,
            [AliasAs("count")] int count, [AliasAs("sort")] SortModel sortType, [AliasAs("clineId")] string clinetId = "dy12xlkfAvya5OqE10pqP9_0wp_rWFejplLsQrMHqpo");
        //Post llike
        [Post("/photos/{id}/like")]
        Task<PhotoResponse> SetLike([AliasAs("id")] int imageId, [AliasAs("clineId")] string clinetId = "dy12xlkfAvya5OqE10pqP9_0wp_rWFejplLsQrMHqpo");

        //Delete unlike
        [Post("/photos/{id}/like")]
        Task<PhotoResponse> UnLike([AliasAs("id")] int imageId);

        //GET /stats/total
        [Get("/stats/total?client_id={clineId}")]
        Task<PhotoResponseCount> GetCountPhoto([AliasAs("clineId")] string clinetId = "dy12xlkfAvya5OqE10pqP9_0wp_rWFejplLsQrMHqpo");
    }
}
