using MyAbilityFirst.Domain.AttachmentManagement;
using System.Collections.Generic;

namespace MyAbilityFirst.Models
{
	public class CareWorkerAttachmentViewModel
	{
		public int CareWorkerID { get; set; }

		// all attachments list
		public List<AttachmentType> AttachmentList { get; set; }

		// for tracking changes, contains previously uploaded attachment
		public List<UserAttachment> PreviousAttachmentList { get; set; }
	}
}
