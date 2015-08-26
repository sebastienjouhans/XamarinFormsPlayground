namespace XamarinFormApp2.ViewModels
{
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;

    public class TheNextViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private string name;

        public TheNextViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.MasterDetailsCommand = new DelegateCommand(this.MasterDetails);
        }

        public ICommand MasterDetailsCommand { get; private set; }

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

        private void MasterDetails()
        {
            this.navigationService.NavigateTo(this.navigationService.GetMasterDetailsViewDescriptor());
        }
    }
}
