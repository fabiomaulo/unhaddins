using System.Windows.Forms;

namespace SessionManagement.GUI.Views
{
	public partial class PopupForm : Form
	{
		private readonly Control view;

		public PopupForm()
		{
			InitializeComponent();
		}

		public PopupForm(Control view) : this()
		{
			this.view = view;
			ClientSize = this.view.Size;
			this.view.Dock = DockStyle.Fill;
			Controls.Add(this.view);
		}
	}
}
