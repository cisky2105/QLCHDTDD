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
using BUS;
using DTO;

namespace CuaHang_DTDD_ver2.AllUserControl
{
    /// <summary>
    /// Interaction logic for ucTonKho.xaml
    /// </summary>
    public partial class ucTonKho : UserControl
    {
        public ucTonKho()
        {
            InitializeComponent();
        }

        List<clsSanPham_DTO> lsSanPham = new List<clsSanPham_DTO>();
        clsSanPham_BUS sp_BUS = new clsSanPham_BUS();

        private void txtTimKiemSP_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPhamTheoTen(txtTimKiemSP.Text);
            foreach (var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPham();
            foreach(var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
        }
    }
}
