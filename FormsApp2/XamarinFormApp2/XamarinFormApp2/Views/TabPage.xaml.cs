using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFormApp2.Views
{
    using XamarinFormApp2.ViewModels;

    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            this.InitializeComponent();

            this.BindingContext = ((ServiceLocator)Application.Current.Resources["ServiceLocator"]).TabPageViewModel;
        }
    }
}
