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
using DTO;
using BUS;

namespace CuaHang_DTDD_ver2.AllUserControl
{
    /// <summary>
    /// Interaction logic for ucKhachHang.xaml
    /// </summary>
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }
        List<clsKhachHang_DTO> lsKhachHang = new List<clsKhachHang_DTO>();
        clsKhachHang_BUS kh_BUS = new clsKhachHang_BUS();
        clsKhachHang_DTO khChon_DTO = null;
        int tam = 0;//0 them, 1 sua
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lsDanhSachKhachHang.Items.Clear();
            lsKhachHang = kh_BUS.DanhSachKhachHang();
            foreach (var item in lsKhachHang)
            {
                lsDanhSachKhachHang.Items.Add(item);
            }
            DisGiaoDien();
        }

        private void DisGiaoDien()
        {
            txtSDTKH.IsReadOnly = true;
            txtTenKH.IsReadOnly = true;
            txtDiaChiKH.IsReadOnly = true;
            txtEmailKH.IsReadOnly = true;
        }
        private void EnGiaoDien()
        {
            txtSDTKH.IsReadOnly = false;
            txtTenKH.IsReadOnly = false;
            txtDiaChiKH.IsReadOnly = false;
            txtEmailKH.IsReadOnly = false;
        }

        private void ClearGiaoDien()
        {
            txtSDTKH.Clear();
            txtTenKH.Clear();
            txtDiaChiKH.Clear();
            txtEmailKH.Clear();
        }

        private void BindingChiTiet()
        {
            if (khChon_DTO != null)
            {
                txtSDTKH.Text = khChon_DTO.SDTKH;
                txtTenKH.Text = khChon_DTO.TenKH;
                txtDiaChiKH.Text = khChon_DTO.DiaChi;
                if (khChon_DTO.GioiTinh == true)
                    radNam.IsChecked = true;
                if (khChon_DTO.GioiTinh == false)
                    radNu.IsChecked = true;
                txtEmailKH.Text = khChon_DTO.Email;
            }
            else
            {
                ClearGiaoDien();
            }
        }

        private void GetDataChiTiet()
        {
            if (khChon_DTO == null)
                khChon_DTO = new clsKhachHang_DTO();
            khChon_DTO.SDTKH = txtSDTKH.Text;
            khChon_DTO.TenKH = txtTenKH.Text;
            khChon_DTO.DiaChi = txtDiaChiKH.Text;
            khChon_DTO.Email = txtEmailKH.Text;
            if (radNam.IsChecked == true)
                khChon_DTO.GioiTinh = true;
            if (radNu.IsChecked == true)
                khChon_DTO.GioiTinh = false;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ClearGiaoDien();
            EnGiaoDien();
            khChon_DTO = null;
            tam = 0;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GetDataChiTiet();
            MessageBoxResult dir = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (dir == MessageBoxResult.Yes)
                {
                    if (kh_BUS.XoaKhachHang(txtSDTKH.Text))
                        MessageBox.Show("Bạn đã xóa khách hàng!", "Thông báo");
                    else
                        MessageBox.Show("Xóa khách hàng không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Grid_Loaded( sender,  e);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            EnGiaoDien();
            tam = 1;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tam == 0)
                {
                    GetDataChiTiet();
                    if (kh_BUS.ThemKhachHang(khChon_DTO))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!");
                        Grid_Loaded(sender, e);
                        DisGiaoDien();
                    }
                }
                if (tam == 1)
                {
                    GetDataChiTiet();
                    if (kh_BUS.CapNhatKhachHang(khChon_DTO))
                    {
                        MessageBox.Show("Sửa khách hàng thành công!");
                        Grid_Loaded(sender, e);
                        DisGiaoDien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lsDanhSachKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisGiaoDien();
            if (lsDanhSachKhachHang.SelectedItems.Count > 0)
            {
                khChon_DTO = (clsKhachHang_DTO)lsDanhSachKhachHang.SelectedItems[0];
            }
            else
                khChon_DTO = null;
            BindingChiTiet();
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
