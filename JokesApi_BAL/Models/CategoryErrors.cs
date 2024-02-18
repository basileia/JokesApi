namespace JokesApi_BAL.Models
{
    public static class CategoryErrors
    {
        public static readonly Error CategoryNotFound = new("Categories.NotFound", "Category not found");
        public static readonly Error CategoryExists = new("Categories.AlreadyExists", "Category already exists");
        public static readonly Error CategoryBadRequest = new("Categories.DifferentIds", "The id in the path must be the same as the category id.");
    }
}
