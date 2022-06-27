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
    /// Interaction logic for LectureWindow.xaml
    /// </summary>
    public partial class LectureWindow : Window
    {
        IDbCRUD db;
        DisciplineModel discipline = new DisciplineModel();
        public LectureWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                discipline.DisciplineTitle = LectureBox.Text;
                db.CreateDiscipline(discipline);
                if (discipline != null)
                    MessageBox.Show("Lecture succesfuly added !");

                LectureBox.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! ");
            }
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
