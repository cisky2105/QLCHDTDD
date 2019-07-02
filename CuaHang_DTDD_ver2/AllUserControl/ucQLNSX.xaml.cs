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
    /// Interaction logic for ucQLNSX.xaml
    /// </summary>
    public partial class ucQLNSX : UserControl
    {
        public ucQLNSX()
        {
            InitializeComponent();
        }

        List<clsNhaSanXuat_DTO> lsReult = new List<clsNhaSanXuat_DTO>();
        clsNhaSanXuat_DTO nsxChon_DTO = null;
        clsNhaSanXuat_BUS nsx_BUS = new clsNhaSanXuat_BUS();
        int tam = 0; //0 them, 1 xoa

        private void lsNhaSanXuat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsNhaSanXuat.SelectedItems.Count > 0)
            {
                nsxChon_DTO = (clsNhaSanXuat_DTO)lsNhaSanXuat.SelectedItems[0];
            }
            else
                nsxChon_DTO = null;
            BindingChiTiet();
        }

        private void GetDataChiTiet()
        {
            if (nsxChon_DTO == null)
            {
                nsxChon_DTO = new clsNhaSanXuat_DTO();
                nsxChon_DTO.MaNSX = txtTenNSX.Text;
            }
            nsxChon_DTO.TenNSX = txtTenNSX.Text;
        }

        private void BindingChiTiet()
        {
            if (nsxChon_DTO != null)
            {
                txtMaNSX.Text = nsxChon_DTO.MaNSX;
                txtTenNSX.Text = nsxChon_DTO.TenNSX;
            }
            else
            {
                txtMaNSX.Clear();
                txtTenNSX.Clear();

            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

            txtMaNSX.Text = nsx_BUS.LayMaTiepTheo();
            txtTenNSX.IsReadOnly = false;
            txtTenNSX.Clear();
            tam = 0;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GetDataChiTiet();
            MessageBoxResult dir = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà sản xuất?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (dir == MessageBoxResult.Yes)
                {
                    if (nsx_BUS.XoaNhaSanXuat(nsxChon_DTO.MaNSX))
                        MessageBox.Show("Bạn đã xóa nhà sản xuất!", "Thông báo");
                    else
                        MessageBox.Show("Xóa nhà sản xuất không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Grid_Loaded(sender, e);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            txtTenNSX.IsReadOnly = false;
            tam = 1;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tam == 0)
                {
                    GetDataChiTiet();
                    if (nsx_BUS.ThemNhaSanXuat(nsxChon_DTO))
                    {
                        MessageBox.Show("Thêm nhà sản xuất thành công!");
                        Grid_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà sản xuất không thành công!");
                        nsxChon_DTO = null;
                    }
                }
                if (tam == 1)
                {
                    GetDataChiTiet();
                    if (nsx_BUS.CapNhatNhaSanXuat(nsxChon_DTO))
                    {
                        MessageBox.Show("Sửa nhà sản xuất thành công!");
                        Grid_Loaded( sender,  e);
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhà sản xuất không thành công!");
                        nsxChon_DTO = null;
                    }
                }
                txtTenNSX.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lsNhaSanXuat.Items.Clear();
            lsReult = nsx_BUS.DanhSachNhaSanXuat();
            foreach (var item in lsReult)
            {
                lsNhaSanXuat.Items.Add(item);
            }
            txtMaNSX.IsReadOnly = true;
            txtTenNSX.IsReadOnly = true;
            txtMaNSX.Text = nsx_BUS.LayMaTiepTheo();
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
