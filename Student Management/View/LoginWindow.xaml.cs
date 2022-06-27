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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Interfaces;
using BLL.Models;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IDbCRUD db;

        public LoginWindow() { }
        public LoginWindow(IDbCRUD context)
        {
            InitializeComponent();
            db = context;
        }

        private void LoginWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string log = Logbox.Text;
            string pass = Passbox.Password;

            TeacherPanel teacher = new TeacherPanel(db);
            StudentWindow student = new StudentWindow(db);
            AdminPanel adminPanel = new AdminPanel(db);



            var userStudent = db.GetAllLogStudent()
                .Where(x => x.StudentLogin == log && x.StudentPass == pass).FirstOrDefault();
            var userTeacher = db.GetAllLogTeacher()
                .Where(x => x.TeacherLogin == log && x.TeacherPass == pass).FirstOrDefault();
            StudentWindow sw = new StudentWindow(db);
            //teacher.Show();
            //student.Show();

            //int valid = int.Parse(Logbox.Text);


            try
            {
              

                if (Logbox.Text == "admin" && Passbox.Password == "admin")
                {
                    adminPanel.Show();


                }
                else if (userStudent != null)
                {
                    
                   // sw.UserValidator(valid);
                    student.Show();
                   


                }

                else if (userTeacher != null)
                {

                    teacher.Show();

                }

                else
                {
                    MessageBox.Show("Login or Password not correct ! ");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong !");

            }

            this.Close();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }


}
