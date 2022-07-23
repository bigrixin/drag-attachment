
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class CPRAndFirstAidCertificate : UserAttachment
	{
		#region Ctor

		protected CPRAndFirstAidCertificate()
		{
			// required by EF
		}

		public CPRAndFirstAidCertificate(int userID) : this(userID, null)
		{
		}

		public CPRAndFirstAidCertificate(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.CPRAndFirstAidCertificate;

		public override string GetFriendlyName() => "CPR and First Aid Certificate";

		#endregion
	}
}
