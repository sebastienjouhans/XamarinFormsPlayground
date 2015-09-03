using UIKit;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;

[assembly: ExportRendererAttribute(typeof(XamarinFormApp2.Controls.MyCustomButton), typeof(XamarinFormApp2.iOS.Controls.CustomButtonRenderer))]
namespace XamarinFormApp2.iOS.Controls
{
	using System;
	using Xamarin.Forms.Platform.iOS;

	public class CustomButtonRenderer : ButtonRenderer
	{
		UIButton btn ;
		public CustomButtonRenderer()
		{

		}

		public override void Draw (CGRect rect)
		{
			base.Draw (rect);

			CAGradientLayer btnGradient = new CAGradientLayer ();
			btnGradient.Frame = btn.Bounds;
			btnGradient.Colors = new CGColor[]{ Color.White.ToCGColor(), Color.FromHex("#0073BD").ToCGColor() };
			btn.Layer.InsertSublayer (btnGradient, 0);
			btn.Layer.MasksToBounds = true;
			btn.Layer.BorderColor = Color.FromHex("#0073BE").ToCGColor();
			btn.Layer.BorderWidth = 1;
			btn.SetTitleColor(Color.Black.ToUIColor (), UIControlState.Normal);
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			if(e.OldElement == null)
			{
				btn = (UIButton) Control;
			}
		}
	}
}

