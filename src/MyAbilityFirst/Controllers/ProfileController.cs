using AutoMapper;
using MyAbilityFirst.Domain;
using MyAbilityFirst.Models;
using MyAbilityFirst.Services.CareWorkerFunctions;
using System;
using System.Web.Mvc;

namespace MyAbilityFirst.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ICareWorkerService _careWorkerServices;
		private readonly IMapper _mapper;

		public ProfileController(ICareWorkerService careWorkerServices, IMapper mapper)
		{
			_careWorkerServices = careWorkerServices;
			_mapper = mapper;
		}

		[AllowAnonymous]
		[HttpGet]
		public ActionResult PublicProfile(int id)
		{
			CareWorkerPublicProfileViewModel vm = new CareWorkerPublicProfileViewModel();
			if (_careWorkerServices.RetrieveCareWorker(id) == null)
			{
				return RedirectToAction("Index", "Home");
			}
			CareWorker careworker = _careWorkerServices.RetrieveCareWorker(id);
			vm = _mapper.Map(careworker, vm);
			vm.CareWorkerID = id;
			vm.OverallRating = Math.Round(careworker.TotalRating / careworker.RatingCount, 1);
			return View(vm);
		}

	}
}