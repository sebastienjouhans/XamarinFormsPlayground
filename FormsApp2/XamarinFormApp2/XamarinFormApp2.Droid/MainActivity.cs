

namespace XamarinFormApp2.Droid
{
    using Android.App;
    using Android.Content.PM;

    using Android.OS;

    using ImageCircle.Forms.Plugin.Droid;

    [Activity(Label = "Xamarin Form App2", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

