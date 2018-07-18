namespace ClinicHistoryApi.Entities
{
	public class ComplementaryMethod : BaseEntity
	{
		private string _name;

		public string Name
		{
			get => _name;
			set => _name = value;
		}
	}
}
