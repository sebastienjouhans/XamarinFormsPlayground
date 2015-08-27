namespace XamarinFormApp2.Interfaces
{
    using System;

    using XamarinFormApp2.Commons;

    public interface IViewModel : IDisposable
    {
        ViewArgs ViewArgs { get; set; }
    }
}
