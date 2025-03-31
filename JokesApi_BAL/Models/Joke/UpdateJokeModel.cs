using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesApi_BAL.Models.Joke
{
    public class UpdateJokeModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
    }
}
