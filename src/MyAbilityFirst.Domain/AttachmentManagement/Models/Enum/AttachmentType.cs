
namespace MyAbilityFirst.Domain.AttachmentManagement
{
  //1000-1999 for patient, 2000-2009 for care worker
	public enum AttachmentType
	{
		ProfilePhoto = 1001,
		CarePlanDocument = 1002,
		NdisPlanDocument = 1003,
		GpDocument = 1004,
		BirthCertificate = 1005,
		MedicareDocument = 1006,
		ProofOfAgeDocument = 1007,
		PsychologyReport = 1008,
		ReviewAssessmentReport = 1009,
		CV = 2001,
		Qualifications = 2002,
		Referencees = 2003,
		SpecialAwards = 2004,
		DriverLicense = 2005,
		RegisteredVehicle = 2006,
		CPRAndFirstAidCertificate = 2007,
		PoliceCriminalRecordsCheck = 2008,
		Passport = 2009,
		WorkingWithChildrenCheck = 2010,
		WorkingWithVulnerablePeopleCheck = 2011
	}
}