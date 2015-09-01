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

    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Interfaces;

    public class ListPageViewModel : ViewModelBase
    {
        private readonly ICommunicationService communicationService;

        private TestData listViewData;

        private List<User> usersData;

        public ListPageViewModel(ICommunicationService communicationService)
        {
            this.communicationService = communicationService;

            this.AppearingCommand = new DelegateCommand(async () => await this.AppearingAsync());

            this.ItemSelectedCommand = new DelegateCommand<SelectedItemChangedEventArgs>(this.ItemSelected);
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

        public override void Dispose()
        {
        }

        private async Task AppearingAsync()
        {
            var result = await this.communicationService.GetTestDataAsync().ConfigureAwait(false);

            if (result == null)
            {
                return;
            }

            this.ListViewData = result.Response;

            this.UsersData = this.ListViewData.Users;
        }

        private void ItemSelected(SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine((e.SelectedItem as User).Name);
        }
    }
}
