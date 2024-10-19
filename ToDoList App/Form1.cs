using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

         DataTable todoList=new DataTable();
        bool isEditing=false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            //Point the datagridview to the datatable
            ToDoListView .DataSource = todoList;
        }

        private void newButtton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            descriptionBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //Text fields from the table
            titleBox.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionBox.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Title"]=titleBox.Text;
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = descriptionBox.Text;
            }
            else
            {
                todoList.Rows.Add(titleBox.Text, descriptionBox.Text);
            }

            //Clear the fields
            isEditing = false;
            titleBox.Text = "";
            descriptionBox.Text = "";
        }
    }
}
