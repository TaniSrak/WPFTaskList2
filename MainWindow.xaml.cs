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
using System.ComponentModel;
using System.Collections.Specialized;

namespace WPFTaskList2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged //уведомлять на изменение свойств, имеет в себе делегат
    {
        private List<ToDo> ToDoList;

        public List<ToDo> ToDoList2
        {
            get { return ToDoList; }
            set 
            { 
                ToDoList = value;
                OnPropertyChanged();
            }
        }

        public int CountDone { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            ToDoList2 = new List<ToDo>();

            ToDoList2.Add(new ToDo("Дело 1", "Описание", new DateTime(2024, 01, 10)));
            ToDoList2.Add(new ToDo("Дело 2", "Описание", new DateTime(2024, 01, 10)));
            ToDoList2.Add(new ToDo("Дело 3", "Описание", new DateTime(2024, 01, 10)));

            listToDo.ItemsSource = ToDoList2;
        }

        public event PropertyChangedEventHandler PropertyChanged; //делаем делегат, чтобы не проверять действие через цикл
        public void OnPropertyChanged() //вызываем событие на любые изменения ту ду листа
        {
            CountDone = ToDoList2.Where(e=> e.Done == true).ToList().Count;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToDoList2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountDone"));
        }

        private void DeleteJob (object sender, RoutedEventArgs e)
        {
            ToDoList2.Remove(listToDo.SelectedItem as ToDo);
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoList2;
            OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                (listToDo.SelectedItem as ToDo).Done = false;
                OnPropertyChanged();
            }
        }

        
    }

    // ----------------------------------- Стили --------------------------------------------

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

    //-------------------------------------- Триггеры ----------------------------------------------------

    // Триггеры связываются со стилями через коллекцию Style.Triggers
    //      - Trigger - простейшая форма триггеров. Только для одного действия. Он следит за изменением в свойстве в зависимости и затем использует средство установки для изменений стиля
    //      - MultiTrigger - Мультитриггер может сделать несколько действий - Поддерживает проверку множества условий. Этот триггер вступает в дейтсвие, только если удовлетворены все заданные условия
    //      - DataTrigger - работает с привязкой данных. ОН следит за изменением в любых связанных данных
    //      - MultiDataTrigger - объединяет множество триггеров данных
    //      - EventTrigger - Триггер события - применяет анимацию, когда возникает соответствующее событие

    // Простой триггер модифицирует указанные свойства, когда др свойство элемента изменяется согласно установленным правилам
    // (типо выделить цветом кнопку или область, наведение курсора мыши, пока не нажмешь tab)
    // 
    // 
}