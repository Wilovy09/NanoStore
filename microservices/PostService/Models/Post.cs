using System.ComponentModel.DataAnnotations;

namespace PostModel.Models
{
    public class Post
    {
        public int Id { get; set; }
        required public int owner_id { get; set; }
        [MinLength(1), MaxLength(254)]
        required public string title { get; set; }
        required public string description { get; set; }
        required public string image { get; set; }
    }
}
