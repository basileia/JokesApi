﻿using System.ComponentModel.DataAnnotations;

namespace JokesApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Joke>? Jokes { get; }  
    }
}
