namespace XamarinFormApp2.ViewModels
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Extensions;
    using XamarinFormApp2.Interfaces;
    using XamarinFormApp2.Views;

    public class TheNextViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private readonly IMessageBoxService messageBoxService;

        private string name;

        private bool initialise = false;

        private string textFromPreviousPage;

        private string theNewTextForCustomControl;

        public TheNextViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService)
        {
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;

            this.ThreeDTextCommand = new DelegateCommand(async () => await this.ThreeDTextAsync());
            this.DisplayAlertCommand = new DelegateCommand(async () => await this.DisplayAlertAsync());
            this.ThreeDTextCommand = new DelegateCommand(async () => await this.ThreeDTextAsync());
            this.ListViewCommand = new DelegateCommand(async () => await this.ListViewAsync());
            this.TextUpdatedCommand = new DelegateCommand<string>(async (x) => await this.TextUpdatedAsync(x));
            this.StoragePageCommand = new DelegateCommand(async () => await this.StoragePageAsync());
            this.UpdateControlCommand = new DelegateCommand(() =>
                {
                    this.TheNewTextForCustomControl = "this is the new text";
                });


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

        public ICommand StoragePageCommand { get; set; }

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
            
            this.TheNewTextForCustomControl = "default text - this will update";

            if (this.ViewArgs != null)
            {
                this.TextFromPreviousPage = ((TheNextPageViewArgs)this.ViewArgs).SomeImpotantParameter;
            }
        }

        private async Task DisplayAlertAsync()
        {
            await this.navigationService.PushModalAsync(new MainPage()).ConfigureAwait(false);
        }

        private async Task ThreeDTextAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetThreeDTextViewDescriptor()).ConfigureAwait(false);
        }

        private async Task ListViewAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetListPageViewDescriptor()).ConfigureAwait(false);
        }

        private async Task TextUpdatedAsync(string text)
        {
            await this.messageBoxService.ShowMessageAsync(MessageBoxType.TextUpdate).ConfigureAwait(false);
        }

        private async Task StoragePageAsync()
        {
            await this.navigationService.NavigateToAsync(this.navigationService.GetStoragePageViewDescriptor()).ConfigureAwait(false);
        }
    }
}
