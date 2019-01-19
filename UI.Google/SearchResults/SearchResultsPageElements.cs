using UI.Core.Abstractions;

namespace UI.Google.SearchResults
{
    public class SearchResultsPageElements : PageElements
    {
        public string SearchResults => "div#ires div.g";

        public string SearchHeaders => $"{SearchResults} a h3";
        public string SearchLinks => $"{SearchResults} a div.TbwUpd > cite";

        public string Page(int pageNumber) => $"table#nav a[aria-label='Page {pageNumber}']";
    }
}
