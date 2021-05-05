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
    public partial class FrmAPCMemo : Form
    {
        public OleDbDataAdapter ada = new OleDbDataAdapter();
        public OleDbCommandBuilder cmd = new OleDbCommandBuilder();
        public DataRow drow;
        public DataTable dt = new DataTable();


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

        private void fillSupplier()//Combo List Diff methord!
        {

            dt.Clear();
            ada = new OleDbDataAdapter("select * from Supplier", con);
            cmd = new OleDbCommandBuilder(ada);
            dt = new DataTable();
            cmd = new OleDbCommandBuilder(ada);
            ada.Fill(dt);



            comboBox1.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                comboBox1.Items.Add(dt.Rows[i]["SupplierName"].ToString());


        }

        private void fromDGView()
        {
            //   txtStNo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //   dtpDoMFR.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[19].Value);
        }

        private void DGViewSize()
        {
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[1].Width = 30;
            //dataGridView1.Columns[2].Width = 70;
            //if (lblULevel1.Text == "USER")
            //{
            //    dataGridView1.Columns[24].Visible = false;
            //    dataGridView1.Columns[25].Visible = false;
            //    dataGridView1.Columns[26].Visible = false;
            //    dataGridView1.Columns[27].Visible = false;
            //}
            //else
            //{
            //    dataGridView1.Columns[4].Visible = false;
            //    dataGridView1.Columns[25].Width = 45;
            //    dataGridView1.Columns[26].Width = 35;
            //    dataGridView1.Columns[27].Width = 45;
            //    dataGridView1.Columns[28].Width = 25;
            //}
        }
        public FrmAPCMemo()
        {
            InitializeComponent();
        }

        private void FrmAPCMemo_Load(object sender, EventArgs e)
        {
            //  lblUser1.Text = FrmMain.uname;
            // lblULevel1.Text = FrmMain.ul;
            // TxtSer_TextChanged(null, null);
            dt.Clear();
            ada = new OleDbDataAdapter("SELECT * FROM [Arinvoice] ", con);
            cmd = new OleDbCommandBuilder(ada);
            dt = new DataTable();
            cmd = new OleDbCommandBuilder(ada);
            ada.Fill(dt);
            //   dataGridView1.DataSource = dt;


            fillSupplier();
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                foreach (DataGridViewRow item in dataGridView1.Rows)
                {



                    if ((bool)item.Cells[0].Value == true)
                    {


                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }



                        OleDbCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;



                        cmd1.CommandText = "Insert into ApMemo(vender,namee,currencyy,invoiceno,DESCRIPTION,qty,CostPrice,jobNo,total,remarks,totbtax,nbt,vats,totalrdue) values('"
                              + comboBox1.Text + "', '" + txtName.Text + "', '" + txtCur.Text + "', '" + item.Cells[1].Value.ToString() + "','" + item.Cells[2].Value.ToString() + "', '" + item.Cells[3].Value.ToString() + "', '" + item.Cells[4].Value.ToString() + "', '"
                              + item.Cells[5].Value.ToString() + "', '" + item.Cells[6].Value.ToString() + "', '" + txtRem.Text + "', '" + txtTotBT.Text + "', '" + txtNBT.Text + "', '" + txtVS.Text + "', '" + txtTot.Text + "')";

                        cmd1.ExecuteNonQuery();



                    }


                }


                MessageBox.Show("Added");

            }
            catch (Exception x)
            {
                // MessageBox.Show("ERROR CODE : CMD-UPD-101-ACC-PAY" + "\n" + "\n" + "[Please Note this Error Code and Take a Photo in this More Details." + "\n" + "\n" + "Inform the Error Code and Send this Error Details (Mail or WhatsUP) to Development Team (SRIS)!]" + "\n" + "\n" + "\n" + "MORE DETAILS :- " + "\n" + "\n" + x, "MESSAGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //if (txtStNo.Text == "")
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
                    MessageBox.Show("ERROR CODE : SUP-KDW-135-APC-MEM" + "\n" + "\n" + "[Please Note this Error Code and Take a Photo in this More Details." + "\n" + "\n" + "Inform the Error Code and Send this Error Details (Mail or WhatsUP) to Development Team (SRIS)!]" + "\n" + "\n" + "\n" + "MORE DETAILS :- " + "\n" + "\n" + x, "MESSAGE BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt.Clear();
            ada = new OleDbDataAdapter("SELECT crycode,SupplierCode,ContactPerson FROM [Supplier] WHERE [SupplierName] = '" + comboBox1.Text + "'", con);

            dt = new DataTable();
            cmd = new OleDbCommandBuilder(ada);
            ada.Fill(dt);


            txtCur.Text = dt.Rows[0]["crycode"].ToString();
            txtName.Text = dt.Rows[0]["ContactPerson"].ToString();
            txtveco.Text = dt.Rows[0]["SupplierCode"].ToString();







            dt.Clear();

            ada = new OleDbDataAdapter("SELECT invoiceno FROM [Purchase] WHERE [SupplierCode] = '" + txtveco.Text + "'", con);

            dt = new DataTable();
            cmd = new OleDbCommandBuilder(ada);
            ada.Fill(dt);

            comboBox2.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)

                comboBox2.Items.Add(dt.Rows[i]["invoiceno"].ToString());









            fillSupplier();

            comboBox1.Text = comboBox1.SelectedText;


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {



                item.Cells[0].Value = false;


            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt.Clear();

            ada = new OleDbDataAdapter("SELECT invoiceno,DESCRIPTION,MinimumQTY,UnitCost,jobNo,totall FROM [StockItem] WHERE [invoiceno] = '" + comboBox2.Text + "'", con);

            dt = new DataTable();
            cmd = new OleDbCommandBuilder(ada);
            ada.Fill(dt);


            dataGridView1.DataSource = dt;



            foreach (DataGridViewRow item in dataGridView1.Rows)
            {



                item.Cells[0].Value = false;


            }
        }
    }
}
