using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ExcelAddIn.Log.DisplayObjects
{
    class WeightItemSource : IItemsSource
    {
        public WeightItemSource()
        {

        }
        public ItemCollection GetValues()
        {
            ItemCollection sizes = new ItemCollection();
            //sizes = Network.Default
            return sizes;
        }
    }
}
