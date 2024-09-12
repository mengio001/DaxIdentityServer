using AutoMapper;

namespace QuizTower.IDP.Profiles
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Mapping from IdentityServer Model to Entity
            this.CreateMap<Duende.IdentityServer.Models.Client, Duende.IdentityServer.EntityFramework.Entities.Client>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RedirectUris, opt => opt.Ignore())
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Mapping from IdentityResource Model to Entity
            this.CreateMap<Duende.IdentityServer.Models.IdentityResource, Duende.IdentityServer.EntityFramework.Entities.IdentityResource>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Mapping from ApiScope Model to Entity
            this.CreateMap<Duende.IdentityServer.Models.ApiScope, Duende.IdentityServer.EntityFramework.Entities.ApiScope>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Mapping from ApiResource Model to Entity
            this.CreateMap<Duende.IdentityServer.Models.ApiResource, Duende.IdentityServer.EntityFramework.Entities.ApiResource>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
