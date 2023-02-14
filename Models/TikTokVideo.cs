namespace tiktok.Models
{
    public class TikTokVideo
    {
        public List<TikTokVideo> video { get; set; }
        public List<TikTokVideo> music { get; set; }
        public List<TikTokVideo> cover { get; set; }
        public List<TikTokVideo> OriginalWatermarkedVideo { get; set; }
        public List<TikTokVideo> description { get; set; }
        public List<TikTokVideo> dynamic_cover { get; set; }
        public List<TikTokVideo> author { get; set; }
        public List<TikTokVideo> region { get; set; }
        public List<TikTokVideo> avatar_thumb { get; set; }
        public List<TikTokVideo> custom_verify { get; set; }
        public List<TikTokVideo> videoid { get; set; }
        public String post_type { get; set; }
    }
}
