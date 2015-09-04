namespace XamarinFormApp2.Interfaces
{
    using System.Threading.Tasks;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Entities;

    public interface IStorageService
    {
        Task<bool> SaveDataSettingAsync(User user);

        Task<User> GetDataSettingAsync();
    }
}
