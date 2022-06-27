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
using BLL.Models;
using BLL;
using BLL.Interfaces;
namespace Student_Management.View
{
    /// <summary>
    /// Interaction logic for UserAddWindow.xaml
    /// </summary>
    public partial class UserAddWindow : Window
    {
        IDbCRUD db;

      
        UserStudentModel student = new UserStudentModel();
        UserTeacherModel teacher = new UserTeacherModel();
        StudentModel st = new StudentModel();
        public UserAddWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel ad = new AdminPanel(db);
            var combo = UserTypeComboBox.Text;
            try
            {
                if(combo == "Student")
                {
                    student.StudentLogin = LoginBox.Text;
                    student.StudentPass = PasswordBox.Text;

                    //st.Name = NameUserBox.Text;
                 
                    db.CreateSUser(student);
                    ad.AdminDatagrid.UpdateLayout();
                    LoginBox.Clear();
                    PasswordBox.Clear(); 

                    if (student != null)
                        MessageBox.Show("User Added !");

                }
                else
                {
                    teacher.TeacherLogin = LoginBox.Text;
                    teacher.TeacherPass = PasswordBox.Text;
                    db.CreateTUser(teacher);
                    ad.AdminDatagrid.UpdateLayout();
                    LoginBox.Clear();
                    PasswordBox.Clear();
                    if (teacher != null)
                        MessageBox.Show("User Added !");

                }
              
              
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong");
            }

        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    
    }
}
