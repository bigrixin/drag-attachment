
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class Qualifications : UserAttachment
	{

		#region Ctor

		protected Qualifications()
		{
			// required by EF
		}

		public Qualifications(int userID) : this(userID, null)
		{
		}

		public Qualifications(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.Qualifications;

		public override string GetFriendlyName() => "Certificate / Degree";

		#endregion
	}
}
