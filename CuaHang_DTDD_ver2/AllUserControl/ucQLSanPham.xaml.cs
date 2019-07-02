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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace CuaHang_DTDD_ver2.AllUserControl
{
    /// <summary>
    /// Interaction logic for ucQLSanPham.xaml
    /// </summary>
    public partial class ucQLSanPham : UserControl
    {
        public ucQLSanPham()
        {
            InitializeComponent();
            
        }
       

        clsSanPham_BUS sp_BUS = new clsSanPham_BUS();
        clsNhaSanXuat_BUS nsx_BUS = new clsNhaSanXuat_BUS();
        clsLoaiDT_BUS loaidt_BUS = new clsLoaiDT_BUS();
        clsSanPham_DTO spChon_DTO = null;
        int tam = 0; // 0 la them, 1 la sua
        string strPath = @"/images/";
        string strPath2 = @"C:\Users\HOANG KHANG\Desktop\DoAn_vs_Wpf\CuaHang_DTDD_ver2\CuaHang_DTDD_ver2\CuaHang_DTDD_ver2\images\";

        List<clsSanPham_DTO> lsSanPham = new List<clsSanPham_DTO>();
        List<clsNhaSanXuat_DTO> lsNhaSanXuat = new List<clsNhaSanXuat_DTO>();
        List<clsLoaiDT_DTO> lsLoaiDT = new List<clsLoaiDT_DTO>();


        private void LoadDSSP()
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPham();
            foreach(var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
            lsNhaSanXuat = nsx_BUS.DanhSachNhaSanXuat();
            lsLoaiDT = loaidt_BUS.DanhSachLoaiDT();            

            cboNhaSanXuat.ItemsSource = lsNhaSanXuat;           
            cboLoaiDT.ItemsSource = lsLoaiDT;
            
        }
        private void GetDataChiTiet()
        {
            if (spChon_DTO == null)
            {
                spChon_DTO = new clsSanPham_DTO();
                spChon_DTO.MaSP = txtMaSP.Text;
            }

            spChon_DTO.TenSP = txtTenSP.Text;
            spChon_DTO.GiaBan = int.Parse(txtGiaSP.Text.ToString());
            if (txtKhuyenMai.Text == "")
                spChon_DTO.GiaKM = 0;
            else
                spChon_DTO.GiaKM = int.Parse(txtKhuyenMai.Text.ToString());
            spChon_DTO.MaLoaiDT = cboLoaiDT.SelectedValue.ToString();
            spChon_DTO.MaNSX = cboNhaSanXuat.SelectedValue.ToString();
            spChon_DTO.HinhAnh = spChon_DTO.MaSP + ".jpg";
        }

        
        private void BindingChiTiet()
        {
            if (spChon_DTO != null)
            {
                txtMaSP.Text = spChon_DTO.MaSP;
                txtTenSP.Text = spChon_DTO.TenSP;
                txtGiaSP.Text = spChon_DTO.GiaBan.ToString();
                txtKhuyenMai.Text = spChon_DTO.GiaKM.ToString();
                cboNhaSanXuat.SelectedValue = spChon_DTO.MaNSX;
                cboLoaiDT.SelectedValue = spChon_DTO.MaLoaiDT;
                string path = strPath + spChon_DTO.HinhAnh;
                Uri imageUri = new Uri(path, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                imgHinhAnh.Source = imageBitmap;                
            }
            else
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGiaSP.Clear();
                txtKhuyenMai.Clear();
                cboLoaiDT.SelectedValue = -1;
                cboNhaSanXuat.SelectedValue = -1;
                imgHinhAnh.Source = null;
            }
        }
        private void lsDanhSachSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSua.IsEnabled = true;
            btnXoa.IsEnabled = true;
            if (lsDanhSachSanPham.SelectedItems.Count > 0)
            {
                spChon_DTO = (clsSanPham_DTO)lsDanhSachSanPham.SelectedItems[0];
            }                
            else
                spChon_DTO = null;
            BindingChiTiet();
        }

        string filepath;
        private void btnChonHinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofd.Multiselect = false;
            bool? result = ofd.ShowDialog();
            if (result == true)
            {
                filepath = ofd.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                imgHinhAnh.Source = imgsource;
            }
            //imgHinhAnh.Source = new BitmapImage(new Uri(ofd.FileName.ToString()));
            
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }
        private void ClearGiaoDien()
        {
            txtTenSP.Clear();
            txtGiaSP.Clear();
            txtKhuyenMai.Clear();
            txtMaSP.Text = sp_BUS.LayMaSPTiepTheo();
            imgHinhAnh.Source = null;
            cboLoaiDT.SelectedIndex = -1;
            cboNhaSanXuat.SelectedIndex = -1;
        }

        private void EnGiaoDien()
        {
            txtTenSP.IsReadOnly = false;
            txtGiaSP.IsReadOnly = false;
            txtKhuyenMai.IsReadOnly = false;
            cboLoaiDT.IsReadOnly = false;
            cboNhaSanXuat.IsReadOnly = false;
            btnChonHinh.IsEnabled = true;
        }

        private void DisGiaoDien()
        {
            txtTenSP.IsReadOnly = true;
            txtGiaSP.IsReadOnly = true;
            txtKhuyenMai.IsReadOnly = true;
            cboLoaiDT.IsReadOnly = true;
            cboNhaSanXuat.IsReadOnly = true;
            btnChonHinh.IsEnabled = false;
        }
        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            btnLuu.IsEnabled = true;
            btnXoa.IsEnabled = false;
            btnSua.IsEnabled = false;
            ClearGiaoDien();            
            EnGiaoDien();
            tam = 0;
            spChon_DTO = null;
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            btnLuu.IsEnabled = true;
            EnGiaoDien();
            tam = 1;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GetDataChiTiet();
            MessageBoxResult dir = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (dir == MessageBoxResult.Yes)
                {
                    if (sp_BUS.XoaSanPham(spChon_DTO.MaSP))
                    {
                        MessageBox.Show("Bạn đã xóa sản phẩm!", "Thông báo");
                        Grid_Loaded(sender, e);
                    }                        
                    else
                        MessageBox.Show("Xóa sản phẩm không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if(txtTenSP.Text == "" || txtGiaSP.Text == "" || imgHinhAnh.Source == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    if (tam == 0)
                    {
                        GetDataChiTiet();
                        if (sp_BUS.ThemSanPham(spChon_DTO))
                        {
                            if (imgHinhAnh.Source != null)
                            {
                                string destinationPath = strPath2 + spChon_DTO.HinhAnh;
                                File.Copy(filepath, destinationPath, true);
                            }
                            MessageBox.Show("Thêm sản phẩm thành công!");
                            Grid_Loaded(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm không thành công!");
                            spChon_DTO = null;
                        }
                    }
                    if (tam == 1)
                    {
                        GetDataChiTiet();
                        if (sp_BUS.CapNhatSanPham(spChon_DTO))
                        {
                            if (imgHinhAnh.Source != null)
                            {
                                string destinationPath = strPath + spChon_DTO.HinhAnh;
                                try
                                {
                                    if (File.Exists(destinationPath))
                                    {
                                        imgHinhAnh.Source = null;
                                        File.Delete(destinationPath);
                                    }
                                    File.Copy(filepath, destinationPath, true);

                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            MessageBox.Show("Sửa sản phẩm thành công!");
                            Grid_Loaded(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Sửa sản phẩm không thành công!");
                            spChon_DTO = null;
                        }
                    }
                    DisGiaoDien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDSSP();
            DisGiaoDien();
            btnThemSP.IsEnabled = true;
            btnXoa.IsEnabled = false;
            btnSua.IsEnabled = false;
            btnLuu.IsEnabled = false;
            btnChonHinh.IsEnabled = false;
            txtMaSP.Text = sp_BUS.LayMaSPTiepTheo();
        }

        private void txtTimKiemSP_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPhamTheoTen(txtTimKiemSP.Text);
            foreach (var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
        }
    }
}
