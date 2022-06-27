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
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        IDbCRUD db;
        
        StudentModel student = new StudentModel();  
        public StudentAdd()
        {
        }
        public StudentAdd(IDbCRUD context)
        {
            InitializeComponent();

            db = context;
        }
        private void StudentAdd_loaded(object sender, RoutedEventArgs e)
        {
            var groupQuery = db.GetAllGroup().Where(p => p.ID == p.ID).Select(i => i.ID).ToList();
            var StudentQuery = db.GetAllLogStudent().Where(p => p.ID == p.ID).Select(i => i.ID).ToList();
            GroupIDComboBox.ItemsSource= groupQuery;
            UserIDComboBox.ItemsSource = StudentQuery;
        }

         private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            student.Name = StudentNameBox.Text; 
            student.GroupID = Convert.ToInt32(GroupIDComboBox.SelectedItem.ToString());
            student.UserID=Convert.ToInt32(UserIDComboBox.SelectedItem.ToString());
           db.CreateStudent(student);
            
      

        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void UserIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
