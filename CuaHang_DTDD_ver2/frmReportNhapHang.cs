using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHang_DTDD_ver2
{
    public partial class frmReportNhapHang : Form
    {
        public frmReportNhapHang()
        {
            InitializeComponent();
        }
        public string MaHDNhap { get; set; }
        private void frmReportNhapHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPhieuNhap.PhieuNhap' table. You can move, or remove it, as needed.
            this.PhieuNhapTableAdapter.Fill(this.DataSetPhieuNhap.PhieuNhap, MaHDNhap);
            // TODO: This line of code loads data into the 'QL_CuaHangDTDDDataSet1.HoaDonNhap' table. You can move, or remove it, as needed.
            this.HoaDonNhapTableAdapter.Fill(this.QL_CuaHangDTDDDataSet1.HoaDonNhap);

            this.rpvNhapHang.RefreshReport();
        }
    }
}
