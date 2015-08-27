﻿
namespace XamarinFormApp2
{
    using Microsoft.Practices.Unity;

    using Xamarin.Forms;

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
        

        public void Initialize()
        {
        }

        private void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IJsonSerializer, JsonSerializer>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommunicationService, CommunicationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager(), new InjectionConstructor(Application.Current));
        }
        
        private void RegisterViewModels(IUnityContainer container)
        {
            container.RegisterType<MainViewModel, MainViewModel>();
            container.RegisterType<TheNextViewModel, TheNextViewModel>();
            container.RegisterType<ListPageViewModel, ListPageViewModel>();
        }

    }
}
