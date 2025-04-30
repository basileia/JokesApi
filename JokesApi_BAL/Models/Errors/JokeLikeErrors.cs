namespace JokesApi_BAL.Models.Errors
{
    public class JokeLikeErrors
    {
        public static readonly Error AlreadyLiked = new("JokeLikes.AlreadyLiked", "You have already liked this joke.");
    }
}
