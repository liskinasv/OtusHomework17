using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomework17
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            T maxItem = collection.First();
            float maxValue = convertToNumber(maxItem);

            foreach (var item in collection)
            {
                float value = convertToNumber(item);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }

}
