using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bai11_3.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bai11_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDanhSach();
        }
        private void HienThiDanhSach()
        {
            var ketqua = from SanPham in db.SanPhams
                         join LoaiSanPham in db.LoaiSanPhams on SanPham.MaLoai equals LoaiSanPham.MaLoai
                         select new
                         {
                             MaSp = SanPham.MaSp,
                             TenSp = SanPham.TenSp,
                             SoLuong = SanPham.SoLuong,
                             DonGia = SanPham.DonGia,
                             TenLoai = LoaiSanPham.TenLoai
                         };
            danhsachTable.ItemsSource = ketqua.ToList();
        }
        private void DeleteText()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtMaLoai.Text = "";
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "" || txtMaLoai.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    var maloai = (from LoaiSanPham in db.LoaiSanPhams
                                  where LoaiSanPham.TenLoai.Equals(txtMaLoai.Text)
                                  select LoaiSanPham.MaLoai).FirstOrDefault();
                    if(maloai != null)
                    {
                        SanPham sp = new SanPham();
                        sp.MaSp = txtMaSP.Text;
                        sp.TenSp = txtTenSP.Text;
                        sp.MaLoai = txtMaLoai.Text;
                        sp.DonGia = int.Parse(txtDonGia.Text);
                        sp.SoLuong = int.Parse(txtSoLuong.Text);

                        if (!db.SanPhams.Contains(sp))
                        {
                            db.SanPhams.Add(sp);
                            db.SaveChanges();
                            HienThiDanhSach();
                            DeleteText();
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm đã tồn tại");
                        }
                    }else
                    {
                        MessageBox.Show("Không tìm thấy lọai sản phẩm");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMaSP.Text == "")
                {
                    MessageBox.Show("Không được để trống MaSP");
                }
                else
                {
                    var sp = (from SanPham in db.SanPhams
                              where SanPham.MaSp == txtMaSP.Text
                              select SanPham).FirstOrDefault();

                    if (db.SanPhams.Contains(sp))
                    {
                        db.SanPhams.Remove(sp);
                        db.SaveChanges();
                        HienThiDanhSach();
                        DeleteText();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm này");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMaSP.Text == "")
                {
                    MessageBox.Show("Không được để trống MaSP");
                }
                else
                {
                    var maloai = (from LoaiSanPham in db.LoaiSanPhams
                                  where LoaiSanPham.TenLoai.Equals(txtMaLoai.Text)
                                  select LoaiSanPham.MaLoai).FirstOrDefault();
                    if (maloai != null)
                    {
                        var sp = (from SanPham in db.SanPhams
                                  where SanPham.MaSp == txtMaSP.Text
                                  select SanPham).FirstOrDefault();

                        if (sp != null)
                        {
                            sp.TenSp = txtTenSP.Text;
                            sp.MaLoai = txtMaLoai.Text;
                            sp.DonGia = int.Parse(txtDonGia.Text);
                            sp.SoLuong = int.Parse(txtSoLuong.Text);
                            db.SaveChanges();
                            HienThiDanhSach();
                            DeleteText();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm này");
                        }
                    } else
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm này");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ShowItemDanhSach(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                dynamic sp = danhsachTable.SelectedItem;
                if (sp != null)
                {
                    string tenloai = sp.TenLoai;
                    var maloai = (from LoaiSanPham in db.LoaiSanPhams
                                 where LoaiSanPham.TenLoai.Equals(tenloai)
                                 select LoaiSanPham.MaLoai).FirstOrDefault();
                    txtMaSP.Text = sp.MaSp;
                    txtTenSP.Text = sp.TenSp;
                    txtDonGia.Text = sp.DonGia.ToString();
                    txtSoLuong.Text = sp.SoLuong.ToString();
                    txtMaLoai.Text = maloai.ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
