using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTests
{
    public class TestItem : BaseModelPrimario
    {
        #region Name
        private string _Name;
        /// <summary>
        /// Name: Name
        /// </summary>
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
        #endregion

        #region Value
        private decimal _Value;
        /// <summary>
        /// Value: Value
        /// </summary>
        public decimal Value
        {
            get => _Value;
            set => SetProperty(ref _Value, value);
        }
        #endregion

    }
}
