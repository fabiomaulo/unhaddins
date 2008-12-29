#region usings

using System;
using System.Windows.Forms;
using SessionManagement.Domain;
using SessionManagement.Domain.Model;
using SessionManagement.Presentation.Presenters;
using SessionManagement.Presentation.ViewInterfaces;

#endregion

namespace SessionManagement.GUI.Views
{
	public partial class CreateOrderView : UserControl, ICreateOrderView
	{
		#region Readonly & Static Fields

		private readonly IOrderModel orderModel;

		#endregion

		#region Fields

		private CreateOrderPresenter presenter;

		#endregion

		#region C'tors

		public CreateOrderView()
		{
			InitializeComponent();
		}

		public CreateOrderView(IOrderModel orderModel)
			: this()
		{
			this.orderModel = orderModel;
		}

		#endregion

		#region Instance Properties

		public string Number
		{
			get { return NumberTextBox.Text; }
		}


		#endregion

		#region Instance Methods


		private void InvokeAddButtonPressed(TEventArgs<PurchaseOrder> e)
		{
			var addButtonPressedHandler = addButtonPressed;
			if (addButtonPressedHandler != null) addButtonPressedHandler(this, e);
		}

		private void InvokeViewInitialized(EventArgs e)
		{
			var viewInitializedHandler = viewInitialized;
			if (viewInitializedHandler != null) viewInitializedHandler(this, e);
		}

		#endregion

		#region Event Handling

		private void AddButton_Click(object sender, EventArgs e)
		{
			var order = GetOrder();
			InvokeAddButtonPressed(new TEventArgs<PurchaseOrder>(order));
		}

		private PurchaseOrder GetOrder()
		{
			return orderModel.FindOrderOrCreateNew();
		}

		private DateTime OrderDate
		{
			get { return dateTimePicker1.Value; }
		}

		private string OrderNumber
		{
			get { return NumberTextBox.Text; }
		}

		private void AddProductView_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				presenter = new CreateOrderPresenter(this, orderModel);
				InvokeViewInitialized(EventArgs.Empty);
			}
		}

		#endregion

		#region Event Declarations

		private event EventHandler<TEventArgs<PurchaseOrder>> addButtonPressed;
		private event EventHandler viewInitialized;

		#endregion

		#region IAddProductView Members

		public event EventHandler<TEventArgs<PurchaseOrder>> AddButtonPressed
		{
			add { addButtonPressed += value; }
			remove { addButtonPressed -= value; }
		}

		public void Clean()
		{
			NumberTextBox.Text = string.Empty;
			NumberTextBox.Focus();
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		public event EventHandler ViewInitialized
		{
			add { viewInitialized += value; }
			remove { viewInitialized -= value; }
		}

		#endregion
	}
}