namespace XamarinFormApp2.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Data;
    using XamarinFormApp2.Entities;

    public class TabPageViewModel : ViewModelBase
    {
        private IList<Monkey> monkeys;

        public TabPageViewModel()
        {
            this.AppearingCommand = new DelegateCommand(this.Appearing);
        }

        public ICommand AppearingCommand { get; private set; }

        public IList<Monkey> Monkeys
        {
            get
            {
                return this.monkeys;
            }

            private set
            {
                this.Set(() => this.Monkeys, ref this.monkeys, value);
            }
        }

        public override void Dispose()
        {
        }

        private void Appearing()
        {
            this.Monkeys = MonkeyData.All;
        }
    }
}
