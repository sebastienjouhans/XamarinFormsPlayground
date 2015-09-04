namespace XamarinFormApp2.Services
{
    using System.IO;
    using System.Threading.Tasks;

    using PCLStorage;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Interfaces;

    public class StorageService : IStorageService
    {
        private readonly IJsonSerializer jsonSerializer;

        public StorageService(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
        }

        private async Task<bool> SaveFileAsync(StorageFolder storageFolder, StorageFile storageFile, FileType fileType, string content)
        {
            var rootFolder = FileSystem.Current.LocalStorage;

            var folder = await rootFolder.CreateFolderAsync(storageFolder.ToString(), CreationCollisionOption.OpenIfExists);

            if (folder == null)
            {
                return false;
            }

            var file = await folder.CreateFileAsync(string.Format(@"{0}.{1}", storageFile, fileType), CreationCollisionOption.ReplaceExisting);

            if (file == null)
            {
                return false;
            }

            await file.WriteAllTextAsync(content);

            return true;
        }

        private async Task<string> ReadFileAsync(StorageFolder storageFolder, StorageFile storageFile, FileType fileType)
        {
            var rootFolder = FileSystem.Current.LocalStorage;

            var folder = await rootFolder.GetFolderAsync(storageFolder.ToString());

            if (folder == null)
            {
                return null;
            }

            var file = await folder.GetFileAsync(string.Format(@"{0}.{1}", storageFile, fileType));

            if (file == null)
            {
                return null;
            }

            var stream = await file.OpenAsync(FileAccess.Read);

            if (stream == null)
            {
                return null;
            }

            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }

        public async Task<bool> SaveDataSettingAsync(User user)
        {
            var result = this.jsonSerializer.Serialize(user);

            if (result == null)
            {
                return false;
            }

            return await this.SaveFileAsync(StorageFolder.MyFolder, StorageFile.DataSettings, FileType.json, result).ConfigureAwait(false);
        }

        public async Task<User> GetDataSettingAsync()
        {
            var result = await this.ReadFileAsync(StorageFolder.MyFolder, StorageFile.DataSettings, FileType.json).ConfigureAwait(false);

            if (result == null)
            {
                return null;
            }

            return this.jsonSerializer.Deserialize<User>(result);
        }
    }
}
