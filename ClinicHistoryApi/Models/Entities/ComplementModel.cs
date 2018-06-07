namespace ClinicHistoryApi.Models.Entities
{
	public class ComplementModel
	{
		public int Id;
		public int ConsultationId { get; set; }
		public string Date { get; set; }
		public ComplementaryMethodInstanceModel[] ComplementaryMethods { get; set; }
		public LaboratoryInstanceModel[] LaboratoryModels { get; set; }
	}
}