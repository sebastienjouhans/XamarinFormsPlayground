﻿using Xamarin.Forms;

using XamarinFormApp2.WinPhone.Controls;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace XamarinFormApp2.WinPhone.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using Xamarin.Forms.Platform.WinPhone;
    
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var button = e.NewElement;


            if (Control != null)
            {
                button.SizeChanged += OnSizeChanged;
            }
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            var button = (Xamarin.Forms.Button)sender;

            Control.ApplyTemplate();
            var borders = Control.GetVisuals<Border>();

            foreach (var border in borders)
            {
                border.CornerRadius = new CornerRadius(button.BorderRadius);
            }

            button.SizeChanged -= OnSizeChanged;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "BorderRadius")
            {
                var borders = Control.GetVisuals<Border>();

                foreach (var border in borders)
                {
                    border.CornerRadius = new CornerRadius(((Xamarin.Forms.Button)sender).BorderRadius);
                }
            }
        }
    }

    internal static class DependencyObjectExtensions
    {
        public static IEnumerable<T> GetVisuals<T>(this DependencyObject root) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(root);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                if (child is T) yield return child as T;

                foreach (var descendants in child.GetVisuals<T>())
                {
                    yield return descendants;
                }
            }
        }
    }
}
