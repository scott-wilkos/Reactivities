using AutoMapper;
using Domain;

namespace API.Controllers.Activities;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
    }
}
