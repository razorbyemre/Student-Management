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
using BLL.Interfaces;
using BLL.Models;
using BLL;
using Student_Management.View; 

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        IDbCRUD db;
        List<UserStudentModel> userStudents;       
        List<UserTeacherModel> userTeachers;      
        List<StudentModel> students;
        List<TeacherModel> teachers;
        public AdminPanel(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }



        private void AdminPanel_Loaded(object sender, RoutedEventArgs e)
        {
           
           
        }

        //List User Teacher
        private void ListUserTeacherbtn_Click(object sender, RoutedEventArgs e)
        {
            userTeachers = db.GetAllLogTeacher().ToList();

            AdminDatagrid.ItemsSource = userTeachers;
        }

        //List User Student
        private void ListUserStudentbtn_Click(object sender, RoutedEventArgs e)
        {
            userStudents = db.GetAllLogStudent().ToList();
            AdminDatagrid.ItemsSource = userStudents;
        }

        //List Student
        private void ListStudent_Click(object sender,RoutedEventArgs e)
        {
            students= db.GetAllStudents().ToList(); 
            AdminDatagrid.ItemsSource= students;    
        }

        //List Teacher
        private void ListTeacher_Click(object sender,RoutedEventArgs e)
        {
            teachers = db.GetTeachers().ToList();
            AdminDatagrid.ItemsSource =teachers;
        }
        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {

            LoginWindow login = new LoginWindow(db);
            login.Show();
            this.Close();
        }

        private void AddbtnStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentAdd studentAdd = new StudentAdd(db);
            studentAdd.Show();
        }
        private void AddbtnUser_Click(object sender, RoutedEventArgs e)
        {
            UserAddWindow userAddWindow = new UserAddWindow(db);
            userAddWindow.Show();
        }
        private void AddbtnTeacher_Click(object sender, RoutedEventArgs e)
        {
           TeacherAdd teacherAdd = new TeacherAdd(db); 
            teacherAdd.Show();  

        }
        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
          // db.DeleteUser(Convert.ToInt32(UserIDBox.Text));
           
        }

        private void AddFacultybtn_Click(object sender, RoutedEventArgs e)
        {
            InsertFacultyWindow facultyWindow = new InsertFacultyWindow(db);
            facultyWindow.Show();
        }
    }
}
