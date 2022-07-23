using MyAbilityFirst.Domain;

namespace MyAbilityFirst.Models
{
	public class CareWorkerPublicProfileViewModel
	{
		public int CareWorkerID { get; set; }
		
		// User
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		

		// CareWorker
		public int LocationCoverageRadius { get; set; }
		public string Description { get; set; }
		public string Culture { get; set; }
		public string Personality { get; set; }
		public double OverallRating { get; set; }
		public decimal? HomeLatitude { get; set; }
		public decimal? HomeLongitude { get; set; }

		// Shortlist
		public ShortlistViewModel ShortlistViewModel { get; set; }
	}
}