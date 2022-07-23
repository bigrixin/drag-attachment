
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class BirthCertificate : UserAttachment
	{

		#region Ctor

		protected BirthCertificate()
		{
			// required by EF
		}

		public BirthCertificate(int userID) : this(userID, null)
		{
		}

		public BirthCertificate(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.BirthCertificate;

		public override string GetFriendlyName() => "Birth Certificate";

		#endregion

	}
}