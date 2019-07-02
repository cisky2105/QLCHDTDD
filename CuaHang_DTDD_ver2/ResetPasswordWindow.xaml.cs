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
using DTO;
using BUS;

namespace CuaHang_DTDD_ver2
{
    /// <summary>
    /// Interaction logic for ResetPasswordWindow.xaml
    /// </summary>
    public partial class ResetPasswordWindow : Window
    {
        private clsNhanVien_DTO nhanvien;
        public clsNhanVien_DTO NhanVien
        {
            get { return nhanvien; }
            set { nhanvien = value; }
        }
        public ResetPasswordWindow()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            if (txtPasswordCu.Password != "" && txtPasswordMoi.Password != "" && txtNhapLaiPassword.Password != "")
            {
                if (txtPasswordCu.Password == nhanvien.MatKhau)
                {
                    if (txtPasswordMoi.Password == txtNhapLaiPassword.Password)
                    {
                        clsNhanVien_BUS nvbus = new clsNhanVien_BUS();
                        if (nvbus.DoiMatKhauNV(nhanvien.CMNDNV, txtPasswordMoi.Password))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu cho giống!");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ sai!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
            }
        }
    }    
}
