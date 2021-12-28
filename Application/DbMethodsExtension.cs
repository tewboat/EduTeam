using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore;
using ApplicationCore.Project;
using ApplicationCore.Rights;
using ApplicationCore.User;
using Infrastructure;

namespace Application
{
    public static class DbMethodsExtension
    {
        public static T GetEntityByGuid<T>(this IQueryable<T> enumerable, Guid guid) where T: IEntity=> 
            enumerable.FirstOrDefault(entity => entity.Guid == guid);

        public static AccessLevel? GetMemberAccessLevel(this IQueryable<MemberProject> queryable, Project project,
            User user) =>
            queryable.FirstOrDefault(entity
                    => entity.ProjectGuid == project.Guid && entity.UserGuid == user.Guid)
                ?.UserAccessLevel;

    }
}