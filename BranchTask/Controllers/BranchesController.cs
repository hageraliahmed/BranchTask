
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BranchTask.Controllers
{
	public class BranchesController : Controller
	{
		private readonly BranchContext _branchContext;

		public BranchesController(BranchContext branchContext)
		{
			_branchContext = branchContext;
		}

		public IActionResult Index()
		{
            var totalBranches = _branchContext.Branch.Count(); // Get total count of branches
            ViewBag.TotalBranches = totalBranches; // Pass total count to view

            var branch = _branchContext.Branch.FirstOrDefault();
			if(branch == null) {         //there isn't any branch in database
                Branch branchModel = new Branch { };
                return View(branchModel);
            }
            
            return View(branch);
		}

		/////////////////////////////////////////////////////////////

		

		
		public IActionResult AddBranch()
		{
			Branch newBranch = new Branch { };

			_branchContext.Branch.Add(newBranch);
			_branchContext.SaveChanges();

            var totalBranches = _branchContext.Branch.Count(); 
            ViewBag.TotalBranches = totalBranches;

            return View("Index", newBranch);
		}

		////////////////////////////////////////////////////////////
	

		[HttpPost]
		public IActionResult SaveBranch(int id, Branch branch)
		{

            if (!ModelState.IsValid)
			{
				return View("Index", branch);
			}

			var branchToUpdate = _branchContext.Branch.FirstOrDefault(b => b.BranchId == id);
			if (branchToUpdate == null)
			{
				return RedirectToAction(nameof(Index));
			}

			branchToUpdate.CustomNo = branch.CustomNo;
			branchToUpdate.ArabicName = branch.ArabicName;
			branchToUpdate.ArabicDescription = branch.ArabicDescription;
			branchToUpdate.EnglishName = branch.EnglishName;
			branchToUpdate.EnglishDescription = branch.EnglishDescription;
			branchToUpdate.Note = branch.Note;
			branchToUpdate.Address = branch.Address;
			_branchContext.SaveChanges();

            var totalBranches = _branchContext.Branch.Count();
            ViewBag.TotalBranches = totalBranches;

            return View("Index", branchToUpdate);
		}

        ////////////////////////////////////////////////////
        public IActionResult NextBranch(int id)
        {
            var currentBranch = _branchContext.Branch.FirstOrDefault(b => b.BranchId == id);
            if (currentBranch == null)
            {
                return RedirectToAction(nameof(Index));
            }
			id = id + 1;
            var nextBranch = _branchContext.Branch.FirstOrDefault(b => b.BranchId == id);

            if (nextBranch == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var totalBranches = _branchContext.Branch.Count();
            ViewBag.TotalBranches = totalBranches;

            return View("Index", nextBranch);
        }

        ////////////////////////////////////////////////////////////////
        public IActionResult PreviousBranch(int id)
        {
            var currentBranch = _branchContext.Branch.FirstOrDefault(b => b.BranchId == id);
            if (currentBranch == null)
            {
                return RedirectToAction(nameof(Index));
            }
            id = id -1;
            var previousBranch = _branchContext.Branch.FirstOrDefault(b => b.BranchId == id);
            if (previousBranch == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var totalBranches = _branchContext.Branch.Count();
            ViewBag.TotalBranches = totalBranches;

            return View("Index", previousBranch);
        }

    }
}
