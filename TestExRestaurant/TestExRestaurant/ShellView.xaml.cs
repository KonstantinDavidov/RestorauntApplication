using System.Windows;
using System.Windows.Controls;
using TestExRestaurant.Utils;

namespace TestExRestaurant
{
    partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dg = sender as DataGrid;

            if (dg == null)  return;

            DataGridHelper.DataGridSelectedCellsChanged(dg);
        }
    }
}
