namespace XamarinFormApp2.WinPhone
{
    using Microsoft.Phone.Controls;

    using ImageCircle.Forms.Plugin.WindowsPhone;

    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new XamarinFormApp2.App());
        }
    }
}
