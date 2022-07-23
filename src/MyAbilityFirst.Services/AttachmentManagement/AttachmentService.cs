using MyAbilityFirst.Domain.AttachmentManagement;
using MyAbilityFirst.Infrastructure;
using MyAbilityFirst.Services.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyAbilityFirst.Services.AttachmentManagement
{
	public class AttachmentService : IAttachmentService
	{

		#region Fields

		private readonly IWriteEntities _entities;
		private readonly IReadEntities _readEntities;
		private readonly IUploadService _uploadService;

		#endregion

		#region Ctor

		public AttachmentService(IWriteEntities entities, IReadEntities readEntities, IUploadService uploadService)
		{
			this._entities = entities;
			this._readEntities = readEntities;
			this._uploadService = uploadService;
		}

		#endregion

		#region for-patinet

		public T UploadAttachmentForPatient<T>(int patientID, HttpPostedFileBase file) where T : UserAttachment
		{
			if (patientID < 1)
				throw new ArgumentNullException("patientID");

			if (file == null)
				throw new ArgumentNullException("file");

			// upload to storage
			string path = ConfigurationManager.AppSettings["azure.uploadPath.Patient"];
			string newUrl = this._uploadService.UploadToAzureStorage(file, path);

			if (string.IsNullOrWhiteSpace(newUrl))
				throw new ApplicationException($"Failed to upload {typeof(T).Name}");

			var doc = this.GetAttachmentForPatient<T>(patientID);
			if (doc == null)
			{
				doc = (T)Activator.CreateInstance(typeof(T), patientID, newUrl);
				
				this._entities.Create(doc);
				this._entities.Save();
			}
			else
			{
				// delete old file from storage
				if (!string.IsNullOrWhiteSpace(doc.URL))
				{
					string filename = doc.URL;
					this._uploadService.DeleteFromAzureStorage(filename, path);
				}

				// update doc with new url
				doc.SetUrl(newUrl);

				this._entities.Update(doc);
				this._entities.Save();
			}

			return doc;

		}

		public bool DeleteAttachmentForPatient<T>(int patientID) where T : UserAttachment
		{
			if (patientID < 1)
				throw new ArgumentNullException("patientID");

			var doc = this.GetAttachmentForPatient<T>(patientID);
			if (doc == null || string.IsNullOrWhiteSpace(doc.URL))
				return true;

			string filename = doc.URL;
			string path = ConfigurationManager.AppSettings["azure.uploadPath.Patient"];
			if (this._uploadService.DeleteFromAzureStorage(filename, path))
			{
				this._entities.Delete(doc);
				this._entities.Save();

				return true;
			}

			return false;
		}

		public T GetAttachmentForPatient<T>(int patientID) where T : UserAttachment
		{
			if (patientID < 1)
				throw new ArgumentNullException("patientID");

			var doc = this._entities.First<T>(a => a.UserID == patientID);
			return doc;
		}


		public List<UserAttachment> GetAttachmentsForUser(int userID)
		{
			if (userID < 1)
				throw new ArgumentNullException("userID");

			var docs = this._readEntities.Get<UserAttachment>(a => a.UserID == userID).ToList();
			return docs;
		}


		#endregion


		#region for-carer

		public T UploadAttachmentForCareWorker<T>(int careWorkerID, HttpPostedFileBase file) where T : UserAttachment
		{
			if (careWorkerID < 1)
				throw new ArgumentNullException("careWorkerID");

			if (file == null)
				throw new ArgumentNullException("file");

			// upload to storage
			string path = ConfigurationManager.AppSettings["azure.uploadPath.CareWorker"];
			string newUrl = this._uploadService.UploadToAzureStorage(file, path);

			if (string.IsNullOrWhiteSpace(newUrl))
				throw new ApplicationException($"Failed to upload {typeof(T).Name}");

			var doc = this.GetAttachmentForCareWorker<T>(careWorkerID);
			if (doc == null)
			{
				doc = (T)Activator.CreateInstance(typeof(T), careWorkerID, newUrl);
				this._entities.Create(doc);
				this._entities.Save();
			}
			else
			{
				// delete old file from storage
				if (!string.IsNullOrWhiteSpace(doc.URL))
				{
					string filename = doc.URL;
					this._uploadService.DeleteFromAzureStorage(filename, path);
				}

				// update doc with new url
				doc.SetUrl(newUrl);

				this._entities.Update(doc);
				this._entities.Save();
			}

			return doc;

		}

		public bool DeleteAttachmentForCareWorker<T>(int careWorkerID) where T : UserAttachment
		{
			if (careWorkerID < 1)
				throw new ArgumentNullException("careWorkerID");

			var doc = this.GetAttachmentForCareWorker<T>(careWorkerID);
			if (doc == null || string.IsNullOrWhiteSpace(doc.URL))
				return true;

			string filename = doc.URL;
			string path = ConfigurationManager.AppSettings["azure.uploadPath.CareWorker"];
			if (this._uploadService.DeleteFromAzureStorage(filename, path))
			{
				this._entities.Delete(doc);
				this._entities.Save();

				return true;
			}

			return false;
		}

		public T GetAttachmentForCareWorker<T>(int careWorkerID) where T : UserAttachment
		{
			if (careWorkerID < 1)
				throw new ArgumentNullException("careWorkerID");

			var doc = this._entities.First<T>(a => a.UserID == careWorkerID);
			return doc;
		}


		#endregion
	}
}