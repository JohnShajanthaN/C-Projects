﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace WindowsFormsERP
{
    public partial class FrmAPInv : Form
    {
        public static string uname = "";
        public static string ul = "";
        int count = 0;
        int found1 = 0;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\InvDatabase.mdb");
        private void Blank()
        {
            //  txtDes.Text = "";            
            //  dtpDoMFR.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //  picImg.Image = null;
            //TxtSer.Text = "";
            //  TxtSer_TextChanged(null, null);
        }

        private void fromDGView()
        {
            //   txtStNo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //   dtpDoMFR.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[19].Value);
        }

        private void DGViewSize()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 30;
            dataGridView1.Columns[2].Width = 70;
            //if (lblULevel1.Text == "USER")
            //{
            //    dataGridView1.Columns[24].Visible = false;
            //    dataGridView1.Columns[25].Visible = false;
            //}
            //else
            //{
            //    dataGridView1.Columns[4].Visible = false;
            //    dataGridView1.Columns[25].Width = 45;
            //}
        }
        public FrmAPInv()
        {
            InitializeComponent();
        }

        private void dtpDuDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmAPInv_Load(object sender, EventArgs e)
        {
            //  lblUser1.Text = FrmMain.uname;
            // lblULevel1.Text = FrmMain.ul;
            // TxtSer_TextChanged(null, null);
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                /////////////////ADD *********************************************
                //  OleDbCommand cmd = new OleDbCommand("Insert into Item(StNo, Des) values('"
                //      + txtStNo.Text + "', '"  + dtpDOE.Value.ToString() + "', '" + txtMin.Text.ToString() + "')", con);

                //////////////////EDIT ******************************************************
                //  OleDbCommand cmd = new OleDbCommand("Update Item SET StNo='" + txtStNo.Text + "', DOE='" + dtpDOE.Value.ToString() + "', Min1='" + txtMin.Text.ToString()
                //      + "' WHERE ID=" + dataGridView1.SelectedRows[0].Cells[0].Value + " ", con);

                con.Open();
                //  cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added Sucessfully!", "MESSAGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  txtStNo.Text = "";
                Blank();
                //   txtStNo.Focus();
            }
            catch (Exception x)
            {
                MessageBox.Show("ERROR CODE : CMD-UPD-101-ACC-PAY" + "\n" + "\n" + "[Please Note this Error Code and Take a Photo in this More Details." + "\n" + "\n" + "Inform the Error Code and Send this Error Details (Mail or WhatsUP) to Development Team (SRIS)!]" + "\n" + "\n" + "\n" + "MORE DETAILS :- " + "\n" + "\n" + x, "MESSAGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //if (txtVen.Text == "")
                    //{
                    //    MessageBox.Show("Please Enter the Data!", "Invalid Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //    found1 = 0;
                    //    for (int i = 0; i < count; i++)
                    //    {
                    //        dataGridView1.ClearSelection();
                    //        dataGridView1.Rows[i].Selected = true;
                    //        if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() == txtStNo.Text)
                    //        {
                    //            string txt = "SELECT * FROM [Item] Where id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + " ";
                    //            OleDbDataAdapter da = new OleDbDataAdapter(txt, con);
                    //            DataSet ds = new DataSet();
                    //            da.Fill(ds);
                    //            found1 = 1;
                    //            fromDGView();
                    //            byte[] Photo = (byte[])(ds.Tables[0].Rows[0]["IImg"]);
                    //            MemoryStream ms = new MemoryStream(Photo);
                    //            picImg.Image = Image.FromStream(ms);
                    //        }
                    //    }
                    //    txtDes.Focus();
                    //    if (found1 == 0)
                    //    {
                    //        Blank();
                    //    }
                    //}
                }
                catch (Exception x)
                {
                    MessageBox.Show("ERROR CODE : VEN-KWN-144-ACC-PAY" + "\n" + "\n" + "[Please Note this Error Code and Take a Photo in this More Details." + "\n" + "\n" + "Inform the Error Code and Send this Error Details (Mail or WhatsUP) to Development Team (SRIS)!]" + "\n" + "\n" + "\n" + "MORE DETAILS :- " + "\n" + "\n" + x, "MESSAGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please Enter the Data!", "Invalid Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //comKW.Focus();
                }
            }
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVS_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAPInv_Activated(object sender, EventArgs e)
        {

        }

        private void FrmAPInv_ClientSizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmAPInv_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
