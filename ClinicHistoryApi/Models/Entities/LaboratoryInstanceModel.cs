namespace ClinicHistoryApi.Models.Entities
{
	public class LaboratoryInstanceModel
	{
		public int Id { get; set; }
		public int LaboratoryId { get; set; }
		public double Value { get; set; }
	}
}