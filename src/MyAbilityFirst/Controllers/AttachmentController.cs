using MyAbilityFirst.Domain.AttachmentManagement;
using MyAbilityFirst.Infrastructure;
using MyAbilityFirst.Services.AttachmentManagement;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


namespace MyAbilityFirst.Controllers
{
	[Authorize]
	[AuthorizeForAttachments]
	public class AttachmentController : Controller
	{

		#region Fields

		private readonly IReadEntities _entities;
		private readonly IAttachmentService _attachmentService;

		#endregion

		#region Ctor

		public AttachmentController(IReadEntities entities, IAttachmentService attachmentService)
		{
			this._entities = entities;
			this._attachmentService = attachmentService;
		}

		#endregion

		#region Actions

		public ActionResult Upload(AttachmentType itemId, int userID)
		{
			UserAttachment attached = null;
			HttpPostedFileBase file = Request.Files[0];
			if (file != null)
			{
				// for patient
				switch (itemId)
				{
					case AttachmentType.ProfilePhoto:
						attached = this._attachmentService.UploadAttachmentForPatient<ProfilePhoto>(userID, file);
						break;
					case AttachmentType.CarePlanDocument:
						attached = this._attachmentService.UploadAttachmentForPatient<CarePlanDocument>(userID, file);
						break;
					case AttachmentType.NdisPlanDocument:
						attached = this._attachmentService.UploadAttachmentForPatient<NdisPlanDocument>(userID, file);
						break;
					case AttachmentType.GpDocument:
						attached = this._attachmentService.UploadAttachmentForPatient<GpDocument>(userID, file);
						break;
					case AttachmentType.BirthCertificate:
						attached = this._attachmentService.UploadAttachmentForPatient<BirthCertificate>(userID, file);
						break;
					case AttachmentType.MedicareDocument:
						attached = this._attachmentService.UploadAttachmentForPatient<MedicareDocument>(userID, file);
						break;
					case AttachmentType.ProofOfAgeDocument:
						attached = this._attachmentService.UploadAttachmentForPatient<ProofOfAgeDocument>(userID, file);
						break;
					case AttachmentType.PsychologyReport:
						attached = this._attachmentService.UploadAttachmentForPatient<PsychologyReport>(userID, file);
						break;
					case AttachmentType.ReviewAssessmentReport:
						attached = this._attachmentService.UploadAttachmentForPatient<ReviewAssessmentReport>(userID, file);
						break;

					case AttachmentType.CV:      // for care worker
						attached = this._attachmentService.UploadAttachmentForCareWorker<CV>(userID, file);
						break;
					case AttachmentType.Qualifications:
						attached = this._attachmentService.UploadAttachmentForCareWorker<Qualifications>(userID, file);
						break;
					case AttachmentType.Referencees:
						attached = this._attachmentService.UploadAttachmentForCareWorker<Referencees>(userID, file);
						break;
					case AttachmentType.SpecialAwards:
						attached = this._attachmentService.UploadAttachmentForCareWorker<SpecialAwards>(userID, file);
						break;
					case AttachmentType.DriverLicense:
						attached = this._attachmentService.UploadAttachmentForCareWorker<DriverLicense>(userID, file);
						break;
					case AttachmentType.RegisteredVehicle:
						attached = this._attachmentService.UploadAttachmentForCareWorker<RegisteredVehicle>(userID, file);
						break;
					case AttachmentType.CPRAndFirstAidCertificate:
						attached = this._attachmentService.UploadAttachmentForCareWorker<CPRAndFirstAidCertificate>(userID, file);
						break;
					case AttachmentType.PoliceCriminalRecordsCheck:
						attached = this._attachmentService.UploadAttachmentForCareWorker<PoliceCriminalRecordsCheck>(userID, file);
						break;
					case AttachmentType.Passport:
						attached = this._attachmentService.UploadAttachmentForCareWorker<Passport>(userID, file);
						break;
					case AttachmentType.WorkingWithChildrenCheck:
						attached = this._attachmentService.UploadAttachmentForCareWorker<WorkingWithChildrenCheck>(userID, file);
						break;
					case AttachmentType.WorkingWithVulnerablePeopleCheck:
						attached = this._attachmentService.UploadAttachmentForCareWorker<WorkingWithVulnerablePeopleCheck>(userID, file);
						break;
					default:
						return Json(new
						{
							statusCode = 400,
							status = "Bad Request! Upload Failed",
							file = string.Empty
						}, JsonRequestBehavior.AllowGet);
				}
			}

			if (attached != null && !string.IsNullOrWhiteSpace(attached.URL))
				return Ok("File uploaded", attached.URL);

			return Error("Failed to upload");
		}

