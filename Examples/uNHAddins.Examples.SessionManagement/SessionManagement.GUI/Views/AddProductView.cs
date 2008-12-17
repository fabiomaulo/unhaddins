using System.Windows.Forms;
using SessionManagement.Domain.Model;
using SessionManagement.Presentation.Presenters;
using SessionManagement.Presentation.ViewInterfaces;

namespace SessionManagement.GUI.Views
{
	public partial class AddProductView : UserControl, IAddProductView
	{
		private AddProductPresenter presenter;
		private readonly IProductModel productModel;

		public AddProductView()
		{
			InitializeComponent();
		}

		public AddProductView(IProductModel productModel) : this()
		{
			this.productModel = productModel;
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void AddButton_Click(object sender, System.EventArgs e)
		{
			presenter.CreateNewProduct();
		}

		private void AddProductView_Load(object sender, System.EventArgs e)
		{
			if (!DesignMode)
			{
				presenter = new AddProductPresenter(this, productModel);
				CodeTextBox.Focus();
			}
		}

		#region IAddProductView Members

		public string Code
		{
			get { return CodeTextBox.Text; }
		}

		public string Description
		{
			get { return DescriptionTextBox.Text; }
		}

		public double Price
		{
			get
			{
				double price;

				return double.TryParse(PriceTextBox.Text, out price) 
							? price 
							: 0.0;
			}
		}

		public void Clean()
		{
			CodeTextBox.Text = string.Empty;
			DescriptionTextBox.Text = string.Empty;
			PriceTextBox.Text = string.Empty;
			CodeTextBox.Focus();
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		#endregion
	}
}