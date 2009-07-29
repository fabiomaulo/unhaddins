using System.ComponentModel;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Presenters.ModelInterfaces
{
    public interface IEditableAlbum : IAlbum, IEditableObject, INotifyPropertyChanged
    {}
}