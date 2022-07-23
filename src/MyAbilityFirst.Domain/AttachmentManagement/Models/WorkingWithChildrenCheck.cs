
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class WorkingWithChildrenCheck : UserAttachment
	{
		#region Ctor

		protected WorkingWithChildrenCheck()
		{
			// required by EF
		}

		public WorkingWithChildrenCheck(int userID) : this(userID, null)
		{
		}

		public WorkingWithChildrenCheck(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.WorkingWithChildrenCheck;

		public override string GetFriendlyName() => "Working With Children Check";

		#endregion
	}
}