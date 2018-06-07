namespace ClinicHistoryApi.Models.Entities
{
	public class ComplementaryMethodInstanceModel
	{
		public int Id { get; set; }
		public int ComplementaryMethodId { get; set; }
		public double Value { get; set; }
	}
}