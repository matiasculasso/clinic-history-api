using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicHistoryApi.Entities
{
	public class Patient : BaseEntity, IAuditableEntity
	{
		[Required]
		[StringLength(150)]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		public string LastName { get; set; }

		[Required]
		[StringLength(50)]
		public string IdentificationNumber { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		[Required]		
		public string ConsultationReason { get; set; }
		
		[StringLength(350)]
		public string Origin { get; set; }

		[StringLength(250)]
		public string ContactPhones { get; set; }

		[StringLength(250)]
		public string Email { get; set; }
		
		public SocialSecurity SocialSecurity { get; set; }

		public Diagnostic Diagnostic { get; set; }
		
		public string PrerinatologicalBackground { get; set; }

		public string EpidemiologicalBackground { get; set; }

		public string PhysiologicalBackground { get; set; }

		public string PathologicalBackground { get; set; }

		public string FamilyBackground { get; set; }

		public DateTime? CreatedOn { get; set; }

		[StringLength(150)]
		public string CreatedBy { get; set; }

		public DateTime? UpdatedOn { get; set; }

		[StringLength(150)]
		public string UpdatedBy { get; set; }
	}
}
