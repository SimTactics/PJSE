/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.PackedFiles.Wrapper;
using SimPe.Interfaces.Plugin;

namespace pjse
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	public class StrChooser : System.Windows.Forms.Form
	{
		#region Form variables
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.ListBox lbItemList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrChooser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

        public StrChooser(bool sortflag) : this() { this.sortflag = sortflag; }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region StrChooser
        private bool sortflag = false;

		public int Strnum(StrWrapper wrapper)
		{
			fill(wrapper);

			DialogResult dr = ShowDialog();
			Close();

			switch (dr)
			{
				case DialogResult.OK:
					if (lbItemList.SelectedIndex >= 0) return (int)((SimPe.Data.Alias)lbItemList.SelectedItem).Id;
					return -1;
				default:
					return -1;
			}
		}

		private void fill(StrWrapper wrapper)
		{
			this.lbItemList.Items.Clear();

			for (int i = 0; wrapper[1, i] != null; i++)
				lbItemList.Items.Add(new SimPe.Data.Alias((uint)i, wrapper[1, i].Title));

            lbItemList.Sorted = sortflag;
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StrChooser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbItemList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.Controls.Add(this.OK);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            //
            // OK
            //
            resources.ApplyResources(this.OK, "OK");
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Name = "OK";
            //
            // Cancel
            //
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Name = "Cancel";
            //
            // panel2
            //
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            //
            // lbItemList
            //
            resources.ApplyResources(this.lbItemList, "lbItemList");
            this.lbItemList.Name = "lbItemList";
            this.lbItemList.DoubleClick += new System.EventHandler(this.lbItemList_DoubleClick);
            //
            // StrChooser
            //
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.Cancel;
            this.Controls.Add(this.lbItemList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "StrChooser";
            this.ShowInTaskbar = false;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void lbItemList_DoubleClick(object sender, System.EventArgs e)
		{
			if (lbItemList.SelectedIndex >= 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

	}
}
