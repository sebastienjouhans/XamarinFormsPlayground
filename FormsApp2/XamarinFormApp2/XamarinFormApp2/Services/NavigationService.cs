
namespace XamarinFormApp2.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;

    public class NavigationService : INavigationService
    {
        private readonly Application application;

        private readonly Lazy<INavigation> navigation;

        private const string PathTemplate = @"XamarinFormApp2.Views.{0}";

        public NavigationService(Application application)
        {
            this.application = application;

            this.navigation = new Lazy<INavigation>(this.GetNavigation, LazyThreadSafetyMode.ExecutionAndPublication);
        }


        public void RemovePage(Page page)
        {
            this.Navigation.RemovePage(page);
        }

        public void InsertPageBefore(Page page, Page before)
        {
            this.Navigation.InsertPageBefore(page, before);
        }

        public async Task NavigateToAsync(ViewDescriptor viewDescriptor)
        {
            await this.NavigateToAsync(viewDescriptor, false).ConfigureAwait(false);
        }

        public async Task NavigateToAsync(ViewDescriptor viewDescriptor, bool animated)
        {
            var pageName = viewDescriptor.PageType.ToString();
            var type = Type.GetType(string.Format(PathTemplate, pageName));
            var page = (Page)Activator.CreateInstance(type);

            var viewModel = page.BindingContext as IViewModel;

            if (viewModel != null)
            {
                viewModel.ViewArgs = viewDescriptor.ViewArgs;
            }

            await this.Navigation.PushAsync(page, animated).ConfigureAwait(false);
        }

        public async Task<Page> GoBackAsync()
        {
            return await this.GoBackAsync(false).ConfigureAwait(false);
        }

        public async Task<Page> GoBackAsync(bool animated)
        {
            return await this.Navigation.PopAsync(animated).ConfigureAwait(false);
        }

        public async Task PushModalAsync(Page page)
        {
            await this.PushModalAsync(page, false).ConfigureAwait(false);
        }

        public async Task PushModalAsync(Page page, bool animated)
        {
            this.Navigation.PushModalAsync(page, animated).ConfigureAwait(false);
        }

        
        //public Task PopToRootAsync()
        //{
        //    return this.Navigation.PopToRootAsync();
        //}

        //public Task PushModalAsync(Page page)
        //{
        //    return this.Navigation.PushModalAsync(page);
        //}

        //public Task<Page> PopModalAsync()
        //{
        //    return this.Navigation.PopModalAsync();
        //}

        //public Task PopToRootAsync(bool animated)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task PushModalAsync(Page page, bool animated)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<Page> PopModalAsync(bool animated)
        //{
        //    throw new System.NotImplementedException();
        //}


        public ViewDescriptor GetListPageViewDescriptor()
        {
            return new ViewDescriptor(PageType.ListPage);
        }

        public ViewDescriptor GetStoragePageViewDescriptor()
        {
            return new ViewDescriptor(PageType.StoragePage);
        }

        public ViewDescriptor GetTheNextPageViewDescriptor(ViewArgs viewArgs)
        {
            return new ViewDescriptor(PageType.TheNextPage, viewArgs);
        }

        public ViewDescriptor GetThreeDTextViewDescriptor()
        {
            return new ViewDescriptor(PageType.ThreeDTextPage);
        }

        private INavigation GetNavigation()
        {
            return this.application.MainPage.Navigation;
        }

        private INavigation Navigation
        {
            get{ return this.navigation.Value; }
        }
    }
}
