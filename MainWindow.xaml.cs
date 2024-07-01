using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFTaskList2.src;

namespace WPFTaskList2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> ToDoList;
        public MainWindow()
        {
            InitializeComponent();

            ToDoList = new List<ToDo>();

            ToDoList.Add(new ToDo("Дело 1", "Описание", new DateTime(2024, 01, 10)));
            ToDoList.Add(new ToDo("Дело 1", "Описание", new DateTime(2024, 01, 10)));
            ToDoList.Add(new ToDo("Дело 1", "Описание", new DateTime(2024, 01, 10)));

            listToDo.ItemsSource = ToDoList;
        }

        private void DeleteJob (object sender, RoutedEventArgs e)
        {
            ToDoList.Remove(listToDo.SelectedItem as ToDo);
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoList;
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            NewToDo newToDo = new NewToDo();
            newToDo.Owner = this;
            newToDo.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                (listToDo.SelectedItem as ToDo).Done = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                (listToDo.SelectedItem as ToDo).Done = false;
            }
        }

        
    }


    // Стили Style - это коллекция значений свойств, которые могут применяться к элементу.
    // Система стилей впф играет ту же роль, ктору. играет стандарт каскадных таблиц стилей (CCS) в HTML разметке.
    // 
    //Ключевые свойства
    // setterss - коллекция объектов, которые позволяют автоматически изменять натсройки стиля. Настройки стиля могут модифицироваться, например, при изменении значения
    // какого-то др свойтва или при поступлении какого-нибудь события
    // triggers - коллекция объектов, которы епозволяют автоматически изменять настройки стиля. Настройки стиля могут модифицироваться, например, при измнении значения какого-то другого
    // свойства или при поступлении какого-нибудь события
    // Resources - коллекция ресурсов, которые должны использоваться со стилямию
    // Base - свойства, кот позвоялет создавать более специализированный стиль, наследующий параметры др стиля
    // TargetType - свойство, кот идентифицирует тип элемента, к которому применяется данный стиль. Создаются сеттеры, влияющие только на определенные элементы

    //Объекты имеют два свойства Setter:
    // - Property - указывают на свойство, к которому будет применяться данный сеттер
    // - Value - устанавливает значение

}