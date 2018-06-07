namespace ClinicHistoryApi.Entities
{
	public class ComplementaryMethodInstance : BaseEntity
	{
		private double _value;
		private int _complementaryMethodId;
		private ComplementaryMethod _complementaryMethod;

		protected ComplementaryMethodInstance()
		{
		}

		public ComplementaryMethodInstance(int complementaryMethodId, double value)
		{
			_complementaryMethodId = complementaryMethodId;
			_value = value;
		}

		public int ComplementaryMethodId => _complementaryMethodId;

		public double Value
		{
			get => _value;
			set => _value = value;
		}

		public ComplementaryMethod ComplementaryMethod => _complementaryMethod;
	}
}