using PM_QuanLyCuaHangTruyenTranh.Helpers;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new LoginForm());
             //Application.Run(new AdminForm(null));

            /* string senderEmail = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderEmail"]);
             string senderPassword = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderPass"]);
             Console.WriteLine("Decrypted Email: " + senderEmail);
             Console.WriteLine("Decrypted Password: " + senderPassword);
             */

            // in ra AES key để kiểm tra
            /*  using (var db = new AppDbContext())
              {
                  // Kiểm tra nếu chưa có admin nào
                  if (!db.Admins.Any())
                  {
                      var admin = new Admin
                      {
                          MaAdmin = "AD001",
                          TenDangNhap = "admin",
                          MatKhau = PasswordHelper.HashPassword("123456"), // mật khẩu được mã hóa
                          Email = "admin@example.com"
                      };

                      db.Admins.Add(admin);
                      db.SaveChanges();

                      Console.WriteLine("✅ Đã thêm tài khoản admin mặc định (admin / 123456)");
                  }
                  else
                  {
                      Console.WriteLine("⚙️ Đã có tài khoản admin trong hệ thống, bỏ qua.");
                  }
              }

              Console.WriteLine("Nhấn Enter để thoát...");
              Console.ReadLine();*/
            /* using (var db = new AppDbContext())
              {


                  if (!db.Sachs.Any())
                  {
                      // ======== THỂ LOẠI ========
                      var hanhDong = new TheLoai { MaTheLoai = "TL01", TenTheLoai = "Hành Động", GhiChu = "Truyện có yếu tố chiến đấu, phiêu lưu" };
                      var haiHuoc = new TheLoai { MaTheLoai = "TL02", TenTheLoai = "Hài Hước", GhiChu = "Truyện gây cười, giải trí nhẹ nhàng" };
                      var tinhCam = new TheLoai { MaTheLoai = "TL03", TenTheLoai = "Tình Cảm", GhiChu = "Truyện về tình yêu, cảm xúc con người" };
                      var kinhDi = new TheLoai { MaTheLoai = "TL04", TenTheLoai = "Kinh Dị", GhiChu = "Truyện rùng rợn, bí ẩn" };
                      var hocDuong = new TheLoai { MaTheLoai = "TL05", TenTheLoai = "Học Đường", GhiChu = "Truyện xoay quanh đời sống học sinh" };
                      var phieuLuu = new TheLoai { MaTheLoai = "TL06", TenTheLoai = "Phiêu Lưu", GhiChu = "Truyện khám phá, hành trình mạo hiểm" };
                      var giaTuong = new TheLoai { MaTheLoai = "TL07", TenTheLoai = "Giả Tưởng", GhiChu = "Thế giới tưởng tượng, phép thuật" };
                      var khoaHoc = new TheLoai { MaTheLoai = "TL08", TenTheLoai = "Khoa Học Viễn Tưởng", GhiChu = "Truyện về tương lai, công nghệ" };
                      var trinhTham = new TheLoai { MaTheLoai = "TL09", TenTheLoai = "Trinh Thám", GhiChu = "Phá án, điều tra, bí ẩn" };

                      db.TheLoais.AddRange(new[] { hanhDong,haiHuoc,tinhCam, kinhDi, hocDuong, phieuLuu, giaTuong, khoaHoc, trinhTham });

                      // ======== TRUYỆN TRANH ========
                      var sachs = new List<Sach>
          {
              new Sach { MaSach = "S001", TenSach = "One Piece", SoTrang = 200, GioiThieu = "Hành trình của Luffy cùng đồng đội trên biển tìm kho báu One Piece.", TacGia = "Eiichiro Oda", BiaSach = TaiAnhTuInternet("https://static0.srcdn.com/wordpress/wp-content/uploads/2023/07/one-piece-franchise-poster.jpg?q=70&fit=contain&w=280&dpr=1"), TheLoais = new List<TheLoai> { hanhDong, phieuLuu, haiHuoc } },
              new Sach { MaSach = "S002", TenSach = "Naruto", SoTrang = 190, GioiThieu = "Câu chuyện về ninja Naruto và hành trình trở thành Hokage.", TacGia = "Masashi Kishimoto", BiaSach = TaiAnhTuInternet("https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg"), TheLoais = new List<TheLoai> { hanhDong, phieuLuu } },
              new Sach { MaSach = "S003", TenSach = "Your Name", SoTrang = 150, GioiThieu = "Một câu chuyện tình cảm đầy cảm xúc giữa hai người xa lạ bị hoán đổi thân xác.", TacGia = "Makoto Shinkai", BiaSach = TaiAnhTuInternet("https://upload.wikimedia.org/wikipedia/en/0/0b/Your_Name_poster.png"), TheLoais = new List<TheLoai> { tinhCam, giaTuong } },
              new Sach { MaSach = "S004", TenSach = "Attack on Titan", SoTrang = 230, GioiThieu = "Cuộc chiến sinh tồn giữa loài người và Titan khổng lồ.", TacGia = "Hajime Isayama", BiaSach = TaiAnhTuInternet("https://i.ebayimg.com/images/g/fqEAAOSwB-1YtiGV/s-l400.jpg"), TheLoais = new List<TheLoai> { hanhDong, phieuLuu, kinhDi } },
              new Sach { MaSach = "S005", TenSach = "Demon Slayer", SoTrang = 210, GioiThieu = "Câu chuyện của Tanjiro trong hành trình tiêu diệt quỷ để cứu em gái.", TacGia = "Koyoharu Gotouge", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/86/1d/95/861d95dc646bec1dedde1586adf896e3.jpg"), TheLoais = new List<TheLoai> { hanhDong, giaTuong } },
              new Sach { MaSach = "S006", TenSach = "Spy x Family", SoTrang = 160, GioiThieu = "Một điệp viên lập gia đình giả để hoàn thành nhiệm vụ bí mật.", TacGia = "Tatsuya Endo", BiaSach = TaiAnhTuInternet("https://mixmangastore.com/cdn/shop/files/12.jpg?v=1691219705"), TheLoais = new List<TheLoai> { haiHuoc, tinhCam, hanhDong } },
              new Sach { MaSach = "S007", TenSach = "Death Note", SoTrang = 180, GioiThieu = "Câu chuyện về cuốn sổ tử thần cho phép người viết giết bất kỳ ai.", TacGia = "Tsugumi Ohba", BiaSach = TaiAnhTuInternet("https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg"), TheLoais = new List<TheLoai> { trinhTham, kinhDi } },
              new Sach { MaSach = "S008", TenSach = "Detective Conan", SoTrang = 250, GioiThieu = "Cậu thám tử học sinh giải mã những vụ án hóc búa.", TacGia = "Gosho Aoyama", BiaSach = TaiAnhTuInternet("https://www.manga-news.com/public/images/vols/detective-conan-97-kana.jpg"), TheLoais = new List<TheLoai> { trinhTham, hocDuong } },
              new Sach { MaSach = "S009", TenSach = "Tokyo Ghoul", SoTrang = 220, GioiThieu = "Một sinh viên đại học trở thành bán quỷ sau tai nạn định mệnh.", TacGia = "Sui Ishida", BiaSach = TaiAnhTuInternet("http://www.manga-sanctuary.com/imageslesseries2/tokyo-ghoul-manga-volume-1-francaise-73492[1].jpg"), TheLoais = new List<TheLoai> { kinhDi, hanhDong } },
              new Sach { MaSach = "S010", TenSach = "Blue Lock", SoTrang = 200, GioiThieu = "Giải đấu đào tạo tiền đạo đỉnh cao trong bóng đá Nhật Bản.", TacGia = "Muneyuki Kaneshiro", BiaSach = TaiAnhTuInternet("https://cdn.kobo.com/book-images/d0259d14-58b5-443a-b4a3-f59ebd47a85b/1200/1200/False/blue-lock-20.jpg"), TheLoais = new List<TheLoai> { hanhDong, hocDuong } },
              new Sach { MaSach = "S011", TenSach = "Jujutsu Kaisen", SoTrang = 190, GioiThieu = "Học sinh trung học chiến đấu chống lại lời nguyền và linh hồn ác.", TacGia = "Gege Akutami", BiaSach = TaiAnhTuInternet("https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/jujutsu-kaisen-manga-cover-4-william-stratton.jpg"), TheLoais = new List<TheLoai> { hanhDong, giaTuong } },
              new Sach { MaSach = "S012", TenSach = "Chainsaw Man", SoTrang = 210, GioiThieu = "Câu chuyện về Denji – thợ săn quỷ có trái tim của một con quỷ cưa máy.", TacGia = "Tatsuki Fujimoto", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/736x/5b/56/78/5b5678fc43d0cf4566e65546efd2cfa5.jpg"), TheLoais = new List<TheLoai> { hanhDong, kinhDi } },
              new Sach { MaSach = "S013", TenSach = "Dr. Stone", SoTrang = 170, GioiThieu = "Nhân loại bị hóa đá, hai thiên tài tái thiết nền văn minh từ đầu.", TacGia = "Riichiro Inagaki", BiaSach = TaiAnhTuInternet("https://www.manga-news.com/public/images/vols/Dr_Stone_-_Tome_24_-_Gl_nat.jpg"), TheLoais = new List<TheLoai> { khoaHoc, phieuLuu } },
              new Sach { MaSach = "S014", TenSach = "My Hero Academia", SoTrang = 210, GioiThieu = "Thế giới nơi ai cũng có siêu năng lực và hành trình trở thành anh hùng.", TacGia = "Kohei Horikoshi", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/736x/c8/41/e7/c841e78626b3cf416ce1bc185e1543f6.jpg"), TheLoais = new List<TheLoai> { hanhDong, hocDuong, giaTuong } },
              new Sach { MaSach = "S015", TenSach = "Fairy Tail", SoTrang = 230, GioiThieu = "Câu chuyện về hội pháp sư Fairy Tail và những cuộc phiêu lưu huyền ảo.", TacGia = "Hiro Mashima", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/10/f6/85/10f68546e22d27fc4df8c6d221bbdcc6.png"), TheLoais = new List<TheLoai> { giaTuong, phieuLuu } },
              new Sach { MaSach = "S016", TenSach = "Sword Art Online", SoTrang = 180, GioiThieu = "Người chơi bị mắc kẹt trong thế giới thực tế ảo và phải chiến đấu để thoát ra.", TacGia = "Reki Kawahara", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/e3/fa/75/e3fa753ceabf2095350e89f849485ca7.png"), TheLoais = new List<TheLoai> { giaTuong, khoaHoc } },
              new Sach { MaSach = "S017", TenSach = "A Silent Voice", SoTrang = 160, GioiThieu = "Một chàng trai từng bắt nạt bạn khiếm thính và hành trình chuộc lỗi của mình.", TacGia = "Yoshitoki Oima", BiaSach = TaiAnhTuInternet("https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/a-silent-voice-anime-poster-elizabeth-king.jpg"), TheLoais = new List<TheLoai> { tinhCam, hocDuong } },
              new Sach { MaSach = "S018", TenSach = "Parasyte", SoTrang = 200, GioiThieu = "Sinh vật ký sinh xâm chiếm con người, tạo nên những sinh vật quái dị.", TacGia = "Hitoshi Iwaaki", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/e3/5a/e8/e35ae8083a43c49729d206bfe9036507.jpg"), TheLoais = new List<TheLoai> { kinhDi, khoaHoc } },
              new Sach { MaSach = "S019", TenSach = "Black Clover", SoTrang = 220, GioiThieu = "Cậu bé không phép thuật quyết tâm trở thành Ma pháp vương.", TacGia = "Yūki Tabata", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/55/b3/4e/55b34ed676329d360be068d576e9098a.jpg"), TheLoais = new List<TheLoai> { hanhDong, giaTuong } },
              new Sach { MaSach = "S020", TenSach = "Haikyuu!!", SoTrang = 200, GioiThieu = "Câu chuyện cảm động về đội bóng chuyền trung học Karasuno.", TacGia = "Haruichi Furudate", BiaSach = TaiAnhTuInternet("https://i.pinimg.com/originals/ce/a7/98/cea7987217ebc08748342c83c77f3208.jpg"), TheLoais = new List<TheLoai> { hocDuong, hanhDong } }
          };

                      db.Sachs.AddRange(sachs);
                      db.SaveChanges();

                      MessageBox.Show("Đã thêm dữ liệu mẫu (20 truyện) thành công!", "Khởi tạo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  else
                  {
                      MessageBox.Show("Dữ liệu đã tồn tại, không cần khởi tạo thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
              }

             // Console.WriteLine("Hoàn tất. Nhấn phím bất kỳ để thoát...");
             MessageBox.Show("Hoàn tất thêm dữ liệu mẫu. Nhấn OK để thoát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              //Console.ReadKey();


          }
               static byte[] TaiAnhTuInternet(string url)
                {
                try
                {
                    using (var webClient = new WebClient())
                    {
                        // Giả lập trình duyệt để tránh bị chặn 403
                        webClient.Headers.Add("User-Agent",
                            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                            "AppleWebKit/537.36 (KHTML, like Gecko) " +
                            "Chrome/124.0.0.0 Safari/537.36");

                        return webClient.DownloadData(url);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải ảnh từ {url}:\n{ex.Message}",
                        "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }*/
        }
    }
} //xoa khi mo hai c dong  /* o tren






