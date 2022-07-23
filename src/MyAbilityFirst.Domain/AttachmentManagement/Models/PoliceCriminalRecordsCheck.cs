
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class PoliceCriminalRecordsCheck : UserAttachment
	{
		#region Ctor

		protected PoliceCriminalRecordsCheck()
		{
			// required by EF
		}

		public PoliceCriminalRecordsCheck(int userID) : this(userID, null)
		{
		}

		public PoliceCriminalRecordsCheck(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.PoliceCriminalRecordsCheck;

		public override string GetFriendlyName() => "Police Criminal Records Check";

		#endregion
	}
}
