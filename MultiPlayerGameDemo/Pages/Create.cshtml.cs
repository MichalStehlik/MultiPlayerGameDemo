using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MultiPlayerGameDemo.Models;
using MultiPlayerGameDemo.Services;

namespace MultiPlayerGameDemo
{
    public class CreateModel : PageModel
    {
        protected ApplicationDbContext _db;
        protected RandomStringGenerator _rsg;

        public string Player1Code { get; set; }
        public string Player2Code { get; set; }

        public CreateModel(ApplicationDbContext db, RandomStringGenerator rsg)
        {
            _db = db;
            _rsg = rsg;
        }

        public void OnGet()
        {
            string p1c;
            do
            {
                p1c = _rsg.Next(5);
            }
            while (_db.Games.Where(g => ((g.Player1Id == p1c) || (g.Player2Id == p1c))).ToList().Count > 0);
            string p2c;
            do
            {
                p2c = _rsg.Next(5);
            }
            while (_db.Games.Where(g => ((g.Player1Id == p2c) || (g.Player2Id == p2c))).ToList().Count > 0);
            _db.Games.Add(new Game { Player1Id = p1c, Player2Id = p2c, Turn = 0 }); ;
            _db.SaveChanges();
            Player1Code = p1c;
            Player2Code = p2c;
        }
    }
}