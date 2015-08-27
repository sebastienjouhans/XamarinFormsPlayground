namespace XamarinFormApp2.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;
    using XamarinFormApp2.Views;

    public class TheNextViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private string name;

        private bool initialise = false;

        public TheNextViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.MasterDetailsCommand = new DelegateCommand(async () => await this.MasterDetailsAsync());
            this.DisplayAlertCommand = new DelegateCommand(this.DisplayAlert);

            this.OnAppearingCommand = new DelegateCommand(this.OnAppearing);
            this.OnDisappearingCommand = new DelegateCommand(this.OnDisappearing);
        }

        public ICommand MasterDetailsCommand { get; private set; }

        public ICommand DisplayAlertCommand { get; private set; }

        public ICommand OnAppearingCommand { get; private set; }

        public ICommand OnDisappearingCommand { get; private set; }

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

        protected override void OnAppearing()
        {
            if (this.initialise)
            {
                return;
            }

            this.Initialise();
        }

        protected override void OnDisappearing()
        {
            this.Dispose();
        }

        private void Initialise()
        {
            this.initialise = true;
        }

        private async Task MasterDetailsAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetMasterDetailsViewDescriptor());
        }

        private void DisplayAlert()
        {
            this.navigationService.PushModalAsync(new MainPage());
        }
    }
}
