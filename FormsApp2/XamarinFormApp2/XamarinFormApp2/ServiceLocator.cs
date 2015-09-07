
namespace XamarinFormApp2
{
    using System;
    using System.Reflection;

    using Microsoft.Practices.Unity;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Interfaces;
    using XamarinFormApp2.Services;
    using XamarinFormApp2.ViewModels;

    public class ServiceLocator
    {
        private UnityContainer globalContainer;

        public ServiceLocator()
        {
            this.globalContainer = new UnityContainer();


            this.RegisterServices(this.globalContainer);
            this.RegisterViewModels(this.globalContainer);
        }

        public MainViewModel MainViewModel
        {
            get { return this.globalContainer.Resolve<MainViewModel>(); }
        }

        public TheNextViewModel TheNextViewModel
        {
            get { return this.globalContainer.Resolve<TheNextViewModel>(); }
        }

        public ListPageViewModel ListPageViewModel
        {
            get { return this.globalContainer.Resolve<ListPageViewModel>(); }
        }

        public StoragePageViewModel StoragePageViewModel
        {
            get { return this.globalContainer.Resolve<StoragePageViewModel>(); }
        }

        public TabPageViewModel TabPageViewModel
        {
            get { return this.globalContainer.Resolve<TabPageViewModel>(); }
        } 
        

        public void Initialize()
        {
        }

        private void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IJsonSerializer, JsonSerializer>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommunicationService, CommunicationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager(), new InjectionConstructor(Application.Current));
            container.RegisterType<IMessageBoxService, MessageBoxService>(new ContainerControlledLifetimeManager(), new InjectionConstructor(Application.Current));
            container.RegisterType<IStorageService, StorageService>(new ContainerControlledLifetimeManager());
        }
        
        private void RegisterViewModels(IUnityContainer container)
        {
            container.RegisterType<MainViewModel, MainViewModel>();
            container.RegisterType<TheNextViewModel, TheNextViewModel>();
            container.RegisterType<ListPageViewModel, ListPageViewModel>();
            container.RegisterType<StoragePageViewModel, StoragePageViewModel>();
            container.RegisterType<TabPageViewModel, TabPageViewModel>();
        }
    }


    /// <remark>
    /// http://forums.xamarin.com/discussion/comment/149298#Comment_149298    
    /// this is because we are instanciating the view model in the view xaml
    /// there is no one time only binding in xamarin forms
    /// </remark>
    [ContentProperty("Member")]
    public class ServiceLocatorExtension : IMarkupExtension
    {
        public string Member { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            object locator = Application.Current.Resources["ServiceLocator"];
            return locator.GetType().GetRuntimeProperty(this.Member).GetValue(locator);
        }
    }
}
