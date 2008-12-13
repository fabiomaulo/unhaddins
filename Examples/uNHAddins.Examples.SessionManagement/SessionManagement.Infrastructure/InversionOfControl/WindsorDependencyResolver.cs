﻿using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.Windsor;

namespace SessionManagement.Infrastructure.InversionOfControl
{
	public class WindsorDependencyResolver : IDependencyResolver
	{
		private readonly IWindsorContainer underlyingContainer;
		private readonly IDictionary<LifeStyle, LifestyleType> lifeStyleTranslation = new Dictionary<LifeStyle, LifestyleType>();

		public WindsorDependencyResolver(IWindsorContainer underlyingContainer)
		{
			this.underlyingContainer = underlyingContainer;
			CreateLifeStyleTranslation();
		}

		private void CreateLifeStyleTranslation()
		{
			lifeStyleTranslation[LifeStyle.Singleton] = LifestyleType.Singleton;
			lifeStyleTranslation[LifeStyle.Transient] = LifestyleType.Transient;
		}

		#region IDependencyResolver Members

		public void Dispose()
		{
			underlyingContainer.Dispose();
		}

		public T Resolve<T>()
		{
			return underlyingContainer.Resolve<T>();
		}

		public void RegisterImplementationOf(string id, Type service, Type implementation, LifeStyle lifeStyle)
		{
			underlyingContainer.AddComponentLifeStyle(id, service, implementation, lifeStyleTranslation[lifeStyle]);
		}

		public void RegisterImplementationOf(string id, Type service, Type implementation)
		{
			underlyingContainer.AddComponent(id, service, implementation);
		}

		#endregion
	}
}
