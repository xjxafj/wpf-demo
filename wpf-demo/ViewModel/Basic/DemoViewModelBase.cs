using System.Collections.Generic;

namespace wpf_demo.ViewModel
{
    public class DemoViewModelBase<T> : GalaSoft.MvvmLight.ViewModelBase
    {
        /// <summary>
        ///     数据列表
        /// </summary>
        private IList<T> _dataList;

        /// <summary>
        ///     数据列表
        /// </summary>
        public IList<T> DataList
        {
            get => _dataList;

            set => Set(ref _dataList, value);
        }
    }
}
