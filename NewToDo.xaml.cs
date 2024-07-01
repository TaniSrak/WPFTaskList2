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

namespace WPFTaskList2
{
    /// <summary>
    /// Логика взаимодействия для NewToDo.xaml
    /// </summary>
    public partial class NewToDo : Window
    {
        MainWindow main;
        public NewToDo()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);

            MainWindow main = (this.Owner as MainWindow);
            this.main = main;
        }

        private void AddJob(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).ToDoList.Add(new src.ToDo(titleToDo.Text, descriptionToDo.Text, dateToDo.SelectedDate.Value));

            titleToDo.Text = "";
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);

            (this.Owner as MainWindow).listToDo.Items.Refresh();

            this.Close();
        }
    }
}
