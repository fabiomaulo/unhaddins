using System.Collections.Generic;
using System.Linq;
using ChinookMediaManager.Data;
using ChinookMediaManager.Domain.AppServicesInterfaces;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.Domain.Impl
{
	[PersistenceConversational]
	public class AlbumManagerModel : IAlbumManagerModel
	{
		private readonly IDao<Album> daoAlbum;
		private readonly IEntityValidator entityValidator;

		public AlbumManagerModel(IDao<Album> daoAlbum, IEntityValidator entityValidator)
		{
			this.daoAlbum = daoAlbum;
			this.entityValidator = entityValidator;
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public IEnumerable<Album> GetAlbumsToBrowse()
		{
			return daoAlbum.RetrieveAll().ToArray();
		}

		//The default [PersistenceConversation(ConversationEndMode = EndMode.Continue)]
		public Album GetAlbumById(int id)
		{
			return daoAlbum.Get(id);
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public void Save(Album album)
		{
			if(IsValid(album)) daoAlbum.MakePersistent(album);
		}

		[PersistenceConversation(ConversationEndMode = EndMode.Abort)]
		public void Cancel(Album album)
		{}

		[PersistenceConversation(Exclude = true)]
		public bool IsValid(Album album)
		{
			return entityValidator.IsValid(album);
		}
	}
}