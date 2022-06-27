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
using Student_Management.TeacherButtonWindows;
namespace Student_Management
{
    /// <summary>
    /// Interaction logic for TeacherPanel.xaml
    /// </summary>
    public partial class TeacherPanel : Window
    {
        IDbCRUD db;

        // List<UserModel> user = new List<UserModel>();
        List<MarkModel> marks = new List<MarkModel>();
        List<StudentModel> students = new List<StudentModel>();
        List<DisciplineModel> disciplins = new List<DisciplineModel>();
        List<TypeMarkModel> typeMarks = new List<TypeMarkModel>();
        List<MessageModel> message = new List<MessageModel>();

        public TeacherPanel(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }


        private void Panel_Loaded(object sender, RoutedEventArgs e)
        {
            //query de hata almamak icin verilerimizi once veritabanindan cekiyoruz. 
            marks = db.GetAllMarks().ToList();
            students = db.GetAllStudents().ToList();
            disciplins = db.GetAllDiscipline().ToList();
            typeMarks = db.GetAllTypeMarks().ToList();

            var query = from _mark in marks // Uc tablonun birlesimi. MArk icindeki fk id lerle eslesen verileri cektik
                        join _tmark in typeMarks on _mark.TypeMarkID equals _tmark.ID
                        join _student in students on _mark.StudentID equals _student.ID
                        join _discipline in disciplins on _mark.DisciplineID equals _discipline.ID
                        select new
                        {
                            ID = _mark.ID, // Buradaki ID = ... column ismi
                            Student = _student.Name,
                            TypeMark= _tmark.TypeMark1,
                            Discipline = _discipline.DisciplineTitle,
                            Result = _mark.Result,
                                                                               
                        };

            TeacherGrid.ItemsSource = query.ToList();
            
        }
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageWindow window = new MessageWindow();
            window.Show();
        }
        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            message = db.GetMessages().ToList();
            TeacherGrid.ItemsSource = message;
        }

        private void ListStudents_Click(object sender , RoutedEventArgs e )
        {
            students = db.GetAllStudents().ToList();
            TeacherGrid.ItemsSource=students;

        }
        private void ListDisciplins_Click(object sender, RoutedEventArgs e)
        {
            disciplins = db.GetAllDiscipline().ToList();
            TeacherGrid.ItemsSource = disciplins; 
        }

        private void InsertLectureBtn_Click(object sender, RoutedEventArgs e)
        {
            LectureWindow lectureWindow = new LectureWindow(db);
            lectureWindow.Show();

        }

        private void InsertMarkBtn_Click(object sender, RoutedEventArgs e)
        {
            MarkWindow markWindow = new MarkWindow(db);
            markWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
