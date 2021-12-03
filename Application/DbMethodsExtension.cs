using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Project;
using ApplicationCore.User;
using Infrastructure;

namespace Application
{
    public static class DbMethodsExtension
    {
        public static T GetEntityByGuid<T>(this IQueryable<T> enumerable, Guid guid) where T: IEntity=> 
            enumerable.FirstOrDefault(entity => entity.Guid == guid);
    }
}