		public ActionResult Delete(AttachmentType itemID, int userID)
		{
			var ok = false;
			switch (itemID)
			{
				case AttachmentType.ProfilePhoto:
					ok = this._attachmentService.DeleteAttachmentForPatient<ProfilePhoto>(userID);
					break;
				case AttachmentType.CarePlanDocument:
					ok = this._attachmentService.DeleteAttachmentForPatient<CarePlanDocument>(userID);
					break;
				case AttachmentType.NdisPlanDocument:
					ok = this._attachmentService.DeleteAttachmentForPatient<NdisPlanDocument>(userID);
					break;
				case AttachmentType.GpDocument:
					ok = this._attachmentService.DeleteAttachmentForPatient<GpDocument>(userID);
					break;
				case AttachmentType.BirthCertificate:
					ok = this._attachmentService.DeleteAttachmentForPatient<BirthCertificate>(userID);
					break;
				case AttachmentType.MedicareDocument:
					ok = this._attachmentService.DeleteAttachmentForPatient<MedicareDocument>(userID);
					break;
				case AttachmentType.ProofOfAgeDocument:
					ok = this._attachmentService.DeleteAttachmentForPatient<ProofOfAgeDocument>(userID);
					break;
				case AttachmentType.PsychologyReport:
					ok = this._attachmentService.DeleteAttachmentForPatient<PsychologyReport>(userID);
					break;
				case AttachmentType.ReviewAssessmentReport:
					ok = this._attachmentService.DeleteAttachmentForPatient<ReviewAssessmentReport>(userID);
					break;

				case AttachmentType.CV:   // for care worker
					ok = this._attachmentService.DeleteAttachmentForCareWorker<CV>(userID);
					break;
				case AttachmentType.Qualifications:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<Qualifications>(userID);
					break;
				case AttachmentType.Referencees:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<Referencees>(userID);
					break;
				case AttachmentType.SpecialAwards:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<SpecialAwards>(userID);
					break;
				case AttachmentType.DriverLicense:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<DriverLicense>(userID);
					break;
				case AttachmentType.RegisteredVehicle:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<RegisteredVehicle>(userID);
					break;
				case AttachmentType.CPRAndFirstAidCertificate:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<CPRAndFirstAidCertificate>(userID);
					break;
				case AttachmentType.PoliceCriminalRecordsCheck:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<PoliceCriminalRecordsCheck>(userID);
					break;
				case AttachmentType.Passport:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<Passport>(userID);
					break;
				case AttachmentType.WorkingWithChildrenCheck:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<WorkingWithChildrenCheck>(userID);
					break;
				case AttachmentType.WorkingWithVulnerablePeopleCheck:
					ok = this._attachmentService.DeleteAttachmentForCareWorker<WorkingWithVulnerablePeopleCheck>(userID);
					break;
			}

			if (ok)
				return Ok("File deleted", null);

			return Error("Failed to delete");
		}

		private JsonResult Ok(string message, string url)
		{
			return
				Json(new
				{
					statusCode = 200,
					status = "OK",
					message = message,
					file = url,
				}, "text/html");
		}

		private JsonResult Error(string message)
		{
			return
				Json(new
				{
					statusCode = 500,
					status = "Error",
					message = message
				}, "text/html");
		}


		#endregion

	}
}