using BLL.Interfaces;
using BLL.Models;
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

namespace Student_Management.View
{
    /// <summary>
    /// Interaction logic for TeacherAdd.xaml
    /// </summary>
    public partial class TeacherAdd : Window
    {
        IDbCRUD db;
        TeacherModel teacher = new TeacherModel();

        public TeacherAdd() { }

        public TeacherAdd(IDbCRUD context)
        {
            InitializeComponent();
            db = context;
        }
        private void TeacherAdd_Loaded(object sender, RoutedEventArgs e)
        {
            var TeacherQuery = db.GetAllLogTeacher().Where(p => p.ID == p.ID).Select(i => i.ID).ToList();
            UserIDComboBox.ItemsSource = TeacherQuery;

        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            teacher.Name = TeacherNameBox.Text;
            teacher.UserID=Convert.ToInt32(UserIDComboBox.SelectedItem.ToString());
            db.CreateTeacher(teacher);
            

        }
    }
}
