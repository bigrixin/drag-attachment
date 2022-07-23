

namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class DriverLicense : UserAttachment
	{
		#region Ctor

		protected DriverLicense()
		{
			// required by EF
		}

		public DriverLicense(int userID) : this(userID, null)
		{
		}

		public DriverLicense(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.DriverLicense;

		public override string GetFriendlyName() => "Driver License";

		#endregion
	}
}
