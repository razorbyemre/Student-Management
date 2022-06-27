using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
using BLL.Interfaces;
using BLL.Models;
namespace Student_Management
{
    /// <summary>
    /// Interaction logic for InsertFacultyWindow.xaml
    /// </summary>
    public partial class InsertFacultyWindow : Window
    {
        IDbCRUD db;
        FacultyModel Faculty = new FacultyModel();
        GroupModel group = new GroupModel();

        public InsertFacultyWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Faculty.FacultyName = FacultyBox.Text;
                db.CreateFaculty(Faculty);

                group.Group1 = GroupBox.Text;
                db.CreateGroup(group);

                if (Faculty != null && group != null)
                    MessageBox.Show("Added Succesfuly !");

                FacultyBox.Clear();
                GroupBox.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Someting went wrong !!");
            }
           
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
