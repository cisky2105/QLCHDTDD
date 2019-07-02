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
    /// Interaction logic for ucNhapHang.xaml
    /// </summary>
    public partial class ucNhapHang : UserControl
    {
        private clsNhanVien_DTO _nvdnto;
        public clsNhanVien_DTO Nvdnto
        {
            get { return _nvdnto; }
            set { _nvdnto = value; }
        }

        public ucNhapHang()
        {
            InitializeComponent();
        }

       

        List<clsSanPham_DTO> lsSanPham = new List<clsSanPham_DTO>();
        List<clsNhaCungCap_DTO> lsNhaCungCap = new List<clsNhaCungCap_DTO>();
        List<clsChiTietHDNhap_DTO> lsChiTiet = new List<clsChiTietHDNhap_DTO>();
        List<clsChiTietHDNhap_DTO> lsRong = new List<clsChiTietHDNhap_DTO>();
        List<clsNhanVien_DTO> lsNhanVien = new List<clsNhanVien_DTO>();

        clsSanPham_DTO spChon_DTO = null;
        clsHoaDonNhap_DTO hdn_DTO = null;

        clsSanPham_BUS sp_BUS = new clsSanPham_BUS();
        clsNhaCungCap_BUS ncc_BUS = new clsNhaCungCap_BUS();
        clsNhanVien_BUS nv_BUS = new clsNhanVien_BUS();
        clsHoaDonNhap_BUS hdn_BUS = new clsHoaDonNhap_BUS();
        clsChiTietHDNhap_BUS cthd_BUS = new clsChiTietHDNhap_BUS();

        private void LoadDanhSachSP()
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPham();
            foreach(var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
        }

        private void LoadNhaCungCap()
        {
            lsNhaCungCap = ncc_BUS.DanhSachNhaCungCap();
            cboNhaCungCap.ItemsSource = lsNhaCungCap;
        }

        private void LoadDanhSachNhanVien()
        {
            lsNhanVien = nv_BUS.DanhSachNhanVien();

            clsNhanVien_DTO nvdangnhap = new clsNhanVien_DTO();
            cboNhanVien.ItemsSource = lsNhanVien;            
            cboNhanVien.SelectedValue = Nvdnto.CMNDNV;

            //cboNhanVien.ValueMember = Nvdnto.CMNDNV.ToString();
        }

        private void BindingChiTiet()
        {
            if (spChon_DTO != null)
            {
                txtMaSP.Text = spChon_DTO.MaSP;
                txtTenSP.Text = spChon_DTO.TenSP;
                txtGiaSP.Text = spChon_DTO.GiaBan.ToString();
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if(txtGiaSP.Text==""||txtSoLuongNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                txtMaHDNhap.Text = hdn_BUS.LayMaTiepTheo();
                if (spChon_DTO != null)
                {
                    clsChiTietHDNhap_DTO ct = lsChiTiet.Find(o => o.MaSP == spChon_DTO.MaSP);
                    if (ct != null)
                    {
                        ct.SoLuong += int.Parse(txtSoLuongNhap.Text);
                    }
                    else
                    {
                        //ct.MaHDNhap = txtMaHDNhap.Text;
                        ct = new clsChiTietHDNhap_DTO();
                        ct.MaSP = spChon_DTO.MaSP;
                        ct.MaHDNhap = txtMaHDNhap.Text;
                        ct.SoLuong = int.Parse(txtSoLuongNhap.Text);
                        string giaban = spChon_DTO.GiaBan.ToString();
                        int chieudai = giaban.Length;
                        string gia = giaban.Substring(0, chieudai - 3);
                        ct.DonGia = spChon_DTO.GiaBan;
                        long tt = ct.SoLuong * int.Parse(gia);
                        ct.ThanhTien = tt * 1000;
                        lsChiTiet.Add(ct);
                    }
                    txtThanhTien.Text = lsChiTiet.Sum(o => o.ThanhTien).ToString();
                    lsChiTietHoaDon.Items.Clear();
                    foreach (var item in lsChiTiet)
                    {
                        lsChiTietHoaDon.Items.Add(item);
                    }
                    btnLuu.IsEnabled = true;
                }
            }            
        }

        frmReportNhapHang f = new frmReportNhapHang();
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsChiTiet.Count > 0)
                {
                    hdn_DTO = new clsHoaDonNhap_DTO();
                    hdn_DTO.MaHDNhap = txtMaHDNhap.Text;
                    f.MaHDNhap = hdn_DTO.MaHDNhap;
                    hdn_DTO.TongTien = lsChiTiet.Sum(o => o.ThanhTien);
                    hdn_DTO.MaNCC = cboNhaCungCap.SelectedValue.ToString();
                    hdn_DTO.CMNDNV = int.Parse(cboNhanVien.SelectedValue.ToString());
                    hdn_DTO.NgayNhap = DateTime.Now;
                    if (hdn_BUS.LuuHoaDonNhap(hdn_DTO))
                    {
                        foreach (clsChiTietHDNhap_DTO ct in lsChiTiet)
                        {
                            if (cthd_BUS.LuuChiTietHoaDon(ct)) continue;
                            else return;
                        }
                        MessageBox.Show("Luu thanh cong");                        
                        lsChiTiet = new List<clsChiTietHDNhap_DTO>();
                        spChon_DTO = null;                        
                    }
                }
                Grid_Loaded(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lsDanhSachSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsDanhSachSanPham.SelectedItems.Count > 0)
            {
                spChon_DTO = (clsSanPham_DTO)lsDanhSachSanPham.SelectedItems[0];
            }
            else
                spChon_DTO = null;
            BindingChiTiet();
            txtGiaSP.IsReadOnly = false;
            txtSoLuongNhap.IsReadOnly = false;
            btnThem.IsEnabled = true;
        }

        private void txtTimKiemSP_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsDanhSachSanPham.Items.Clear();
            lsSanPham = sp_BUS.DanhSachSanPhamTheoTen(txtTimKiem.Text);
            foreach(var item in lsSanPham)
            {
                lsDanhSachSanPham.Items.Add(item);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSachSP();
            LoadDanhSachNhanVien();
            LoadNhaCungCap();
            cboNhanVien.IsEnabled = false;
            txtMaHDNhap.Text = hdn_BUS.LayMaTiepTheo();
            dtpNgayNhap.SelectedDate = DateTime.Now;
            dtpNgayNhap.DisplayDate = DateTime.Now;
            txtMaHDNhap.IsReadOnly = true;            
            txtMaSP.IsReadOnly = true;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtTenSP.IsReadOnly = true;
            txtGiaSP.Clear();
            txtSoLuongNhap.Clear();
            txtSoLuongNhap.IsReadOnly = true;
            btnThem.IsEnabled = false;
            btnLuu.IsEnabled = false;
            lsChiTietHoaDon.Items.Clear();
            txtThanhTien.IsReadOnly = true;
            txtThanhTien.Clear();
        }

        private void btnInHoaDon_Click(object sender, RoutedEventArgs e)
        {
            f.ShowDialog();
        }
    }
}
