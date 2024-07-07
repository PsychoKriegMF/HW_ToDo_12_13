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

namespace HW_ToDo_12_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> toDoList = new List<ToDo>();
        public MainWindow()
        {
            InitializeComponent();
            DescriptionToDo.Text = "Описания нет";
            DateToDo.SelectedDate = DateTime.Today.AddDays(1);

            toDoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 01, 11)));
            toDoList.Add(new ToDo("Поработать", new DateTime(2024, 01, 12), "Съездить на совещание в москву"));
            toDoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 01, 13), "Съездить в отпуск в сочи"));            
            RefreshToDoList();
            CheckboxEnableToDo_Unchecked(Owner, new RoutedEventArgs());

        }

        private void RefreshToDoList()
        {
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = toDoList;
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (GroupBoxToDo == null || ButtonAdd == null) return;
            GroupBoxToDo.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Hidden;
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (GroupBoxToDo == null || ButtonAdd == null) return;
            GroupBoxToDo.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Visible;    
        }
        private void ButtonRemoveToDo_Click(object sender, RoutedEventArgs e)
        {
            toDoList.Remove(ListToDo.SelectedItem as ToDo);
            RefreshToDoList();
        }

        private void ButtonAddToDo_Click(object sender, RoutedEventArgs e)
        {
            if (!DateToDo.SelectedDate.HasValue)
            {
                MessageBox.Show("Дата повесилась", Name = "Ошибка");
                return;
            }
            toDoList.Add(new ToDo(TitleToDo.Text,
                (DateTime)DateToDo.SelectedDate,
                DescriptionToDo.Text));
            TitleToDo.Text = null;
            DescriptionToDo.Text = "Описания нет";
            RefreshToDoList();
        }
    }
}
