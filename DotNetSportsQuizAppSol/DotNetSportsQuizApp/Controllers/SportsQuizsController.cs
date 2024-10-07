using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetSportsQuizApp.Data;
using DotNetSportsQuizApp.Models;

namespace DotNetSportsQuizApp.Controllers
{
    public class SportsQuizsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportsQuizsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportsQuizs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SportsQuiz.ToListAsync());
        }

        // GET: SportsQuizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsQuiz = await _context.SportsQuiz
                .FirstOrDefaultAsync(m => m.SportsQuizId == id);
            if (sportsQuiz == null)
            {
                return NotFound();
            }

            return View(sportsQuiz);
        }

        // GET: SportsQuizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportsQuizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SportsQuizId,QuizTitle,SportType,QuizCreatedBy,CreatedDate")] SportsQuiz sportsQuiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportsQuiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportsQuiz);
        }


        // GET: SportsQuizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsQuiz = await _context.SportsQuiz.FindAsync(id);
            if (sportsQuiz == null)
            {
                return NotFound();
            }
            return View(sportsQuiz);
        }

        // POST: SportsQuizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SportsQuizId,QuizTitle,SportType,QuizCreatedBy,CreatedDate")] SportsQuiz sportsQuiz)
        {
            if (id != sportsQuiz.SportsQuizId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportsQuiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportsQuizExists(sportsQuiz.SportsQuizId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sportsQuiz);
        }

        // GET: SportsQuizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsQuiz = await _context.SportsQuiz
                .FirstOrDefaultAsync(m => m.SportsQuizId == id);
            if (sportsQuiz == null)
            {
                return NotFound();
            }

            return View(sportsQuiz);
        }

        // POST: SportsQuizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportsQuiz = await _context.SportsQuiz.FindAsync(id);
            if (sportsQuiz != null)
            {
                _context.SportsQuiz.Remove(sportsQuiz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportsQuizExists(int id)
        {
            return _context.SportsQuiz.Any(e => e.SportsQuizId == id);
        }
    }
}
