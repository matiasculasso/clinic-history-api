using System.ComponentModel.DataAnnotations;

namespace ClinicHistoryApi.Entities
{
	public class SocialSecurity : BaseEntity
	{
		[Required]
		[StringLength(150)]
		public string Name { get; set; }
	}

}
