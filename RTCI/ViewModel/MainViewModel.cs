using RTCI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCI.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ActualiteItem> ActualitesCollectionItem { get; set; }

        public MainViewModel()
        {
            ActualitesCollectionItem = new ObservableCollection<ActualiteItem>();
        }

        public void InsertActsList(List<ActualiteItem> listAct)
        {
            ActualitesCollectionItem.Clear();

            foreach (var item in listAct)
            {
                ActualitesCollectionItem.Add(item);
            }
        }
    }
}
