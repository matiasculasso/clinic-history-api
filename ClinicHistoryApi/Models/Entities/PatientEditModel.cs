namespace ClinicHistoryApi.Models.Entities
{
	public class PatientEditModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public string IdentificationNumber { get; set; }

		public string BirthDate { get; set; }

		public string ConsultationReason { get; set; }

		public string Origin { get; set; }

		public string ContactPhones { get; set; }

		public string Email { get; set; }

		public int? SocialSecurityId { get; set; }

		public int? DiagnosticId { get; set; }

		public string PrerinatologicalBackground { get; set; }

		public string EpidemiologicalBackground { get; set; }

		public string PhysiologicalBackground { get; set; }

		public string PathologicalBackground { get; set; }

		public string FamilyBackground { get; set; }

		public ConsultationModel Consultation { get; set; }
	}
}
