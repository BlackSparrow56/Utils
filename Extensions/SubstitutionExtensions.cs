using System.Collections.Generic;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class SubstitutionExtensions
    {
        public static ISubstitutionOperator<T> AsSubstitutionOperator<T>(this IList<T> list)
        {
            return SubstitutionHelper.CreateSubstitutionOperator(list);
        }

        public static ISubstitutionOperator<KeyValuePair<TKey, TValue>> AsSubstitutionOperator<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary)
        {
            return SubstitutionHelper.CreateSubstitutionOperator(dictionary);
        }
    }
}