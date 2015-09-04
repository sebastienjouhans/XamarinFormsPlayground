namespace XamarinFormApp2.ViewModels
{
    using System.Windows.Input;
    using System.Threading.Tasks;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Interfaces;

    public class StoragePageViewModel : ViewModelBase
    {
        private readonly IStorageService storageService;

        private readonly IJsonSerializer jsonSerializer;

        private readonly IMessageBoxService messageBoxService;

        private string age;

        private string name;

        private bool initialise = false;

        public StoragePageViewModel(IStorageService storageService, IJsonSerializer jsonSerializer, IMessageBoxService messageBoxService)
        {
            this.storageService = storageService;
            this.jsonSerializer = jsonSerializer;
            this.messageBoxService = messageBoxService;
            this.StoreContentCommand = new DelegateCommand(async () => await this.StoreContentAsync());

            this.Name = "seb";
            this.Age = "23";

            this.AppearingCommand = new DelegateCommand(this.Appearing);
        }

        public ICommand StoreContentCommand { get; set; }

        public ICommand AppearingCommand { get; private set; }

        public override void Dispose()
        {
            
        }

        private void Appearing()
        {
            if (this.initialise)
            {
                return;
            }

            this.InitialiseAsync();
        }

        private async Task InitialiseAsync()
        {
            this.initialise = true;

            var result = await this.storageService.GetDataSettingAsync();

            if (result == null)
            {
                return;
            }

            this.Name = result.Name;
            this.Age = result.Age.ToString();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.Set(() => this.Name, ref this.name, value);
            }
        }

        public string Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.Set(() => this.Age, ref this.age, value);
            }
        }

        private async Task StoreContentAsync()
        {
            var user = new User { Name = this.Name, Age = int.Parse(this.Age) };

            var result = await this.storageService.SaveDataSettingAsync(user).ConfigureAwait(false);

            if (!result)
            {
                //this.messageBoxService.ShowMessageAsync()
            }
        }
    }
}
