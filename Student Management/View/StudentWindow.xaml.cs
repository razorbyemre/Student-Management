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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        IDbCRUD db;
        List<MarkModel> marks = new List<MarkModel>();
        List<TypeMarkModel> tmark = new List<TypeMarkModel>();
        List<StudentModel> students = new List<StudentModel>();
        List<DisciplineModel> disciplines = new List<DisciplineModel>();
        List<UserStudentModel> userstudent = new List<UserStudentModel>();
        List<MessageModel> message = new List<MessageModel>();
        public int log;
        public StudentWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        public void UserValidator(int userlog)
        {
            log = userlog;
        }

        private void Student_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageWindow window = new MessageWindow();
            window.Show();  
        }
        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            message= db.GetMessages().ToList();
            StudentDatagrid.ItemsSource = message;
        }
        private void Markbtn_Click(object sender, RoutedEventArgs e)
        {


            marks = db.GetAllMarks();
            tmark = db.GetAllTypeMarks();
            students = db.GetAllStudents();
            disciplines = db.GetAllDiscipline();
            userstudent = db.GetAllLogStudent();

     

        

            var query = from _mark in marks // Uc tablonun birlesimi. MArk icindeki fk id lerle eslesen verileri cektik
                        join _tmark in tmark on _mark.TypeMarkID equals _tmark.ID
                        join _student in students on _mark.StudentID equals _student.ID
                        join _discipline in disciplines on _mark.DisciplineID equals _discipline.ID
                        select new
                        {
                            ID = _mark.ID, // Buradaki ID = ... column ismi
                            Student = _student.Name,
                            TypeMark = _tmark.TypeMark1,
                            Discipline = _discipline.DisciplineTitle,
                            Result = _mark.Result,

                        };


            StudentDatagrid.ItemsSource = query;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
