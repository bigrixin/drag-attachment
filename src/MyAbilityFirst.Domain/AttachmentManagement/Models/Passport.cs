using System;
using System.Collections.Generic;

namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class Passport : UserAttachment
	{
		#region Ctor

		protected Passport()
		{
			// required by EF
		}

		public Passport(int userID) : this(userID, null)
		{
		}

		public Passport(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.Passport;

		public override string GetFriendlyName() => "Passport and Visa";

		#endregion
	}
}
