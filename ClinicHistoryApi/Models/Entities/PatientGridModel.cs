
namespace ClinicHistoryApi.Models.Entities
{
    public class PatientGridModel
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public string IdentificationNumber { get; set; }		

		public string ConsultationReason { get; set; }

		public string Diagnostic { get; set; }

		public string BirthDate { get; set; }
	}
}
