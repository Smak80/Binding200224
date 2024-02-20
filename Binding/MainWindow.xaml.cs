using System.ComponentModel;
using System.Dynamic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student std = new Student();
        public MainWindow()
        {
            InitializeComponent();
            std.PropertyChanged += StdOnPropertyChanged;
            std.Name = "Иван";
            std.Password = "1234";
            System.Windows.Data.Binding bind = new System.Windows.Data.Binding();

            // bind.ElementName = "tb1";
            // bind.Path = new PropertyPath("Text");
            // bind.Mode = BindingMode.TwoWay;
            // bind.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            // tb2.SetBinding(TextBox.TextProperty, bind);

            bind.Source = std;
            bind.Path = new PropertyPath(nameof(Student.Name));
            StdName.SetBinding(TextBlock.TextProperty, bind);

            System.Windows.Data.Binding bndSalary = new();
            bndSalary.Source = std;
            bndSalary.Path = new(nameof(Student.Salary));
            StdSalary.SetBinding(TextBox.TextProperty, bndSalary);
            
        }

        private void StdOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Student.Password))
            {
                if (!StdPass.Password.Equals(std.Password))
                {
                    StdPass.Password = std.Password;
                }
            }
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            std.Save("student.info");
            std.Name = "44444";
            std.Password = "123456789";
        }

        private void StdPass_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            std.Password = StdPass.Password;
        }
    }
}