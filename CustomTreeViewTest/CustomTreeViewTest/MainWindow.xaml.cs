using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CustomTreeViewTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomTreeNodeList EntList;

        public MainWindow()
        {
            InitializeComponent();

            EntList = new CustomTreeNodeList();
            DataContext = EntList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(1024))
            {
                Serializer.Serialize(ms, (CustomTreeNodeList)DataContext);

                byte[] bs = ms.ToArray();

                File.WriteAllBytes("test.txt", bs);
            }

            MessageBox.Show("Done!");
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            byte[] bs = File.ReadAllBytes("test.txt");

            using (MemoryStream ms = new MemoryStream(bs))
            {
                CustomTreeNodeList ic = Serializer.Deserialize<CustomTreeNodeList>(ms);
                DataContext = ic;
            }

            MessageBox.Show("Done!");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EntList.Add();
        }
    }
}
