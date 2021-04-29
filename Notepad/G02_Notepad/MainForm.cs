using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G02_Notepad {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		private string _filePath = null;

		private void setBackgroundToolStripMenuItem_Click(object sender, EventArgs e) {
			colorDialog.Color = txtContent.BackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				txtContent.BackColor = colorDialog.Color;
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				txtContent.Text = openFileDialog.FileName;
			}
		}

		private void selectAll_Click(object sender, EventArgs e) {
			txtContent.SelectAll();
		}

		private void paste_Click(object sender, EventArgs e) {
			txtContent.Paste();
		}

		private void copy_click(object sender, EventArgs e) {
			txtContent.Copy();
		}

		private void undo_Click(object sender, EventArgs e) {
			txtContent.Undo();
		}

		private void cut_Click(object sneder, EventArgs e) {
			txtContent.Cut();
		}

		private void newDocument_Click(object sender, EventArgs e) {
			_filePath = null;
			txtContent.Text = "";
		}

		private void open_Click(object sender, EventArgs e) {
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				txtContent.Text = File.ReadAllText(openFileDialog.FileName);
				//using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
				//	txtContent.Text = sr.ReadToEnd();
				//	_filePath = openFileDialog.FileName;
				//}
			}
		}

		private void exit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void saveAs_Click(object sender, EventArgs e) //Needs try catch
		{
			SaveFile(true);
		}

		private void save_Click(object sender, EventArgs e) {
			SaveFile();
		}

		private bool SaveFile(bool saveAs = false) {
			if (saveAs || _filePath == null) {
				if (saveFileDialog.ShowDialog() == DialogResult.OK) {
					_filePath = saveFileDialog.FileName;
				} else {
					return false;
				}
			}
			
			File.WriteAllText(saveFileDialog.FileName, txtContent.Text);
			return true;
		}
	}
}
