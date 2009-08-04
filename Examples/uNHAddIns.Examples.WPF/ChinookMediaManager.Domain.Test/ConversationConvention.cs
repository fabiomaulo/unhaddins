using System;
using uNhAddIns.SessionEasier.Conversations;

namespace ChinookMediaManager.Domain.Test
{
    public class ConversationObserver<TModel> : 
        IConversationCreationInterceptorConvention<TModel> where TModel : class
    {
        private IConversation _lastConversation;

        #region IConversationCreationInterceptorConvention<TModel> Members

        //public IConversation LastConversation
        //{
        //    get { return _lastConversation; }
        //}

        /// <summary>
        /// Configure a new fresh conversation.
        /// </summary>
        /// <param name="conversation">The new conversation.</param>
        public void Configure(IConversation conversation)
        {
            conversation.Ended += InvokeEnded;
            conversation.Ending += InvokeEnding;
            conversation.Paused += InvokePaused;
            conversation.Aborting += InvokeAborting;
        }

        #endregion

        public event EventHandler<EventArgs> Starting;
        public event EventHandler<EventArgs> Started;
        public event EventHandler<EventArgs> Pausing;
        public event EventHandler<EventArgs> Paused;

        private void InvokePaused(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = Paused;
            if (handler != null) handler(sender, e);
        }

        public event EventHandler<EventArgs> Resuming;
        public event EventHandler<EventArgs> Resumed;
        public event EventHandler<EventArgs> Ending;

        private void InvokeEnding(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = Ending;
            if (handler != null) handler(sender, e);
        }

        public event EventHandler<EventArgs> Aborting;

        private void InvokeAborting(object seder, EventArgs e)
        {
            EventHandler<EventArgs> aborting = Aborting;
            if (aborting != null) aborting(seder, e);
        }

        public event EventHandler<EndedEventArgs> Ended;

        private void InvokeEnded(object sender, EndedEventArgs e)
        {
            EventHandler<EndedEventArgs> handler = Ended;
            if (handler != null) handler(sender, e);
        }

        public event EventHandler<OnExceptionEventArgs> OnException;
    }
}