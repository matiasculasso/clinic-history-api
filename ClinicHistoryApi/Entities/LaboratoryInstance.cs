namespace ClinicHistoryApi.Entities
{
	public class LaboratoryInstance : BaseEntity
	{
		private double _value;
		private int _laboratoryId;
		private Laboratory _laboratory;

		protected LaboratoryInstance()
		{
		}

		public LaboratoryInstance(int laboratoryId, double value)
		{
			_laboratoryId = laboratoryId;
			_value = value;
		}

		public int LaboratoryId => _laboratoryId;

		public double Value
		{
			get => _value;
			set => _value = value;
		}

		public Laboratory Laboratory => _laboratory;
	}
}