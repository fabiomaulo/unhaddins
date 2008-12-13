using System.Windows.Forms;
using SessionManagement.Presentation.Presenters;
using SessionManagement.Presentation.ViewInterfaces;

namespace SessionManagement.GUI.Views
{
	public partial class AddProductView : UserControl, IAddProductView
	{
		private Presenter<IAddProductView> presenter;

		public AddProductView()
		{
			InitializeComponent();
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

		}

		private void AddProductView_Load(object sender, System.EventArgs e)
		{
			if (!DesignMode)
			{
				presenter = new Presenter<IAddProductView>(this);

			}
		}
	}
}
