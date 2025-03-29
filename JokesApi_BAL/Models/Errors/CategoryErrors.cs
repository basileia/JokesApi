namespace JokesApi_BAL.Models.Errors
{
    public static class CategoryErrors
    {
        public static readonly NotFoundError CategoryNotFound = new("Categories.NotFound", "Category not found");
        public static readonly Error CategoryExists = new("Categories.AlreadyExists", "Category already exists");
        public static readonly Error CategoryBadRequest = new("Categories.DifferentIds", "The id in the path must be the same as the category id.");
        public static readonly Error CategoryIsEmpty = new("Categories.IsNullOrEmpty", "Category name is required");
    }
}
