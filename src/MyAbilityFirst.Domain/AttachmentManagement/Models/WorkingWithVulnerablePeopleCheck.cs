
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class WorkingWithVulnerablePeopleCheck : UserAttachment
	{
		#region Ctor

		protected WorkingWithVulnerablePeopleCheck()
		{
			// required by EF
		}

		public WorkingWithVulnerablePeopleCheck(int userID) : this(userID, null)
		{
		}

		public WorkingWithVulnerablePeopleCheck(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.WorkingWithVulnerablePeopleCheck;

		public override string GetFriendlyName() => "Working With Vulnerable People Check";

		#endregion
	}
}