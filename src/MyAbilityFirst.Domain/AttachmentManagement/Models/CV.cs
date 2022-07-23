
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class CV : UserAttachment
	{
		#region Ctor

		protected CV()
		{
			// required by EF
		}

		public CV(int userID) : this(userID, null)
		{
		}

		public CV(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.CV;

		public override string GetFriendlyName() => "CV";

		#endregion

	}
}
