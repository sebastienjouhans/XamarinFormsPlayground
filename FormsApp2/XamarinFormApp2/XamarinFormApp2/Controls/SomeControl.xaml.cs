

namespace XamarinFormApp2.Controls
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public partial class SomeControl : ContentView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create<SomeControl, ICommand>(
                ctrl => ctrl.Command,
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: null);

        public static readonly BindableProperty SomeNewTextProperty =
            BindableProperty.Create<SomeControl, string>(
                ctrl => ctrl.SomeNewText,
                defaultValue: "this text will update",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (SomeControl)bindable;
                    ctrl.MyLabel.Text = (string)newValue;
                    ctrl.Command.Execute(true);
                });

        public SomeControl()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string SomeNewText
        {
            get { return (string)GetValue(SomeNewTextProperty); }
            set { SetValue(SomeNewTextProperty, value); }
        }
    }
}
