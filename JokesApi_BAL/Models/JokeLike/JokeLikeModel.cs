namespace JokesApi_BAL.Models.JokeLike
{
    public class JokeLikeModel
    {
        public int JokeId { get; set; }
        public int LikeCount { get; set; }
        public bool IsLikedByUser { get; set; }
    }
}
