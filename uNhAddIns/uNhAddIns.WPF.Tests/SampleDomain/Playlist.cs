﻿using Iesi.Collections.Generic;
using uNhAddIns.Entities;
using uNhAddIns.WPF.Collections;

namespace uNhAddIns.WPF.Tests.SampleDomain
{
    public class Playlist : Entity
    {
        public Playlist()
        {
            Tracks = new ObservableSet<Track>();
        }

        public virtual string Name { get; set; }

        public virtual ISet<Track> Tracks { get; private set; }

        public virtual void AddTrack(Track track)
        {
            Tracks.Add(track);
        }
    }
}