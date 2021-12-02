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
        public static T GetByGuid<T>(this IQueryable<T> enumerable, Guid guid) where T: IEntity=> 
            enumerable.Select(entity => entity).FirstOrDefault(entity => entity.Guid == guid);
        
    }
}