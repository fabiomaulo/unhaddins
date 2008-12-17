using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SessionManagement.GUI.Views;
using SessionManagement.Infrastructure.InversionOfControl;

namespace SessionManagement.GUI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MenuItem_Click(object sender, EventArgs e)
		{
			var toolStripItem = sender as ToolStripItem;
			if (toolStripItem != null && toolStripItem.Tag != null)
			{
				var key = toolStripItem.Tag.ToString();
				ShowView(key);
			}
		}

		private void ShowView(string key)
		{
			using (var form = new PopupForm((Control) IoC.Resolve(key)))
			{
				form.ShowDialog();
			}
		}

		private void createToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var cfg = new Configuration().Configure();
			new SchemaExport(cfg).Create(false, true);
		}

		private void dropToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var cfg = new Configuration().Configure();
			new SchemaExport(cfg).Drop(false, true);
		}
	}
}
