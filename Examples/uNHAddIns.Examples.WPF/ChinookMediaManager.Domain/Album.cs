using System.Collections.Generic;
using NHibernate.Validator.Constraints;
using uNhAddIns.Entities;

namespace ChinookMediaManager.Domain
{
    public class Album : Entity
    {
        public Album()
        {
            Tracks = new List<Track>();
        }

        #region IAlbum Members

        public virtual Artist Artist { get; set; }

        [NotNullNotEmpty]
        public virtual string Title { get; set; }

        public virtual IList<Track> Tracks { get; private set; }

        public virtual void AddTrack(Track track)
        {
            track.Album = this;
            Tracks.Add(track);
        }

        public virtual void RemoveTrack(Track track)
        {
            track.Album = null;
            Tracks.Remove(track);
        }

        #endregion
    }
}