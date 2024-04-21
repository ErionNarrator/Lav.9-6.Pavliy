using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Lav._9_6.Pavliy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> listLab1;
        private Queue<int> queue;
        private LinkedList<int> listLab3;
        public MainWindow()
        {
            InitializeComponent();
            listLab1 = new List<int>();
            queue = new Queue<int>();
            listLab3 = new LinkedList<int>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listLab1.Add(int.Parse(tbElement.Text));
            lbList.ItemsSource = null;
            lbList.ItemsSource = listLab1;
            tbElement.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = lbList.SelectedIndex;
            listLab1.RemoveAt(index);
            lbList.ItemsSource = null;
            lbList.ItemsSource = listLab1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (int l in listLab1)
            {
                if (l < 0) count++;
            }
            Result.Text = "Количество отрицательных:" + count.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            queue.Enqueue(int.Parse(tbElementQueue.Text));
            lbQueue.ItemsSource = null;
            lbQueue.ItemsSource = queue;
            tbElementQueue.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(tbCount.Text);
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += queue.Dequeue() + " ";
            }
            tbResultQueue.Text = result;
            lbQueue.ItemsSource = null;
            lbQueue.ItemsSource = queue;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            listLab3.Add(int.Parse(tbElementAdd.Text));
            lbList3.Items.Clear();
            foreach (int item in listLab3)
            {
                lbList3.Items.Add(item);
            }
            tbElementAdd.Text = "";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            List<int> listLab3 = lbList3.Items.Cast<int>().ToList();
            listLab3.RemoveAll(i => Math.Abs(i) < 5);
            lbList3.Items.Clear();
            foreach (int item in listLab3)
            {
                lbList3.Items.Add(item);
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            listLab3.Clear();
            lbList3.Items.Clear();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string str1 = FirstStringTextBox.Text;
            string str2 = SecondStringTextBox.Text;

            str1 = str1.ToLower();
            str2 = str2.ToLower();

            str1 = Regex.Replace(str1, @"\s+", "");
            str2 = Regex.Replace(str2, @"\s+", "");

            str1 = Regex.Replace(str1, @"\p{P}", "");
            str2 = Regex.Replace(str2, @"\p{P}", "");

            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            string sortedStr1 = new string(arr1);
            string sortedStr2 = new string(arr2);

            bool isAnagram = sortedStr1 == sortedStr2;

            if (isAnagram)
            {
                MessageBox.Show("Данные строки являются анаграммами.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Данные строки не являются анаграммами.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
 }
