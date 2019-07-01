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
using CuaHang_DTDD_ver2.AllUserControl;
using BUS;
using DTO;

namespace CuaHang_DTDD_ver2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();            
            this.Topmost = false;
                     
        }

        private void mnQLSP_Click(object sender, RoutedEventArgs e)
        {
            //Controls thay bang children
            ucQLSanPham qlsp = new ucQLSanPham();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlsp);
        }

        private void mnQLNV_Click(object sender, RoutedEventArgs e)
        {
            ucQLNhanVien qlnv = new ucQLNhanVien();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlnv);
        }
    }
}
