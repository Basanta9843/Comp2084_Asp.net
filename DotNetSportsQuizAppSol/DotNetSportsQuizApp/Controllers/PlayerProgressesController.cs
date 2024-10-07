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
    public class PlayerProgressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerProgressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerProgresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerProgress.ToListAsync());
        }

        // GET: PlayerProgresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProgress = await _context.PlayerProgress
                .FirstOrDefaultAsync(m => m.PlayerProgressId == id);
            if (playerProgress == null)
            {
                return NotFound();
            }

            return View(playerProgress);
        }

        // GET: PlayerProgresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerProgresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerProgressId,PlayerName,CurrentScore,TotalQuestions,CorrectAnswers,SportsQuizId")] PlayerProgress playerProgress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerProgress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerProgress);
        }

        // GET: PlayerProgresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProgress = await _context.PlayerProgress.FindAsync(id);
            if (playerProgress == null)
            {
                return NotFound();
            }
            return View(playerProgress);
        }

        // POST: PlayerProgresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerProgressId,PlayerName,CurrentScore,TotalQuestions,CorrectAnswers,SportsQuizId")] PlayerProgress playerProgress)
        {
            if (id != playerProgress.PlayerProgressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerProgress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerProgressExists(playerProgress.PlayerProgressId))
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
            return View(playerProgress);
        }

        // GET: PlayerProgresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProgress = await _context.PlayerProgress
                .FirstOrDefaultAsync(m => m.PlayerProgressId == id);
            if (playerProgress == null)
            {
                return NotFound();
            }

            return View(playerProgress);
        }

        // POST: PlayerProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerProgress = await _context.PlayerProgress.FindAsync(id);
            if (playerProgress != null)
            {
                _context.PlayerProgress.Remove(playerProgress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerProgressExists(int id)
        {
            return _context.PlayerProgress.Any(e => e.PlayerProgressId == id);
        }
    }
}
