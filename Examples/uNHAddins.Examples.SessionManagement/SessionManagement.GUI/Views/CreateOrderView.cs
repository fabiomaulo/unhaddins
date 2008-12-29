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
	public partial class CreateOrderView : UserControl, ICreateOrderView
	{
		private readonly IModifyOrderModel orderModel;

		#region Fields

		private CreateOrderPresenter presenter;

		#endregion

		#region C'tors

		public CreateOrderView()
		{
			InitializeComponent();
		}

		public CreateOrderView(IModifyOrderModel orderModel)
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

		public DateTime OrderDate
		{
			get { return dateTimePicker1.Value; }
		}

		public string OrderNumber
		{
			get { return NumberTextBox.Text; }
		}

		public void ShowLines(IList<OrderLine> lines)
		{
			orderLineBindingSource.DataSource = new BindingList<OrderLine>(lines);
		}

		#endregion

		#region Instance Methods

		private void InvokeAddButtonPressed(EventArgs e)
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
			InvokeAddButtonPressed(EventArgs.Empty);
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

		private event EventHandler addButtonPressed;
		private event EventHandler saveButtonPressed;
		private event EventHandler viewInitialized;

		#endregion

		#region ICreateOrderView Members

		public event EventHandler AddButtonPressed
		{
			add { addButtonPressed += value; }
			remove { addButtonPressed -= value; }
		}
		
		public event EventHandler SaveButtonPressed
		{
			add { saveButtonPressed += value; }
			remove { saveButtonPressed -= value; }
		}

		private void InvokeSaveButtonPressed(EventArgs e)
		{
			var saveButtonPressedHandler = saveButtonPressed;
			if (saveButtonPressedHandler != null)
			{
				saveButtonPressedHandler(this, e);
			}
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

		private void SaveButton_Click(object sender, EventArgs e)
		{
			InvokeSaveButtonPressed(EventArgs.Empty);
		}
	}
}