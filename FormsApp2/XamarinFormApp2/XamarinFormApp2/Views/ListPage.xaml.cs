using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFormApp2.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            this.BindingContext = ((ServiceLocator)Application.Current.Resources["ServiceLocator"]).ListPageViewModel;
        }
    }
}
