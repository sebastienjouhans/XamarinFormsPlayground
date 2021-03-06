﻿namespace XamarinFormApp2.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;
    using XamarinFormApp2.Views;

    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private int counter = 0;

        private string name;

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.ClickCommand = new DelegateCommand(this.Click);
            this.NextPageCommand = new DelegateCommand(async () => await this.NextPageAsync());

            this.Name = @"this will be updated";

            this.AppearingCommand = new DelegateCommand(this.Appearing);
            this.DisappearingCommand = new DelegateCommand(this.Disappearing);
        }

        public ICommand ClickCommand { get; private set; }

        public ICommand NextPageCommand { get; private set; }

        public ICommand AppearingCommand { get; private set; }

        public ICommand DisappearingCommand { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.Set(() => this.Name, ref this.name, value);
            }
        }

        public override void Dispose()
        {
        }

        private void Appearing()
        {
        }

        private void Disappearing()
        {
            this.Dispose();
        }

        private void Click()
        {
            this.Name = string.Format("Clicked {0} times", this.counter);
            this.counter++;
        }

        private async Task NextPageAsync()
        {
            await
                this.navigationService.NavigateToAsync(
                    this.navigationService.GetTheNextPageViewDescriptor(
                        new TheNextPageViewArgs { SomeImpotantParameter = "this a passed viewargs" }),
                    true).ConfigureAwait(false);
        }
    }
}
