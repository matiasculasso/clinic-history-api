﻿using System;

namespace ClinicHistoryApi.Entities
{
	public interface IAuditableEntity
	{
		DateTime? CreatedOn { get; set; }
		string CreatedBy { get; set; }
		DateTime? UpdatedOn { get; set; }		
		string UpdatedBy { get; set; }
	}
}
