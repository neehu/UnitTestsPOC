using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader { get; set; }
        private IVideoContext _videoContext { get; set; }

        public VideoService(IFileReader reader = null, IVideoContext context = null)
        {
            _fileReader = reader ?? new FileReader();
            _videoContext = context ?? new VideoRepos();
        }
        public string ReadVideoTitle()
        {
            var str = _fileReader.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _videoContext.getUnProcessedVideos();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    public interface IVideoContext
    {
        IEnumerable<Video> getUnProcessedVideos();
    }
}