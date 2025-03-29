namespace JokesApi_BAL.Models.Errors
{
    //record-immutable, class-mutable; 
    public record Error(string Code, string? Description = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}
