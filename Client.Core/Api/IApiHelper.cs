using Client.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Core.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUserModel> Authenticate(string username, string password);
    }
}