using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class VideoRepos : IVideoContext
    {
        private VideoContext _context { get; set; }
        public VideoRepos()
        {
            _context = new VideoContext();
        }
        public IEnumerable<Video> getUnProcessedVideos()
        {
            var videos = from video in _context.Videos
                         where !video.IsProcessed
                         select video;
            return videos.ToList();
        }
    }
}
