using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestExRestaurant.Controls
{
    public class CustomDataGrid : DataGrid
    {

        #region CanEditAllRecordsWhhenValidationErrors

        /// <summary>
        /// CanEditAllRecordsWhhenValidationErrors Dependency Property
        /// </summary>
        public static readonly DependencyProperty CanEditAllRecordsWhenValidationErrorsProperty =
            DependencyProperty.Register("CanEditAllRecordsWhenValidationErrors", typeof(bool),
                typeof(CustomDataGrid),
                new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets the CanEditAllRecordsWhhenValidationErrors property. This dependency property 
        /// indicates ....
        /// </summary>
        public bool CanEditAllRecordsWhenValidationErrors
        {
            get { return (bool)GetValue(CanEditAllRecordsWhenValidationErrorsProperty); }
            set { SetValue(CanEditAllRecordsWhenValidationErrorsProperty, value); }
        }

        #endregion


        /// <summary>
        ///this is a fix for validation bug
        /// <seealso cref="http://stackoverflow.com/questions/4093074/datagrid-on-cell-validation-error-other-row-cells-are-uneditable-readonly"/>
        //see for example 
        /// </summary>
        protected override void OnCanExecuteBeginEdit(CanExecuteRoutedEventArgs e)
        {
            
            bool hasCellValidationError = false;
            bool hasRowValidationError = false;
            const BindingFlags bindingFlags =
                BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance;

            //Current cell
            var baseType = this.GetType().BaseType;

            if (baseType == null)
            {
                throw new NullReferenceException("Vase type for this control does not exists.");
            }

            PropertyInfo cellErrorInfo = baseType.GetProperty("HasCellValidationError", bindingFlags);

            //Grid level
            PropertyInfo rowErrorInfo = baseType.GetProperty("HasRowValidationError", bindingFlags);

            if (cellErrorInfo != null) hasCellValidationError = (bool)cellErrorInfo.GetValue(this, null);
            if (rowErrorInfo != null) hasRowValidationError = (bool)rowErrorInfo.GetValue(this, null);

            base.OnCanExecuteBeginEdit(e);

            if (
                this.CanEditAllRecordsWhenValidationErrors && 
                !e.CanExecute && 
                !hasCellValidationError &&
                hasRowValidationError
                )
            {
                e.CanExecute = true;
                e.Handled = true;
            }
        }

    }
}
