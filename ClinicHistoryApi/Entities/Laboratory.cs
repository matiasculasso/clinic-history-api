
namespace ClinicHistoryApi.Entities
{
	public class Laboratory : BaseEntity
	{
		private string _name;

		public string Name
		{
			get => _name;
			set => _name = value;
		}
	}
}