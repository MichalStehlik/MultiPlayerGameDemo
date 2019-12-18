using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiPlayerGameDemo.Models;

namespace MultiPlayerGameDemo
{
    public class SignModel : PageModel
    {
        protected ApplicationDbContext _db;
        [BindProperty]
        public string Code { get; set; }

        public SignModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Game game = _db.Games.Where(g => ((g.Player1Id == Code) || (g.Player2Id == Code))).FirstOrDefault();
                if (game == null)
                {
                    return RedirectToPage("InvalidCode");
                }
                else if (
                    (game.Player1Id == Code && (game.Turn % 2 == 0)) ||
                    (game.Player2Id == Code && (game.Turn % 2 == 1))
                )
                {
                    return RedirectToPage("Turn",new { Code = Code});
                }
                else
                {
                    return RedirectToPage("NotYourTurn");
                }
            }
            return Page();
        }
    }
}