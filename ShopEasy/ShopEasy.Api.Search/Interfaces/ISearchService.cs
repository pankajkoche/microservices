namespace ShopEasy.Api.Search.Interfaces
{
    public interface ISearchService
    {
       Task<(bool IsSuccess, dynamic SerachResult )> SearchAsync(int customerId)
    }
}
