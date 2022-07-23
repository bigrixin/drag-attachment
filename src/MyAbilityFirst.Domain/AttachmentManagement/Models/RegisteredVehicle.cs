
namespace MyAbilityFirst.Domain.AttachmentManagement
{
	public class RegisteredVehicle : UserAttachment
	{
		#region Ctor

		protected RegisteredVehicle()
		{
			// required by EF
		}

		public RegisteredVehicle(int userID) : this(userID, null)
		{
		}

		public RegisteredVehicle(int userID, string url) : base(userID, url)
		{
		}

		#endregion

		#region Helpers

		public override AttachmentType GetAttachmentType() => AttachmentType.RegisteredVehicle;

		public override string GetFriendlyName() => "References";

		#endregion
	}
}
