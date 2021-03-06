using System;
using System.Collections.Generic;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Generalization.Interfaces;
using ESparrow.Utils.Generalization.Types.Enums;

namespace ESparrow.Utils.Helpers
{
    public static class GeneralizationHelper
    {
        public static Dictionary<EGeneralizationType, Type> GetGeneralizationTypes()
        {
            var types = typeof(IGeneralizationType).GetSubclasses();

            var list = new List<IGeneralizationType>();
            foreach (var type in types)
            {
                var instance = GetInstanceByType(type);
                list.Add(instance);
            }

            var dictionary = new Dictionary<EGeneralizationType, Type>();
            foreach (var element in list)
            {
                dictionary.Add(element.GeneralizationType, element.Type);
            }

            return dictionary;
            
            IGeneralizationType GetInstanceByType(Type type)
            {
                return Activator.CreateInstance(type) as IGeneralizationType;
            }
        }

        public static bool IsGeneralizationType(Type self)
        {
            return GetGeneralizationTypes().ContainsValue(self);
        }

        public static bool IsGeneralizationType<T>(T self)
        {
            return IsGeneralizationType(self.GetType());
        }
    }
}