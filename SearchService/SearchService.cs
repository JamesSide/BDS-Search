using GoogleSearchEngine;
using POCSearchEngine1;
using POCSearchEngine2;
using SearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class SearchService
    {
        public static List<SearchResult> AggregatedSearchResults(string query, ServiceConfiguration configuration)
        {
            return GetSearchEngines(configuration).SelectMany(engine => engine.Search(query)).ToList();
        }

        private static IEnumerable<ISearchEngine> GetSearchEngines(ServiceConfiguration configuration)
        {
            if(configuration.UsePocSearchEngine1)
            {
                yield return new SearchEngine1();
            }
            if (configuration.UsePocSearchEngine2)
            {
                yield return new SearchEngine2();
            }
            if(configuration.UseGoogleApi)
            {
                yield return new GoogleSearch();
            }
        }
    }
}
