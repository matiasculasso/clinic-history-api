using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicHistoryApi.Entities
{
	public class Consultation : BaseEntity, IAuditableEntity
	{
		private int _patientId;
		private Patient _patient;
		private DateTime _date;
		private double? _length;
		private string _alimentation;
		private double? _weight;
		private string _comments;
		private bool _complementaryMethodRequested;
		private string _defecatoryHabit;
		private string _evolution;
		private string _schoolPerformance;
		private string _physicalExam;
		private string _physicalActivity;

		protected Consultation()
		{
		} 

		public Consultation(
			Patient patient,
			DateTime date,
			bool complementaryMethodRequested,
			double? length,
			double? weight,
			string alimentation = "",
			string comments = "",
			string defecatoryHabit = "",
			string evolution = "",
			string schoolPerformance = "",
			string physicalExam = "",
			string physicalActivity = "")
		{
			_patientId = patient.Id;
			_date = date;
			_length = length;
			_alimentation = alimentation;
			_weight = weight;
			_comments = comments;
			_complementaryMethodRequested = complementaryMethodRequested;
			_defecatoryHabit = defecatoryHabit;
			_evolution = evolution;
			_schoolPerformance = schoolPerformance;
			_physicalExam = physicalExam;
			_physicalActivity = physicalActivity;
		}

		[Required]
		public int PatientId => _patientId;

		public Patient Patient => _patient;

		[StringLength(250)]
		public string Alimentation => _alimentation;

		[StringLength(500)]
		public string Comments => _comments;

		public bool ComplementaryMethodRequested => _complementaryMethodRequested;

		[StringLength(150)]
		public string CreatedBy { get; set; }

		public DateTime? CreatedOn { get; set; }

		[Required]
		public DateTime Date => _date;

		[StringLength(150)]
		public string DefecatoryHabit => _defecatoryHabit;

		[StringLength(500)]
		[Required]
		public string Evolution => _evolution;

		public double? Length => _length;

		[StringLength(250)]
		public string PhysicalActivity => _physicalActivity;

		[StringLength(250)]
		public string PhysicalExam => _physicalExam;

		[StringLength(250)]
		public string SchoolPerformance => _schoolPerformance;

		[StringLength(150)]
		public string UpdatedBy { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public double? Weight => _weight;
	}
}
