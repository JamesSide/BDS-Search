using SearchService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool.TryParse(ConfigurationManager.AppSettings["UseEngine1"], out bool useEngine1);
            bool.TryParse(ConfigurationManager.AppSettings["UseEngine2"], out bool useEngine2);
            bool.TryParse(ConfigurationManager.AppSettings["UseGoogle"], out bool useGoogle);

            ServiceConfiguration configuration = new ServiceConfiguration
            {
                UsePocSearchEngine1 = useEngine1,
                UsePocSearchEngine2 = useEngine2,
                UseGoogleApi = useGoogle
            };

            List<SearchResult> results = SearchService.AggregatedSearchResults(searchBox.Text, configuration);
            searchResults.Items.Clear();
            results.ForEach(result => searchResults.Items.Add(SearchResultRow(result)));
            searchResults.Visibility = Visibility.Visible;
        }

        private ListBoxItem SearchResultRow(SearchResult result)
        {
            var row = new ListBoxItem();
            var container = new StackPanel();
            var heading = new TextBlock();
            heading.Text = result.Title;
            heading.FontSize = 16;
            var description = new TextBlock();
            description.Text = result.Description;
            var uri = new TextBlock();
            uri.Text = result.Uri;
            uri.Foreground = new SolidColorBrush(Colors.Blue);
            uri.TextDecorations.Add(TextDecorations.Underline);
            container.Children.Add(heading);
            container.Children.Add(uri);
            container.Children.Add(description);
            row.Content = container;
            return row;
        }

    }
}
