
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class Referencees : UserAttachment
	{
		#region Ctor

		protected Referencees()
		{
			// required by EF
		}

		public Referencees(int userID) : this(userID, null)
		{
		}

		public Referencees(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.Referencees;

		public override string GetFriendlyName() => "References";

		#endregion
	}
}
