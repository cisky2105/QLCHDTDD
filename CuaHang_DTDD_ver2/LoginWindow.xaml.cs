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
using System.Windows.Shapes;
using BUS;
using DTO;


namespace CuaHang_DTDD_ver2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        List<clsNhanVien_DTO> lsNhanVien = new List<clsNhanVien_DTO>();
        public clsNhanVien_DTO nvDangNhap = null;

        clsNhanVien_BUS nv_BUS = new clsNhanVien_BUS();

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string strMaNV = txtUser.Text;
                string strMK = txtPassword.Password;
                if (strMaNV == "" || strMK == "")
                {
                    MessageBox.Show("Bạn chưa nhập Tên đăng nhập hoặc Mật khẩu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                lsNhanVien = nv_BUS.DanhSachNhanVien();
                foreach (clsNhanVien_DTO nv in lsNhanVien)
                {
                    if (nv.CMNDNV == int.Parse(txtUser.Text))
                    {
                        nvDangNhap = new clsNhanVien_DTO();
                        nvDangNhap = nv;
                        break;
                    }
                }
                if (nvDangNhap == null)
                {
                    MessageBox.Show("Ban khong phai nhan vien cua cua hang");
                }
                else
                {
                    if (nvDangNhap.MatKhau == txtPassword.Password)
                    {
                        MainWindow f = new MainWindow();
                        f.Nvdto = nvDangNhap;
                        this.Hide();
                        f.ShowDialog();
                        txtPassword.Clear();
                        txtUser.Clear();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Passwords sai!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
        }
       
    }
}
