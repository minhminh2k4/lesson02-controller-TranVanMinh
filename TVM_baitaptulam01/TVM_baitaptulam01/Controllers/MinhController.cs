using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVM_baitaptulam01.Models;
using System.Web.UI.WebControls;

namespace TVM_baitaptulam01.Controllers
{
    public class MinhController : Controller
    {
        // GET: Minh
        private List<Song> GetSongs()
        {
            return new List<Song>
            {
                new Song{ Id = 1 , FileName = "spotifydown.com - Bật Tình Yêu Lên.mp3" },
                new Song{ Id = 2 , FileName = "spotifydown.com - Missing You.mp3" },
                new Song{ Id = 3 , FileName = "spotifydown.com - Anh Là Ngoại Lệ Của Em.mp3" },
                new Song{ Id = 4 , FileName = "spotifydown.com - Quá Lâu.mp3" },
                new Song{ Id = 5 , FileName = "spotifydown.com - ưng quá chừng.mp3"},
                new Song{ Id = 6 , FileName = "spotifydown.com - Hãy Trao Cho Anh.mp3"},
                new Song{ Id = 7 , FileName = "spotifydown.com - Độ Tộc 2.mp3"},
            };
        }

        public ActionResult Index()
        {
            ViewBag.message = "Danh sách nhạc";
            return View();
        }

        // Action method để hiển thị danh sách bài hát
        public ActionResult ShowSongs()
        {
            List<Song> songs = GetSongs();
            return View(songs);
        }

        public ActionResult PreviewSong(int id)
        {
            Song song = GetSongs().FirstOrDefault(s => s.Id == id);
            return View(song);
        }

        // Action method để tải về một bài hát
        public ActionResult Download(int id)
        {
            // Lấy thông tin của bài hát theo Id
            Song song = GetSongs().FirstOrDefault(s => s.Id == id);

            if (song != null)
            {
                // Đường dẫn tới thư mục chứa các file bài hát
                string filePath = Server.MapPath("~/Content/Songs/" + song.FileName);

                // Trả về file để tải về
                return File(filePath, "audio/mpeg", song.FileName);
            }

            return View(song);
        }
    }
}