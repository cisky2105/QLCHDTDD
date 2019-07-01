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
    /// Interaction logic for ucQLNhanVien.xaml
    /// </summary>
    public partial class ucQLNhanVien : UserControl
    {
        public ucQLNhanVien()
        {
            InitializeComponent();
        }

        clsNhanVien_BUS nv_BUS = new clsNhanVien_BUS();
        clsNhanVien_DTO nvChon_DTO = null;
        clsQuyen_BUS quyen_BUS = new clsQuyen_BUS();

        List<clsQuyen_DTO> lsQuyen = new List<clsQuyen_DTO>();
        List<clsNhanVien_DTO> lsNhanVien = new List<clsNhanVien_DTO>();

        int tam = 0; //0 la them, 1 la sua        

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ClearGiaoDien();
            EnGiaoDien();
            nvChon_DTO = null;
            tam = 0;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GetDataChiTiet();
            MessageBoxResult dir = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (dir == MessageBoxResult.Yes)
                {
                    if (nv_BUS.XoaNhanVien(int.Parse(txtMaNV.Text)))
                        MessageBox.Show("Bạn đã xóa nhân viên!", "Thông báo");
                    else
                        MessageBox.Show("Xóa nhân viên không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DanhSachNhanVien();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            EnGiaoDien();
            txtMaNV.IsReadOnly = true;
            txtTenNV.IsReadOnly = true;
            tam = 1;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //DateTime? value = null;
            //if (dtpNgaySinh.SelectedDate.HasValue)
            //{
            //    value = dtpNgaySinh.DisplayDate;
            //}
            //else
            //    value = DateTime.Now;
            try
            {
                if (tam == 0)
                {
                    GetDataChiTiet();
                    if (nv_BUS.ThemNhanVien(nvChon_DTO))
                    {
                        MessageBox.Show("Thêm nhân viên thành công!");
                        DanhSachNhanVien();
                        DisGiaoDien();
                    }
                }
                if (tam == 1)
                {
                    GetDataChiTiet();
                    if (nv_BUS.CapNhatNhanVien(nvChon_DTO))
                    {
                        MessageBox.Show("Sửa nhân viên thành công!");
                        DanhSachNhanVien();
                        DisGiaoDien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DanhSachNhanVien()
        {
            lsDanhSachNhanVien.Items.Clear();
            lsNhanVien = nv_BUS.DanhSachNhanVien();
            foreach(var item in lsNhanVien)
            {
                lsDanhSachNhanVien.Items.Add(item);
            }
        }

        private void DanhSachQuyen()
        {
            lsQuyen = quyen_BUS.DanhSachQuyenNV();
            cboQuyen.ItemsSource = lsQuyen;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DanhSachNhanVien();
            DanhSachQuyen();
        }

        private void BindingChiTiet()
        {
            if (nvChon_DTO != null)
            {
                txtMaNV.Text = nvChon_DTO.CMNDNV.ToString();
                txtTenNV.Text = nvChon_DTO.HoVaTen;
                txtDiaChi.Text = nvChon_DTO.DiaChi;
                dtpNgaySinh.SelectedDate = nvChon_DTO.NgaySinh;
                if (nvChon_DTO.GioiTinh == true)
                    radNam.IsChecked = true;
                if (nvChon_DTO.GioiTinh == false)
                    radNu.IsChecked = true;
                txtSDTNV.Text = nvChon_DTO.SDT;
                txtMatKhau.Password = nvChon_DTO.MatKhau;
                cboQuyen.SelectedValue = nvChon_DTO.Quyen;
            }
            else
            {
                txtMaNV.Clear();
                txtTenNV.Clear();
                txtDiaChi.Clear();               
                txtSDTNV.Clear();
                txtMatKhau.Clear();
                cboQuyen.SelectedValue = -1;
            }
        }

        private void GetDataChiTiet()
        {
            if (nvChon_DTO == null)
                nvChon_DTO = new clsNhanVien_DTO();
            nvChon_DTO.CMNDNV = int.Parse(txtMaNV.Text);
            nvChon_DTO.HoVaTen = txtTenNV.Text;
            nvChon_DTO.DiaChi = txtDiaChi.Text;
            nvChon_DTO.MatKhau = txtMatKhau.Password;
            if (radNam.IsChecked == true)
                nvChon_DTO.GioiTinh = true;
            if (radNu.IsChecked == true)
                nvChon_DTO.GioiTinh = false;           
            nvChon_DTO.NgaySinh = dtpNgaySinh.SelectedDate.Value;


            //nvChon_DTO.NgaySinh = dtpNgaySinh.SelectedDate.Value;
            nvChon_DTO.Quyen = cboQuyen.SelectedValue.ToString();
            nvChon_DTO.SDT = txtSDTNV.Text;
        }

        private void EnGiaoDien()
        {
            txtMaNV.IsReadOnly = false;
            txtTenNV.IsReadOnly = false;
            txtDiaChi.IsReadOnly = false;
            txtSDTNV.IsReadOnly = false;            
            cboQuyen.IsReadOnly = false;
        }
        private void DisGiaoDien()
        {
            txtMaNV.IsReadOnly = true;
            txtTenNV.IsReadOnly = true;
            txtDiaChi.IsReadOnly = true;
            txtSDTNV.IsReadOnly = true;                        
            cboQuyen.IsReadOnly = true;

        }
        private void ClearGiaoDien()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.SelectedDate = DateTime.Now;
            txtSDTNV.Clear();
            txtMatKhau.Clear();
            cboQuyen.SelectedValue = -1;
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lsDanhSachNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsDanhSachNhanVien.SelectedItems.Count > 0)
            {
                nvChon_DTO = (clsNhanVien_DTO)lsDanhSachNhanVien.SelectedItems[0];
            }
            else
                nvChon_DTO = null;
            BindingChiTiet();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DisGiaoDien();
        }
        
    }
}
