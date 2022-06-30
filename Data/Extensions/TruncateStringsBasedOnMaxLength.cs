using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Truncates the property value to the maximum length of the column.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entityObject">Model of entity</param>
        public static void TruncateStringsBasedOnMaxLength<T>(this DbContext context, T entityObject) where T : BaseEntity
        {
            var entityTypes = context.Model.GetEntityTypes();
            var properties = entityTypes.First(e => e.Name == entityObject.GetType().FullName).GetProperties().ToDictionary(p => p.Name, p => p.GetMaxLength());

            foreach (var propertyInfo in entityObject.GetType().GetProperties().Where(p => p.PropertyType == typeof(string)))
            {
                var value = (string)propertyInfo.GetValue(entityObject);

                if (value == null)
                    continue;

                // If Property Contains 'Phone'. Assume its a phone number and remove all non-digits
                if (propertyInfo.Name.ToLower().Contains("phone"))
                {
                    value = value.SanitizeToDigitsOnly();
                }

                var maxLenght = properties[propertyInfo.Name];

                if (maxLenght.HasValue)
                {
                    propertyInfo.SetValue(entityObject, value.Truncate(maxLenght.Value));
                }
            }
        }
    }
}
