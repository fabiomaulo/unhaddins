using System;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier.Conversations
{
	[Serializable]
	public abstract class AbstractConversation : IConversation
	{
		private readonly IDictionary<string, object> context = new Dictionary<string, object>(5);
		private readonly string id;

		protected AbstractConversation() : this(Guid.NewGuid().ToString()) {}

		protected AbstractConversation(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentNullException("id", "Conversation Id is not optional; Use the empty Ctor if you don't have an available Id.");
			}
			this.id = id;
		}

		#region Implementation of IDisposable

		public void Dispose()
		{
			End();
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected abstract void Dispose(bool disposing);

		~AbstractConversation()
		{
			Dispose(false);
		}

		#endregion

		#region Implementation of IConversation

		public string Id
		{
			get { return id; }
		}

		public IDictionary<string, object> Context
		{
			get { return context; }
		}

		public bool AutoPause { get; set; }

		public bool AutoEnd { get; set; }

		public virtual void Start()
		{
			RaiseStarting();
			DoStart();
		}

		public virtual void Pause()
		{
			DoPause();
			RaisePaused();
		}

		public virtual void Resume()
		{
			RaiseResuming();
			DoResume();
		}

		public virtual void End()
		{
			DoEnd();
			RaiseEnded();
		}

		public event EventHandler<EventArgs> Starting;
		public event EventHandler<EventArgs> Paused;
		public event EventHandler<EventArgs> Resuming;
		public event EventHandler<EventArgs> Ended;

		protected abstract void DoStart();

		protected void RaiseStarting()
		{
			if (Starting != null)
			{
				Starting(this, new EventArgs());
			}
		}

		protected abstract void DoPause();

		protected void RaisePaused()
		{
			if (Paused != null)
			{
				Paused(this, new EventArgs());
			}
		}

		protected abstract void DoResume();

		protected void RaiseResuming()
		{
			if (Resuming != null)
			{
				Resuming(this, new EventArgs());
			}
		}

		protected abstract void DoEnd();

		protected void RaiseEnded()
		{
			if (Ended != null)
			{
				Ended(this, new EventArgs());
			}
		}

		#endregion

		public override bool Equals(object obj)
		{
			var that = obj as IConversation;
			return Equals(that);
		}

		public bool Equals(IConversation obj)
		{
			if (null == obj)
			{
				return false;
			}
			return ReferenceEquals(this, obj) || obj.Id.Equals(id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		#region Implementation of IEqualityComparer<IConversation>

		public bool Equals(IConversation x, IConversation y)
		{
			if(x == null && y == null)
			{
				return true;
			}
			if(x == null || y == null)
				return false;
			return x.Id.Equals(y.Id);
		}

		public int GetHashCode(IConversation obj)
		{
			return obj != null ? obj.Id.GetHashCode() : 0;
		}

		#endregion
	}
}