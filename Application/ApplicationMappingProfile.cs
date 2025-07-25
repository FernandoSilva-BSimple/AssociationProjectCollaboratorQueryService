using AutoMapper;
using Domain.Models;
using Application.DTO;

namespace Application;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<AssociationProjectCollaborator, AssociationProjectCollaboratorDTO>();
        CreateMap<AssociationProjectCollaborator, CreatedAssociationProjectCollaboratorFromMessageDTO>();

    }
}
