
using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCSearchEngine1
{
    public class SearchEngine1 : ISearchEngine
    {
        // Just returns 10 dummy search results
        public List<SearchResult> Search(string query)
        {
            return Enumerable.Range(1, 10).Select(x => new SearchResult
            {
                Title = "Result " + x + " for search engine 1",
                Description = "Description for result " + x + ", query was " + query,
                Uri = "http://localhost"
            }).ToList();
        }
    }
}
