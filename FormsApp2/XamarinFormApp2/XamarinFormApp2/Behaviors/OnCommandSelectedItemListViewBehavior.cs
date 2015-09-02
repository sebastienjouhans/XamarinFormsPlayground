using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.Behaviors
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public class OnCommandSelectedItemListViewBehavior : Xamarin.Behaviors.Behavior<ListView>
    {

        //public static readonly BindableProperty CommandProperty =
        //    BindableProperty.Create<OnSelectedItemListViewBehavior, ICommand>(
        //        ctrl => ctrl.LeftTitle,
        //        defaultValue: null,
        //        defaultBindingMode: BindingMode.TwoWay,
        //        propertyChanging: (bindable, oldValue, newValue) =>
        //        {
        //            var ctrl = (CustomHeaderBox)bindable;
        //            ctrl.LeftTitle = newValue;
        //        });

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create<OnCommandSelectedItemListViewBehavior, ICommand>(
                ctrl => ctrl.Command,
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanging: null);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private void AttacchedObjectItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.Command == null || !this.Command.CanExecute(e))
            {
                return;
            }

            this.Command.Execute(e);

            this.AssociatedObject.SelectedItem = null;
        }

        protected override void OnAttach()
        {
            this.AssociatedObject.ItemSelected += this.AttacchedObjectItemSelected;
        }

        protected override void OnDetach()
        {
            this.AssociatedObject.ItemSelected -= this.AttacchedObjectItemSelected;
        }
    }
}
