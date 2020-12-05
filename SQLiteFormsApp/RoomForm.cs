using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLiteFormsApp
{
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
            GridFill();
        }

        private void GridFill()
        {
            DataTable dt = new DataTable("Room");
            SQLiteDataAdapter da = Database.DataAdapt("SELECT (Name) FROM Room");

            da.Fill(dt);
            da.Update(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string RoomName = txtRoom.Text.Trim();

            if (RoomName == "")
            {
                MessageBox.Show("Fill all fields");
            }
            else if (RoomName.Length > 6)
            {
                MessageBox.Show("Name too long");
            }
            else
            {
                string sql = "INSERT INTO Room (Name) VALUES ('" + RoomName + "')";
                Database.ExecuteCommand(sql);

                txtRoom.Text = "";
                GridFill();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTablesForm frmEdit = new EditTablesForm();
            frmEdit.Show();
        }
    }
}
