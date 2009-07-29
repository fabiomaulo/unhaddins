using System.Collections.Generic;
using uNhAddIns.Entities;

namespace ChinookMediaManager.Domain
{
    public interface IAlbum : IEntity
    {
        Artist Artist { get; set; }
        string Title { get; set; }
        IList<Track> Tracks { get; }
    }
}