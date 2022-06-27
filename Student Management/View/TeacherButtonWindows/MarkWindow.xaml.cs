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
namespace Student_Management.TeacherButtonWindows
{
    /// <summary>
    /// Interaction logic for MarkWindow.xaml
    /// </summary>
    public partial class MarkWindow : Window
    {
        IDbCRUD db;
        List<StudentModel> student = new List<StudentModel>();
        List<DisciplineModel> discipline = new List<DisciplineModel>();
        List<TypeMarkModel> typeMark = new List<TypeMarkModel>();
        MarkModel mark = new MarkModel();

        public MarkWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)

        {
            db.CreateMark(mark);
            mark.StudentID = StudentCombo.SelectedIndex;
            mark.DisciplineID = LectureCombo.SelectedIndex;
            mark.TypeMarkID = TypeMarkCombo.SelectedIndex;
            mark.Result = Convert.ToInt32(MarkBox.Text);
            

            this.Close();

        }
       
        private void MarkWindow_Loaded(object sender, RoutedEventArgs e)
        {
            student = db.GetAllStudents().ToList();
            discipline = db.GetAllDiscipline().ToList();
            typeMark = db.GetAllTypeMarks().ToList();

            StudentCombo.ItemsSource = student;
            StudentCombo.DisplayMemberPath = "Name";
            StudentCombo.SelectedValuePath = "ID";
            StudentCombo.SelectedIndex = 0;

            LectureCombo.ItemsSource = discipline;
            LectureCombo.DisplayMemberPath = "DisciplineTitle";
            LectureCombo.SelectedValuePath = "ID";
            LectureCombo.SelectedIndex = 0;

            TypeMarkCombo.ItemsSource = typeMark;
            TypeMarkCombo.DisplayMemberPath = "TypeMark1";
            TypeMarkCombo.SelectedValuePath = "ID";
            TypeMarkCombo.SelectedIndex = 0;





        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
