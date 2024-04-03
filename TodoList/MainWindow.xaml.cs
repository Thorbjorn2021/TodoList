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

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TodoListDataContext DC => (TodoListDataContext)DataContext;
        public MainWindow()
        {
            InitializeComponent();
            DC.RetrieveTodos();
        }

        private void BtnAddTodo_Click(object sender, RoutedEventArgs e)

        {
            Todo todo = new Todo(txtTitle.Text, txtTodo.Text, myComboBox.Text);
            txtTitle.Clear();
            txtTodo.Clear();
            DC.AddTodo(todo);
        }

        private void BtnRemoveTodo_Click(object sender, RoutedEventArgs e)
        {
            DC.RemoveTodo();
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            DC.StoreTodos();
        }
    }


}