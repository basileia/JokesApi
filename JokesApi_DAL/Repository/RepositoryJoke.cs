//using JokesApi_DAL.Contracts;
//using JokesApi_DAL.Data;
//using JokesApi_DAL.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JokesApi_DAL.Repository
//{
//    public class RepositoryJoke : IRepositoryJoke
//    {
//        private readonly AppDbContext _context;

//        public RepositoryJoke(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<ActionResult<IEnumerable<Joke>>> GetAllJokes()
//        {
//            return await _context.Jokes.ToListAsync();
//        }

//        public async Task<Joke> GetJokeById(int id)
//        {
//            var joke = await _context.Jokes
//                .Include(_ => _.Category)
//                .Where(_ => _.Id == id)
//                .FirstOrDefaultAsync();
            
//            return joke;
//        }
//    }
//}
