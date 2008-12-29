﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SessionManagement.Domain
{
	public class PurchaseOrder : BaseEntity
	{
		public virtual string Number { get; set; }

		private DateTime date;

		public virtual DateTime Date
		{
			get { return date; }
			set { date = value.Date; }
		}

		public virtual bool IsNew
		{
			get { return Id == 0; }
		}

		private readonly IList<OrderLine> orderLines = new List<OrderLine>();

		public virtual IList<OrderLine> OrderLines
		{
			get { return new ReadOnlyCollection<OrderLine>(orderLines); }
		}

		public virtual void AddOrderLine(OrderLine orderLine)
		{
			if (!orderLines.Contains(orderLine))
			{
				orderLines.Add(orderLine);
				orderLine.Order = this;
			}
		}

		public virtual void RemoveOrderLine(OrderLine orderLine)
		{
			if (!orderLines.Contains(orderLine))
			{
				orderLines.Remove(orderLine);
				orderLine.Order = null;
			}
		}
	}
}