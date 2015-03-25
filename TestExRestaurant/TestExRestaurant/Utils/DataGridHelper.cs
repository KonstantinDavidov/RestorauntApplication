using System;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TestExRestaurant.Utils
{
    public static class DataGridHelper
    {
        static public DataGridCell GetCell(DataGrid dg, int row, int column)
        {
            DataGridRow rowContainer = GetRow(dg, row);

            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = DependencyObjectHelper.GetVisualChild<DataGridCellsPresenter>(rowContainer);

                // try to get the cell but it may possibly be virtualized
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    // now try to bring into view and retreive the cell
                    dg.ScrollIntoView(rowContainer, dg.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }


        static public DataGridRow GetRow(DataGrid dg, int index)
        {
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // may be virtualized, bring into view and try again
                dg.ScrollIntoView(dg.Items[index]);
                row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        static public int? GetRowIndex(DataGrid dg, DataGridCellInfo dgci)
        {
            var icg = dg.ItemContainerGenerator;
            if (icg.Status == GeneratorStatus.ContainersGenerated)
            {
                DataGridRow dgrow = (DataGridRow)icg.ContainerFromItem(dgci.Item);
                if (dgrow == null)
                {
                    return null;
                }
                return dgrow.GetIndex();
            }
            else
            {
                ManualResetEventSlim es = new ManualResetEventSlim(false);
                EventHandler dd = null;
                int rowIndex = -1;
                dd = delegate(object sender, EventArgs args)
                {
                    DataGridRow dgrow = (DataGridRow)icg.ContainerFromItem(dgci.Item);
                    rowIndex = dgrow.GetIndex();
                    icg.StatusChanged -= dd;
                    es.Set();
                };
                icg.StatusChanged += dd;
                es.Wait();
                return rowIndex;
            }
        }

        static public int GetColIndex(DataGrid dg, DataGridCellInfo dgci)
        {
            return dgci.Column.DisplayIndex;
        }

        private static void BeginEditDataGridCell(DataGrid dg)
        {
            if (dg.SelectedCells == null || !dg.SelectedCells.Any())
                return;
            DataGridCellInfo dgci = dg.SelectedCells[0];
            if (!dgci.IsValid)
                return;
            int? rowIndex = GetRowIndex(dg, dgci);
            if (!rowIndex.HasValue)
            {
                return;
            }
            DataGridCell dgc = GetCell(
                dg,
                rowIndex.GetValueOrDefault(),
                GetColIndex(dg, dgci)
                );
            dgc.IsSelected = true;
            dgc.Focus();
            dg.BeginEdit();
        }

        public static void DataGridSelectedCellsChanged(DataGrid dg)
        {
            dg.UpdateLayout();
            BeginEditDataGridCell(dg);
        }
    }
}
