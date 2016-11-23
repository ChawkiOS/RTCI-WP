using RTCI.Model;
using RTCI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace RTCI.Views
{

    public sealed partial class LoadingView : Page
    {
        public LoadingView()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await getActualitesItems();
        }



        private async Task getActualitesItems()
        {
            XDocument rss = XDocument.Load("");
            IEnumerable<XElement> items = rss.Element("rss").Element("channel").Elements("item");
            XElement TitleElement = rss.Element("rss").Element("channel");

            List<ActualiteItem> listActs = new List<ActualiteItem>();

            for (int i = 0; i < items.Count(); i++)
            {
                ActualiteItem feedItem = new ActualiteItem();

                feedItem.Title = TitleElement.Element("title").Value;
                feedItem.Description = items.ElementAt(i).Element("content:encoded").Value;
                feedItem.Category = items.ElementAt(i).Element("category").Value;
                feedItem.Creator = items.ElementAt(i).Element("dc:creator").Value;
                feedItem.PubDate = items.ElementAt(i).Element("pubDate").Value;

                listActs.Add(feedItem);
            }

            Statique._MainViewModel.InsertActsList(listActs); 
        }
    }
}
