using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIC0378
{
    public partial class Form1 : Form
    {
        private UserList userList = new UserList();
        private User selectedUser = new User();

        public Form1()
        {
            InitializeComponent();
        }

        private void addB_Click(object sender, EventArgs e)
        {          
            try
            {             
                User user = new User();
                user.Id = Convert.ToInt32(idTB.Text);
                user.Name = Convert.ToString(nameTB.Text);
                bool? adult;
                if (adultRB1.Checked == true)
                {
                    adult = true;
                }
                else
                {
                    adult = false;
                }
                user.Adult = adult;
                this.userList.Add(user);

                resetAdd();
                refreshGrid();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void editB_Click(object sender, EventArgs e)
        {            
            try
            {
                int? id = Convert.ToInt32(idTB.Text);
                string name = nameTB.Text;
                bool? adult;
                if (adultRB1.Checked == true)
                {
                    adult = true;
                }
                else
                {
                    adult = false;
                }

                this.selectedUser = this.userList.Get(dataGridView1.CurrentRow.Index);
                this.userList.Remove(selectedUser);
                User user = new User();
                if (int.TryParse(idTB.Text, out int parsedId))
                {
                    user.Id = parsedId;
                }
                user.Name = name;
                user.Adult = adult;
                this.userList.Add(user);
                refreshGrid();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void deleteB_Click(object sender, EventArgs e)
        {            
            try
            {
                this.selectedUser = this.userList.Get(dataGridView1.CurrentRow.Index);
                this.userList.Remove(selectedUser);
                refreshGrid();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DeleteAllB_Click(object sender, EventArgs e)
        {
            this.userList.Clear();
            refreshGrid();
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Information";
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Adult");
            ds.Tables.Add(dt);
            for (int i = 0; i < this.userList.Count; i++)
            {
                DataRow row = ds.Tables["Information"].NewRow();
                row["ID"] = this.userList.Get(i).Id;
                row["Name"] = this.userList.Get(i).Name;
                row["Adult"] = this.userList.Get(i).Adult;
                ds.Tables["Information"].Rows.Add(row);
            }
            ds.WriteXml("file.xml");
            MessageBox.Show("The file was saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadB_Click(object sender, EventArgs e)
        {   
            try
            {
                this.userList.Clear();
                DataSet ds = new DataSet();
                ds.ReadXml("file.xml");
                dataGridView1.Rows.Clear();
                foreach (DataRow item in ds.Tables["Information"].Rows)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(item[0]);
                    user.Name = Convert.ToString(item[1]);
                    user.Adult = Convert.ToBoolean(item[2]);
                    this.userList.Add(user);
                }
                refreshGrid();
                MessageBox.Show("The file was loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void resetAdd()
        {
            idTB.Text = "";
            nameTB.Text = "";
            adultRB1.Checked = true;
            adultRB2.Checked = false;
        }

        private void refreshGrid()
        {
            this.userList.Sort();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < this.userList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = this.userList.Get(i).Id;
                dataGridView1.Rows[i].Cells[1].Value = this.userList.Get(i).Name;
                dataGridView1.Rows[i].Cells[2].Value = this.userList.Get(i).Adult;
            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idTB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                nameTB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "True")
                {
                    adultRB1.Checked = true;
                    adultRB2.Checked = false;
                }
                else
                {
                    adultRB1.Checked = false;
                    adultRB2.Checked = true;
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
    }
}
