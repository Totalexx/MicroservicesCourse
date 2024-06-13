using Domain.Interfaces;

namespace Infastructed.Connections;

public class CheckUser : ICheckUser
{
    // private readonly IHttpClientFactory _httpClientFactory;
    //
    // public CheckUser(IHttpClientFactory httpClientFactory)
    // {
    //     _httpClientFactory = httpClientFactory;
    // }
    //
    // public async Task CheckUserExistAsync(Guid userId)
    // {
    //     var client = _httpClientFactory.CreateClient();
    //     var res = await client.GetAsync("dfgsdf");
    // }
    //
    // public Task CheckUserHasPermission(string accessToken)
    // {
    //     throw new NotImplementedException();
    // }
    public Task CheckUserExistAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task CheckUserHasPermissionAsync(Guid userId, string accessToken)
    {
        throw new NotImplementedException();
    }
}