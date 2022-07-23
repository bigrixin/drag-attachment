
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class SpecialAwards : UserAttachment
	{
		#region Ctor

		protected SpecialAwards()
		{
			// required by EF
		}

		public SpecialAwards(int userID) : this(userID, null)
		{
		}

		public SpecialAwards(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.SpecialAwards;

		public override string GetFriendlyName() => "Police Criminal Records Check";

		#endregion
	}
}