using System;
using System.Collections.Generic;
using System.Linq;


namespace XamarinFormApp2.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;

    public class MessageBoxService : IMessageBoxService
    {
        private readonly Application application;

        private readonly Lazy<Page> mainPage;

        public MessageBoxService(Application application)
        {
            this.application = application;

            this.mainPage = new Lazy<Page>(this.GetDisplayAllert, LazyThreadSafetyMode.ExecutionAndPublication);
        }


        public async Task ShowMessageAsync(MessageBoxType messageBoxType)
        {
            switch (messageBoxType)
            {
                case MessageBoxType.TextUpdate:
                    await this.MainPage.DisplayAlert("title here", "the text in the control has updated", "OK", "Close");
                    break;
            }
        }

        public async Task ShowMessageAsync(MessageBoxType messageBoxType, string title, string message)
        {
            switch (messageBoxType)
            {
                case MessageBoxType.Generic:
                    await this.MainPage.DisplayAlert(title, message, "OK", "Cancel");
                    break;
            }
        }

        private Page GetDisplayAllert()
        {
            return this.application.MainPage;
        }

        private Page MainPage
        {
            get { return this.mainPage.Value; }
        }
    }
}
