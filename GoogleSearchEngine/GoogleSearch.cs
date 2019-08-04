using Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace GoogleSearchEngine
{
    public class GoogleSearch : ISearchEngine
    {
        public List<SearchResult> Search(string query)
        {
            List<SearchResult> searchResults = new List<SearchResult>();
            try
            {
                ChromeOptions options = new ChromeOptions();
                using (IWebDriver webDriver = new ChromeDriver(options))
                {      
                    webDriver.Url = "https://www.google.com/search?q=" + query + "&num=20";
                    WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
                    wait.Until(a => a.FindElement(By.CssSelector("#search")));
                    var results = webDriver.FindElements(By.CssSelector(".rc"));
                    foreach (var result in results)
                    {
                        try
                        {
                            var titleElement = result.FindElement(By.CssSelector(".r h3"));
                            var title = titleElement.Text;
                            var urlElement = result.FindElement(By.CssSelector(".r cite"));
                            var url = urlElement.Text;
                            var descriptionElement = result.FindElement(By.CssSelector(".s .st"));
                            var description = descriptionElement.Text;
                            searchResults.Add(new SearchResult
                            {
                                Title = title,
                                Uri = url,
                                Description = description
                            });
                        }
                        catch   
                        {
                            continue;
                        }
                    }
                    webDriver.Quit();
                    return searchResults;
                }
            }
            catch(Exception e)
            {
                searchResults = new List<SearchResult>();
                searchResults.Add(new SearchResult
                {
                    Title = "Error",
                    Uri = "",
                    Description = "Error occurred getting google search results"
                });
            }
            return searchResults;
        }

    
        
    }
      
    
}
