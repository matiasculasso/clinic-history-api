using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Models.Entities;

namespace ClinicHistoryApi.Configuration
{
    public class EntitiesMapping : Profile
    {
		public EntitiesMapping()
		{
			CreateMap<Patient, PatientGridModel>()
				.ForMember(x => x.BirthDate, cfg => cfg.MapFrom( x => x.BirthDate.ToString("yyyy-MM-dd hh:mm")))
				.ForMember(x => x.Diagnostic, cfg => cfg.MapFrom(x => x.Diagnostic.Name));

			CreateMap<Patient, PatientEditModel>()
				.ForMember(x => x.Consultation, cfg => cfg.Ignore())
				.ForMember(x => x.BirthDate, cfg => cfg.MapFrom(x => x.BirthDate.ToString("yyyy-MM-dd")))
				.ForMember(x => x.DiagnosticId, cfg => cfg.MapFrom(x => x.Diagnostic.Id))
				.ForMember(x => x.SocialSecurityId, cfg => cfg.MapFrom(x => x.SocialSecurity.Id));

			CreateMap<PatientEditModel, Patient>()
				.ForMember(x => x.Diagnostic, cfg => cfg.Ignore())
				.ForMember(x => x.SocialSecurity, cfg => cfg.Ignore());				

			CreateMap<Consultation, ConsultationModel>()
				.ForMember(x => x.Date, cfg => cfg.MapFrom(x => x.Date.ToString("yyyy-MM-dd hh:mm")))				
				.ForMember(x => x.Physician, cfg => cfg.MapFrom(x => x.CreatedBy))
				.ForMember(x => x.PatientId, cfg => cfg.MapFrom(x => x.Patient.Id));

			CreateMap<ConsultationModel, Consultation>()
				.ForMember(x => x.Patient, cfg => cfg.Ignore())
				.ForMember(x => x.CreatedBy, cfg => cfg.Ignore())
				.ForMember(x => x.CreatedOn, cfg => cfg.Ignore())
				.ForMember(x => x.UpdatedBy, cfg => cfg.Ignore())
				.ForMember(x => x.UpdatedOn, cfg => cfg.Ignore());

		}
	}
}
