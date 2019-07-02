using BUS;
using DTO;
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

namespace CuaHang_DTDD_ver2.AllUserControl
{
    /// <summary>
    /// Interaction logic for ucQLNhaCungCap.xaml
    /// </summary>
    public partial class ucQLNhaCungCap : UserControl
    {
        public ucQLNhaCungCap()
        {
            InitializeComponent();
        }

        List<clsNhaCungCap_DTO> lsNCC = new List<clsNhaCungCap_DTO>();
        clsNhaCungCap_DTO nccChon_DTO = null;
        clsNhaCungCap_BUS ncc_BUS = new clsNhaCungCap_BUS();
        int tam = 0; //0 la them, 1 la sua       

        private void DisGiaoDien()
        {
            txtMaNCC.IsReadOnly = true;
            txtTenNCC.IsReadOnly = true;
            txtDiaChiNCC.IsReadOnly = true;
            txtEmailNCC.IsReadOnly = true;
            txtSDTNCC.IsReadOnly = true;
        }

        private void EnGiaoDien()
        {
            
            txtTenNCC.IsReadOnly = false;
            txtDiaChiNCC.IsReadOnly = false;
            txtEmailNCC.IsReadOnly = false;
            txtSDTNCC.IsReadOnly = false;
        }

        private void ClearGiaoDien()
        {
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtEmailNCC.Clear();
            txtSDTNCC.Clear();
            txtMaNCC.Text = ncc_BUS.LayMaNCCTiepTheo();
        }

        private void GetDataChiTiet()
        {
            if (nccChon_DTO == null)
            {
                nccChon_DTO = new clsNhaCungCap_DTO();
                nccChon_DTO.MaNCC = txtMaNCC.Text;
            }
            nccChon_DTO.TenNCC = txtTenNCC.Text;
            nccChon_DTO.Email = txtEmailNCC.Text;
            nccChon_DTO.SDT = txtSDTNCC.Text;
            nccChon_DTO.DiaChi = txtDiaChiNCC.Text;
        }

        private void BindingChiTiet()
        {
            if (nccChon_DTO != null)
            {
                txtMaNCC.Text = nccChon_DTO.MaNCC;
                txtTenNCC.Text = nccChon_DTO.TenNCC;
                txtDiaChiNCC.Text = nccChon_DTO.DiaChi;
                txtEmailNCC.Text = nccChon_DTO.Email;
                txtSDTNCC.Text = nccChon_DTO.SDT;
            }
            else
            {
                txtMaNCC.Clear();
                txtTenNCC.Clear();
                txtDiaChiNCC.Clear();
                txtEmailNCC.Clear();
                txtSDTNCC.Clear();
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ClearGiaoDien();
            EnGiaoDien();
            tam = 0;
            nccChon_DTO = null;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GetDataChiTiet();
            MessageBoxResult dir = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (dir == MessageBoxResult.Yes)
                {
                    if (ncc_BUS.XoaNhaCungCap(nccChon_DTO.MaNCC))
                        MessageBox.Show("Bạn đã xóa nhà cung cấp!", "Thông báo");
                    else
                        MessageBox.Show("Xóa nhà cung cấp không thành công!");
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
                    if (ncc_BUS.ThemNhaCungCap(nccChon_DTO))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công!");
                        Grid_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp không thành công!");
                        nccChon_DTO = null;
                    }
                }
                if (tam == 1)
                {
                    GetDataChiTiet();
                    if (ncc_BUS.CapNhatNhaCungCap(nccChon_DTO))
                    {
                        MessageBox.Show("Sửa nhà cung cấp thành công!");
                        Grid_Loaded( sender,  e);
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhà cung cấp không thành công!");
                        nccChon_DTO = null;
                    }
                }
                DisGiaoDien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lsDanhSachNhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsDanhSachNhaCungCap.SelectedItems.Count > 0)
            {
                nccChon_DTO = (clsNhaCungCap_DTO)lsDanhSachNhaCungCap.SelectedItems[0];
            }
            else
                nccChon_DTO = null;
            BindingChiTiet();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lsDanhSachNhaCungCap.Items.Clear();
            lsNCC = ncc_BUS.DanhSachNhaCungCap();
            foreach (var item in lsNCC)
            {
                lsDanhSachNhaCungCap.Items.Add(item);
            }
            DisGiaoDien();
        }
    }
}
