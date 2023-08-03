using ShopEasy.Api.Search.Interfaces;

namespace ShopEasy.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        public async  Task<(bool IsSuccess, dynamic SerachResult)> SearchAsync(int customerId)
        {
            await Task.Delay(1);
            return (true, new {Message="hello"});
        }
    }
}
