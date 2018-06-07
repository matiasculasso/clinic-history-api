using System;
using System.Collections.Generic;

namespace ClinicHistoryApi.Entities
{
	public class Complement : BaseEntity
	{
		private Consultation _consultation;
		private int _consultationId;
		private DateTime _date;

		protected Complement() { }

		public Complement(int consultationId, DateTime date)
		{
			_consultationId = consultationId;
			_date = date;
			ComplementaryMethods = new List<ComplementaryMethodInstance>();
			LaboratoryInstances = new List<LaboratoryInstance>();
		}

		public Consultation Consultation => _consultation;
		public int ConsultationId => _consultationId;

		public DateTime Date
		{
			get => _date;
			set => _date = value;
		}

		public List<ComplementaryMethodInstance> ComplementaryMethods { get; set; }
		public List<LaboratoryInstance> LaboratoryInstances { get; set; }
	}
}