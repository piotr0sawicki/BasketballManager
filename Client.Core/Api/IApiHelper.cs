using System.Net.Http;

namespace Client.Core.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
    }
}