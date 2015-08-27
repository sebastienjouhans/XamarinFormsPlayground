using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.ViewModels
{
    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;

    public abstract class ViewModelBase : ObservableObject, IViewModel
    {
        public ViewArgs ViewArgs { get; set; }

        public abstract void Dispose();

        protected abstract void OnAppearing();

        protected abstract void OnDisappearing();
    }
}
