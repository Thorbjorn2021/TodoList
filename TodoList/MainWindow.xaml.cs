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
        public MainWindow()
        {
            InitializeComponent();
        }

        private RadioButton getRadioButton()
        {
            RadioButton radioButton;
            if (radioLow.IsChecked != null && radioLow.IsChecked != false)
            {
                radioButton = (RadioButton)radioLow;
            } else if (radioMedium.IsChecked != null && radioMedium.IsChecked != false)
            {
                radioButton = (RadioButton)radioMedium;
            }
            else if (radioHigh.IsChecked != null && radioHigh.IsChecked != false)
            {
                radioButton = (RadioButton)radioHigh;
            }
            else
            {
                return null;
            }

            return radioButton;
        }

        private void BtnAddTodo_Click(object sender, RoutedEventArgs e)
            //bool isValidCondition = 
            
        {
            RadioButton radiobutton = getRadioButton(); 
            listTodos.Items.Add($"Title: {txtTitle.Text}|Urgency: {radiobutton.Content.ToString()}|Todo: {txtTodo.Text}");
            txtTitle.Clear();
            txtTodo.Clear();
            if(radiobutton.IsChecked == true)
            {
                radiobutton.IsChecked = false;
            }
        }
    }

    
}