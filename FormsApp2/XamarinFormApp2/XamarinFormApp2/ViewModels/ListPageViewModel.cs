using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.ViewModels
{
    using System.Diagnostics;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using Xamarin.Forms;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Interfaces;

    public class ListPageViewModel : ViewModelBase
    {
        private readonly ICommunicationService communicationService;

        private readonly IMessageBoxService messageBoxService;

        private TestData listViewData;

        private List<User> usersData;

        private bool isLoading;

        public ListPageViewModel(ICommunicationService communicationService,
            IMessageBoxService messageBoxService)
        {
            this.communicationService = communicationService;
            this.messageBoxService = messageBoxService;

            this.AppearingCommand = new DelegateCommand(async () => await this.AppearingAsync());

            this.ItemSelectedCommand = new DelegateCommand<SelectedItemChangedEventArgs>((evt) => this.ItemSelected(evt));
        }

        public ICommand AppearingCommand { get; private set; }

        public ICommand ItemSelectedCommand { get; private set; }

        public TestData ListViewData
        {
            get
            {
                return this.listViewData;
            }

            private set
            {
                this.Set(() => this.ListViewData, ref this.listViewData, value);
            }
        }

        public List<User> UsersData
        {
            get
            {
                return this.usersData;
            }

            private set
            {
                this.Set(() => this.UsersData, ref this.usersData, value);
            }
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            private set
            {
                this.Set(() => this.IsLoading, ref this.isLoading, value);
            }
        }

        public override void Dispose()
        {
        }

        private async Task AppearingAsync()
        {
            this.IsLoading = true;

            var result = await this.communicationService.GetTestDataAsync().ConfigureAwait(false);

            if (result == null)
            {
                return;
            }

            this.ListViewData = result.Response;

            this.UsersData = this.ListViewData.Users;

            this.IsLoading = false;
        }

        private async Task ItemSelected(SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            await
                this.messageBoxService.ShowMessageAsync(MessageBoxType.Generic, "user", (e.SelectedItem as User).Name)
                    .ConfigureAwait(false);
        }
    }
}
