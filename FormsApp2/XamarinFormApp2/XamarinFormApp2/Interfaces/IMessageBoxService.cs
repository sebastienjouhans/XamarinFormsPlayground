using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormApp2.Interfaces
{
    using XamarinFormApp2.Commons;

    public interface IMessageBoxService
    {
        Task ShowMessageAsync(MessageBoxType messageBoxType);

        Task ShowMessageAsync(MessageBoxType messageBoxType, string title, string message);
    }
}
