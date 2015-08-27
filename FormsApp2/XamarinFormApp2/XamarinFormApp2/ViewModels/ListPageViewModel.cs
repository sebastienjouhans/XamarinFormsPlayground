using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.ViewModels
{
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Interfaces;

    public class ListPageViewModel : ViewModelBase
    {
        private readonly ICommunicationService communicationService;

        private TestData listViewData;

        public ListPageViewModel(ICommunicationService communicationService)
        {
            this.communicationService = communicationService;

            this.OnAppearingCommand = new DelegateCommand(async () => await this.OnAppearingAsync());
        }

        public ICommand OnAppearingCommand { get; private set; }

        public ICommand OnDisappearingCommand { get; private set; }

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

        public override void Dispose()
        {
        }

        private async Task OnAppearingAsync()
        {
            var result = await this.communicationService.GetTestDataAsync().ConfigureAwait(false);

            if (result == null)
            {
                return;
            }

            this.ListViewData = result.Response;
        }
    }
}
