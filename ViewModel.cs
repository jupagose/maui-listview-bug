using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTests
{
    public class ViewModel : BaseModelPrimario
    {
        public ViewModel()
        {
            Items = new ObservableCollection<TestItem>()
            {
                new TestItem() {Name = "Item1",Value = 0},
                new TestItem() {Name = "Item2",Value = 0},
                new TestItem() {Name = "Item3",Value = 0},
                new TestItem() {Name = "Item4",Value = 0},
            };
            PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            /// IF I HIT MY ENTRY OR MY BUTTON THEN 
            /// SELECTED ITME MUST CHANGE, BUT MAUI 
            /// DON'T CARE ABOUT INNER CONTROLS INTO
            /// MY LIST VIEW :'(
            if (e.PropertyName == nameof(SelectedItem))
            {
                Shell.Current.DisplayAlert("", $"New selected item is: {SelectedItem.Name}", "OK");
            }
        }

        #region Selected Item
        private TestItem _SelectedItem;
        /// <summary>
        /// SelectedItem: Selected Item
        /// </summary>
        public TestItem SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }
        #endregion

        #region My Items
        private ObservableCollection<TestItem> _Items;
        /// <summary>
        /// Items: My Items
        /// </summary>
        public ObservableCollection<TestItem> Items
        {
            get => _Items;
            set => SetProperty(ref _Items, value);
        }
        #endregion
    }
}
