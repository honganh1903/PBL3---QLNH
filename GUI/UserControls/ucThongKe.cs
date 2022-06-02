using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.UserControls
{
    public partial class ucThongKe : UserControl
    {
        private void ucThongKe_Load(object sender, EventArgs e)
        {
            cboDoanhThu.SelectedIndex = 0;
            cboTopSanPham2.SelectedIndex = 0;
            cboTopSanPham1.SelectedIndex = 0;
            btnRefresh.PerformClick();
        }
        public ucThongKe()
        {
            InitializeComponent();
        }

        
        private string Convert(double gia)
        {
            string giaban = gia.ToString();
            string result = "";
            int d = 0;
            for (int i = giaban.Length - 1; i >= 0; i--)
            {
                d++;
                result += giaban[i];
                if (d == 3 && i != 0)
                {
                    result += '.';
                    d = 0;
                }
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void LoadData()
        {
            Cursor = Cursors.AppStarting;
            lbTongSanPham.Text = ThongKeBL.Instance.GetTongSanPhamDaBan().ToString();
            lbTongDoanhThu.Text = Convert(ThongKeBL.Instance.GetTongDoanhThu()) + " ₫";
            lbTongKhachHang.Text = ThongKeBL.Instance.GetTongKhachHang().ToString();
            Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cboDoanhThu_SelectedValueChanged(object sender, EventArgs e)
        {
            //lblDoanhThu.Text = "Biểu Đồ Doanh Thu " + cboDoanhThu.SelectedItem.ToString();
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Series.Add("Doanh Thu");
            chartDoanhThu.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chartDoanhThu.Series["Doanh Thu"].Font = new Font("UTM Avo", 10, FontStyle.Bold);
            chartDoanhThu.Series["Doanh Thu"].BorderColor = Color.Orange;
            chartDoanhThu.Series["Doanh Thu"].BorderWidth = 2;

            List<DoanhThuDTO> lstdt = new List<DoanhThuDTO>();
            double doanhthu = 0;
            DoanhThuDTO dtDTO;
            switch (cboDoanhThu.SelectedItem.ToString())
            {
                case "Hôm nay":
                    doanhthu = ThongKeBL.Instance.GetDoanhThuHomNay();
                    chartDoanhThu.Series["Doanh Thu"].Points.Add(doanhthu);
                    chartDoanhThu.Series["Doanh Thu"].Points[0].AxisLabel = DateTime.Now.ToShortDateString();
                    chartDoanhThu.Series["Doanh Thu"].Points[0].LegendText = DateTime.Now.ToShortDateString();
                    chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                    chartDoanhThu.Series["Doanh Thu"].Points[0].Label = Convert(doanhthu).ToString() + " ₫";
                    break;
                case "Hôm qua":
                    dtDTO = ThongKeBL.Instance.GetDoanhThuHomQua();
                    if (dtDTO != null)
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.DoanhThu);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].AxisLabel = dtDTO.Ngay.ToShortDateString();
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LegendText = DateTime.Now.ToShortDateString();
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = Convert(dtDTO.DoanhThu).ToString() + " ₫";
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "7 ngày qua":
                    lstdt = ThongKeBL.Instance.GetDoanhThu7NgayQua();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.DoanhThu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.DoanhThu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "Tháng này":
                    lstdt = ThongKeBL.Instance.GetDoanhThuThangNay();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.DoanhThu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.DoanhThu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "Tháng trước":
                    lstdt = ThongKeBL.Instance.GetDoanhThuThangTruoc();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.DoanhThu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.Ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.DoanhThu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                default:
                    break;
            }
        }


        private void cboTopSanPham1_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }



        private void cboTopSanPham2_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null && cboTopSanPham1.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.SoLuong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.SoLuong + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = ThongKeBL.Instance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.TongDoanhThu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.MaSP.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.TenSP;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.TongDoanhThu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }
    }
}
