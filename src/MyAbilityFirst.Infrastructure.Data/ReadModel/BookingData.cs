using Microsoft.SqlServer.Types;
using MyAbilityFirst.Domain;
using MyAbilityFirst.Domain.ClientFunctions;
using MyAbilityFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbilityFirst.Infrastructure.Data
{
	public class BookingData
	{

		#region Fields

		public readonly MyAbilityFirstDbContext _context;

		#endregion

		#region Ctor

		public BookingData(MyAbilityFirstDbContext context)
		{
			this._context = context;
		}

		#endregion

		#region Helpers

		public IEnumerable<NewBookingShortlistViewModel> GetShortlist(int ownerUserID)
		{
			var shortlists =
				from c in this._context.Clients
				join s in this._context.Shortlists on c.ID equals s.OwnerUserID
				join cw in this._context.CareWorkers on s.SelectedUserID equals cw.ID
				where c.ID == ownerUserID
				select new NewBookingShortlistViewModel
				{
					CareWorkerID = cw.ID,
					CareWorkerFirstName = cw.FirstName,
					CareWorkerLastName = cw.LastName
				};

			return shortlists;
		}

		public List<UpdateBookingViewModel> GetBookingVMListByCareWorker(int careWorkerID)
		{
			var vmList =
				from cw in this._context.CareWorkers
				join b in this._context.Bookings on cw.ID equals b.CareWorkerID
				join c in this._context.Clients on b.ClientID equals c.ID
				where cw.ID == careWorkerID
				orderby (b.UpdatedAt) descending
				select new UpdateBookingViewModel
				{
					BookingID = b.ID,
					OwnerUserID = b.ClientID,
					CareWorkerID=b.CareWorkerID,
					ClientFirstName = c.FirstName,
					CareWorkerFirstName = cw.FirstName,
					Schedule = b.Schedule,
					Message = b.Message,
					Status = b.Status,
					CaseNotes = b.CaseNotes.ToList(),
					Rating = b.Rating.ToList()
				};

			return vmList.ToList();
		}

		public List<UpdateBookingViewModel> GetBookingVMListByClient(int clientID)
		{
			var vmList =
				from c in this._context.Clients
				join b in this._context.Bookings on c.ID equals b.ClientID
				join cw in this._context.CareWorkers on b.CareWorkerID equals cw.ID
				where c.ID == clientID
				orderby (b.UpdatedAt) descending
				select new UpdateBookingViewModel
				{
					BookingID = b.ID,
					OwnerUserID = b.ClientID,
					CareWorkerID = b.CareWorkerID,
					ClientFirstName = c.FirstName,
					CareWorkerFirstName = cw.FirstName,
					Schedule = b.Schedule,
					Message = b.Message,
					Status = b.Status,
					CaseNotes = b.CaseNotes.ToList(),
					Rating = b.Rating.ToList(),
					Distance = (DbGeography.FromText("POINT(" + c.Address.Longitude.ToString() + " " +c.Address.Latitude.ToString()+ ")")
								.Distance(DbGeography.FromText("POINT(" + cw.Address.Longitude.ToString() + " " + cw.Address.Latitude.ToString()
						 + ")"))/1000).Value.ToString()
				};

			return vmList.ToList();
		}

 
		#endregion

	}
}
