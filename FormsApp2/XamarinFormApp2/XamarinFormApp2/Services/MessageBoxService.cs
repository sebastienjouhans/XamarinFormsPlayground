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


        public async Task ShowMessage(MessageBoxType messageBoxType)
        {
            switch (messageBoxType)
            {
                case MessageBoxType.TextUpdate:
                    await this.MainPage.DisplayAlert("the text title", "the text message", "OK");
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
