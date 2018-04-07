using System;


namespace ClinicHistoryApi.Models.Entities
{
	public class ConsultationModel
	{
		public int Id { get; set; }

		public int PatientId { get; set; }

		public string Alimentation { get; set; }

		public string Comments { get; set; }

		public bool ComplementaryMethodRequested { get; set; }
		
		public DateTime Date { get; set; }

		public string DefecatoryHabit { get; set; }

		public string Evolution { get; set; }

		public double? Length { get; set; }

		public string PhysicalActivity { get; set; }

		public string PhysicalExam { get; set; }

		public string SchoolPerformance { get; set; }

		public double? Weight { get; set; }

		public string Physician { get; set; }
	}
}
