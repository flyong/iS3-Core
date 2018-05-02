using iS3.Geology;
using iS3.Geology.Server;
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

namespace iS3.Core.Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    { 

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            BoreholeServer server = new BoreholeServer(new BoreholeRepositoryForServer(new GeologyDbContext()));

            output.Text += server.ViewBorehole(int.Parse(a.Text)) + "\r\n";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            BoreholeServer server = new BoreholeServer(new BoreholeRepositoryForServer(new GeologyDbContext()));
            Borehole obj = new Borehole()
            {
                ID = int.Parse(a.Text),
                Name = b.Text,
                Top = int.Parse(c.Text),
            };

            output.Text += server.CreateBorehole(obj) + "\r\n";
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            BoreholeServer server = new BoreholeServer(new BoreholeRepositoryForServer(new GeologyDbContext()));
            Borehole obj = new Borehole()
            {
                ID = int.Parse(a.Text),
                Name = b.Text,
                Top = int.Parse(c.Text),
            };
            output.Text += server.ModifyBorehole(obj) + "\r\n";
        }

        private void detele_Click(object sender, RoutedEventArgs e)
        {
            BoreholeServer server = new BoreholeServer(new BoreholeRepositoryForServer(new GeologyDbContext()));
            output.Text += server.DeteleBorehole(int.Parse(a.Text)) + "\r\n";
        }
    }
}
