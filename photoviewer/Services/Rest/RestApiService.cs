using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using photoviewer.core.Handlers;
using photoviewer.Services.Rest;
using Refit;

namespace photoviewer.Services
{
    public class RestApiService : IRestApiService
    {
        public IRestMetodsRequest Request()
        {
            var settings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };

            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler())
            {
                BaseAddress = new Uri(Settings.BaseUrl),
                Timeout = new TimeSpan(0, 0, 10)
            };

            return RestService.For<IRestMetodsRequest>(httpClient, settings);
        }
    }

    public interface IRestApiService
    {
        IRestMetodsRequest Request();
    }
}