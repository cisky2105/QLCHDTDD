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

        private void mnQLNCC_Click(object sender, RoutedEventArgs e)
        {
            ucQLNhaCungCap qlncc = new ucQLNhaCungCap();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlncc);
        }

        private void mnQLNSX_Click(object sender, RoutedEventArgs e)
        {
            ucQLNSX qlnsx = new ucQLNSX();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlnsx);
        }

        private void mnQLKhachHang_Click(object sender, RoutedEventArgs e)
        {
            ucKhachHang qlkh = new ucKhachHang();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlkh);
        }

        private void mnNhapHang_Click(object sender, RoutedEventArgs e)
        {
            ucNhapHang qlnh = new ucNhapHang();
            pnlUC.Children.Clear();
            pnlUC.Children.Add(qlnh);
        }
    }
}
