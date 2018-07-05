namespace ClinicHistoryApi.Models.Entities
{
	public class ComplementEditModel
	{
		public int Id;
		public ComplementaryMethodInstanceModel[] ComplementaryMethods { get; set; }		
		public LaboratoryInstanceModel[] Laboratories { get; set; }
	}
}