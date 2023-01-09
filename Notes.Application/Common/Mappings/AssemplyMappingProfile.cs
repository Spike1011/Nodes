using System;
using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mappings
{
	public class AssemplyMappingProfile : Profile
	{
		public AssemplyMappingProfile(Assembly assemply) =>
			ApplyMappingFromAssemply(assemply);

        /// <summary>
        /// Метод сканирует сборку и ищет все класс, где реализован интерфейс IMapWith
        /// </summary>
        /// <param name="assemply"></param>
        private void ApplyMappingFromAssemply(Assembly assemply)
        {
            var types = assemply.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

