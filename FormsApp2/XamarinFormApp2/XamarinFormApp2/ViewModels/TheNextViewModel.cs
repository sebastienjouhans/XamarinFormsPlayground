namespace XamarinFormApp2.ViewModels
{
    using System.Diagnostics;
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

        private string textFromPreviousPage;

        private string theNewTextForCustomControl;

        public TheNextViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.ThreeDTextCommand = new DelegateCommand(async () => await this.ThreeDTextAsync());
            this.DisplayAlertCommand = new DelegateCommand(this.DisplayAlert);
            this.ThreeDTextCommand = new DelegateCommand(async () => await this.ThreeDTextAsync());
            this.ListViewCommand = new DelegateCommand(async () => await this.ListViewAsync());
            this.TextUpdatedCommand = new DelegateCommand(this.TextUpdated);
            this.UpdateControlCommand = new DelegateCommand(() =>
                {
                    this.TheNewTextForCustomControl = "this is the new text";
                });


            this.TheNewTextForCustomControl = "default text - this will update";

            this.AppearingCommand = new DelegateCommand(this.Appearing);
            this.DisappearingCommand = new DelegateCommand(this.Disappearing);
        }

        public ICommand MasterDetailsCommand { get; private set; }

        public ICommand DisplayAlertCommand { get; private set; }

        public ICommand AppearingCommand { get; private set; }

        public ICommand DisappearingCommand { get; private set; }

        public ICommand ThreeDTextCommand { get; set; }

        public ICommand ListViewCommand { get; set; }

        public ICommand TextUpdatedCommand { get; set; }

        public ICommand UpdateControlCommand { get; set; }

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

        public string TextFromPreviousPage
        {
            get
            {
                return this.textFromPreviousPage;
            }

            private set
            {
                this.Set(() => this.TextFromPreviousPage, ref this.textFromPreviousPage, value);
            }
        }


        public string TheNewTextForCustomControl
        {
            get
            {
                return this.theNewTextForCustomControl;
            }

            private set
            {
                this.Set(() => this.TheNewTextForCustomControl, ref this.theNewTextForCustomControl, value);
            }
        }

        public override void Dispose()
        {
        }

        private void Appearing()
        {
            if (this.initialise)
            {
                return;
            }

            this.Initialise();
        }

        private void Disappearing()
        {
            this.Dispose();
        }

        private void Initialise()
        {
            this.initialise = true;

            this.TextFromPreviousPage = ((TheNextPageViewArgs)this.ViewArgs).SomeImpotantParameter;
        }

        private void DisplayAlert()
        {
            this.navigationService.PushModalAsync(new MainPage());
        }

        private async Task ThreeDTextAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetThreeDTextViewDescriptor()).ConfigureAwait(false);
        }

        private async Task ListViewAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetListPageViewDescriptor()).ConfigureAwait(false);
        }

        private void TextUpdated()
        {
            Debug.WriteLine("Text updated");
        }
    }
}
