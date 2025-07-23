using AutoMapper;
using AutoMapper.Internal.Mappers;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Resolvers;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<Collaborator, CollaboratorDataModel>();
        CreateMap<CollaboratorDataModel, Collaborator>()
             .ConvertUsing<CollaboratorConverter>();
        CreateMap<AssociationProjectCollaborator, AssociationProjectCollaboratorDataModel>();
        CreateMap<AssociationProjectCollaboratorDataModel, AssociationProjectCollaborator>()
            .ConvertUsing<AssociationProjectCollaboratorDataModelConverter>();
        CreateMap<Project, ProjectDataModel>();
        CreateMap<ProjectDataModel, Project>()
            .ConvertUsing<ProjectConverter>();
        CreateMap<User, UserDataModel>();
        CreateMap<UserDataModel, User>()
            .ConvertUsing<UserConverter>();
    }
}