Setup:

Clone -> Open in Visual Studio 2017 or later -> Nuget Package Restore

Then it is ready to run

Actual usage of the UI is self explanatory.

It's just a simple WPF application that queries two fake search engines and aggregates their results.

There is a third search engine (actually more like a web crawler I suppose) that just queries the first 20 results in google 
but that one is rather messy and opens a chrome window via selenium (was just playing around making that really).

If you do want to try the google one it can be turned on via app config (would also need to ensure you have the chromedriver in the application directory - should get added during the package restore).

The assumption was that real search engine integrations weren't expected (after all the story didn't ask for any specific ones ;)).
Also went for a very simple aggregation (just one search engine's results after another)
