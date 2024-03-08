using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Models;
using AutoMapper;

namespace AGSR.Patients.Mappers
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientModel>()
                .ForMember(dest => dest.Name, options => options.MapFrom(source => source.Name))
                .ReverseMap();

            CreateMap<Name, NameModel>()
                .ForMember(x => x.GivenNames, options => options.MapFrom(source => source.GivenNames.Select(gn => gn.Value)));

            CreateMap<NameModel, Name>()
                .ForMember(x => x.GivenNames, options => options.MapFrom(source => source.GivenNames.Select(gn => new GivenName { Value = gn })));
        }
    }
}
