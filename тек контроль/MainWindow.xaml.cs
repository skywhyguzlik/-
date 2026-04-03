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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalaryCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Комментарий: Валидация ввода + вызов сервиса (логика вынесена для unit-тестов)
            if (!double.TryParse(tbHours.Text.Replace(",", "."), out double hours) || hours < 0)
            {
                MessageBox.Show("Введите корректное количество часов (положительное число или 0). Используйте точку или запятую.", "Ошибка ввода");
                return;
            }

            string position = rbAssistant.IsChecked == true ? "ассистент" :
            rbDocent.IsChecked == true ? "доцент" :
            rbProfessor.IsChecked == true ? "профессор" : null;

            if (string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Выберите должность преподавателя.", "Ошибка");
                return;
            }

            var service = new SalaryCalculatorService();
            var result = service.CalculateSalary(hours, position, cbTax.IsChecked == true);

            tbAccrued.Text = $"{result.Gross:F2} руб.";
            tbTax.Text = $"{result.Tax:F2} руб.";
        }
    }
}
