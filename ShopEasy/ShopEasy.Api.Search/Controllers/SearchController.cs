using Microsoft.AspNetCore.Mvc;
using ShopEasy.Api.Search.Interfaces;
using ShopEasy.Api.Search.Models;

namespace ShopEasy.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController:ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult>SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SerachResult);
            }
            return NotFound();
        }

    }
}
