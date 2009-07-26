using System;
using System.Collections.Generic;
using uNhAddIns.Entities;

namespace ChinookMediaManager.Domain
{
    public class Album : Entity
    {
        public virtual Artist Artist { get;  set; }
        public virtual string Title { get; set; }

        public virtual IList<Track> Tracks { get; private set; }

        public virtual void AddTrack(Track track)
        {
            track.Album = this;
            Tracks.Add(track);
        }

        public Album()
        {
            Tracks = new List<Track>();
        }
    }
}