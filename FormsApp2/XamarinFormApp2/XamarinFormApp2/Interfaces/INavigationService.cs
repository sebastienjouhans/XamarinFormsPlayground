namespace XamarinFormApp2.Interfaces
{
    using Xamarin.Forms;

    using System.Threading.Tasks;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Services;

    public interface INavigationService
    {
        Task NavigateTo(ViewDescriptor viewDescriptor);

        Task NavigateTo(ViewDescriptor viewDescriptor, bool animated);

        Task<Page> GoBack();

        Task<Page> GoBack(bool animated);

        void RemovePage(Page page);

        ViewDescriptor GetTheNextPageViewDescriptor(ViewArgs viewArgs);

        ViewDescriptor GetMasterDetailsViewDescriptor();
    }
}
