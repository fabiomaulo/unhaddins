#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SessionManagement.Domain;
using SessionManagement.Domain.Model;
using SessionManagement.Presentation.Presenters;
using SessionManagement.Presentation.ViewInterfaces;

#endregion

namespace SessionManagement.GUI.Views
{
	public partial class BrowseProductsView : UserControl, IBrowseProductsView
	{
		#region Readonly & Static Fields

		private readonly IProductModel productModel;

		#endregion

		#region Fields

		private BrowseProductsPresenter presenter;
		private EventHandler viewInitialized;

		#endregion

		#region C'tors

		public BrowseProductsView()
		{
			InitializeComponent();
		}

		public BrowseProductsView(IProductModel productModel)
			: this()
		{
			this.productModel = productModel;
		}

		#endregion

		#region Instance Methods

		private void InvokeViewInitialized(EventArgs e)
		{
			EventHandler viewInitializedHandler = viewInitialized;
			if (viewInitializedHandler != null) viewInitializedHandler(this, e);
		}

		#endregion

		#region Event Handling

		private void BrowseProductsView_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				presenter = new BrowseProductsPresenter(this, productModel);
				InvokeViewInitialized(EventArgs.Empty);
			}
		}

		#endregion

		#region IBrowseProductsView Members

		public void Clean()
		{
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		public Product SelectedProduct
		{
			get
			{
				if (dataGridView1.CurrentRow != null)
				{
					return productBindingSource[dataGridView1.CurrentRow.Index] as Product;
				}

				return null;
			}
		}

		public void SetProducts(IList<Product> products)
		{
			productBindingSource.DataSource = new BindingList<Product>(products);
		}

		public event EventHandler ViewInitialized
		{
			add { viewInitialized += value; }
			remove { viewInitialized -= value; }
		}

		#endregion
	}
}