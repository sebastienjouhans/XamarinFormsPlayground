namespace XamarinFormApp2.Interfaces
{
    using Xamarin.Forms;

    using System.Threading.Tasks;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Services;

    public interface INavigationService
    {
        Task NavigateToAsync(ViewDescriptor viewDescriptor);

        Task NavigateToAsync(ViewDescriptor viewDescriptor, bool animated);

        Task<Page> GoBackAsync();

        Task<Page> GoBackAsync(bool animated);

        void RemovePage(Page page);
        
        Task PushModalAsync(Page page, bool animated);

        Task PushModalAsync(Page page);

        ViewDescriptor GetTheNextPageViewDescriptor(ViewArgs viewArgs);

        ViewDescriptor GetThreeDTextViewDescriptor();

        ViewDescriptor GetListPageViewDescriptor();

        ViewDescriptor GetStoragePageViewDescriptor();

    }
}
