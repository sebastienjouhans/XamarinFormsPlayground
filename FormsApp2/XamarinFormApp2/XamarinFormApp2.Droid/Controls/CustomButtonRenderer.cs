using Xamarin.Forms;

using XamarinFormApp2.Droid.Controls;

[assembly: ExportRenderer(typeof(XamarinFormApp2.Controls.MyCustomButton), typeof(CustomButtonRenderer))]
namespace XamarinFormApp2.Droid.Controls
{
    using System.ComponentModel;

    using Android.Graphics.Drawables;

    using Xamarin.Forms.Platform.Android;

    public class CustomButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _normal, _pressed;

        private bool styled = false;

        public CustomButtonRenderer()
            : base()
        {
            this.SetWillNotDraw(false);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            //if (Control != null)
            //{
            //    var button = e.NewElement;

            //    // Create a drawable for the button's normal state
            //    _normal = new Android.Graphics.Drawables.GradientDrawable();

            //    if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
            //        _normal.SetColor(Android.Graphics.Color.ParseColor("#ff002eff"));
            //    else
            //        _normal.SetColor(button.BackgroundColor.ToAndroid());

            //    _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
            //    _normal.SetCornerRadius(button.BorderRadius);

            //    // Create a drawable for the button's pressed state
            //    _pressed = new Android.Graphics.Drawables.GradientDrawable();
            //    var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
            //    //_pressed.SetColor(highlight);
            //    _pressed.SetColor(Android.Graphics.Color.ParseColor("#ffff0000"));

            //    _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
            //    _pressed.SetCornerRadius(button.BorderRadius);

            //    // Add the drawables to a state list and assign the state list to the button
            //    var sld = new StateListDrawable();
            //    sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
            //    sld.AddState(new int[] { }, _normal);
            //    Control.SetBackgroundDrawable(sld);
            //}

            if (!this.styled)
            {
                this.SetStyle();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            //var button = (Xamarin.Forms.Button)sender;

            //if (_normal != null && _pressed != null)
            //{
            //    if (e.PropertyName == "BorderRadius")
            //    {
            //        _normal.SetCornerRadius(button.BorderRadius);
            //        _pressed.SetCornerRadius(button.BorderRadius);
            //    }
            //    if (e.PropertyName == "BorderWidth" || e.PropertyName == "BorderColor")
            //    {
            //        _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
            //        _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
            //    }
            //}
        }

        private void SetStyle()
        {
           // var id = Resource.Drawable.red_button;
           // var drawable = (StateListDrawable)Context.Resources.GetDrawable(id);

            Control.SetBackgroundResource(Resource.Drawable.red_button);
            Control.SetTextSize(global::Android.Util.ComplexUnitType.Dip, 30);
            Control.SetTextColor(global::Android.Graphics.Color.White);
            this.styled = true;
        }
    }
}