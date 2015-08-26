using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFormApp2
{
    using XamarinFormApp2.Views;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            // https://forums.xamarin.com/discussion/18590/how-to-work-around-pushasync-is-not-supported-globally-on-android
            // need use NavigationPage so thatr global navigation works
            this.MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }  
    }
}
