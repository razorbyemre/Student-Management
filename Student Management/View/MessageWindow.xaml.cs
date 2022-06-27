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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        IDbCRUD db;

        MessageModel message = new MessageModel();
        public MessageWindow() { }
        public MessageWindow(IDbCRUD context)
        {
            db = context;
            InitializeComponent();
        }

        private void Send_Message_Click(object sender, RoutedEventArgs e)
        {
            message.Message1 = MessagesBox.Text;
            message.To= ToBox.Text;
            db.CreateMessage(message);

            if(MessagesBox.Text != null)
            {
                MessagesBox.Clear();
                MessageBox.Show("Message Sent! ");
            }
            else
            {
                MessageBox.Show("Something went wrong ! ");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
