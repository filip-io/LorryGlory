using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Mappings
{
    internal static class GenericMapper
    {
        /// <summary>
        /// Maps a source object to a target object in which the properties are of the same name and type. Not
        /// all properties of the source object are required in the target object.
        /// </summary>
        /// <typeparam name="TSource">Original type. For instance, a database object.</typeparam>
        /// <typeparam name="TTarget">Target type. For instance, a data transfer object</typeparam>
        /// <param name="source"></param>
        /// <returns>An object of specified type TTarget.</returns>
        public static TTarget OneToOneMapper<TSource, TTarget>(TSource source) where TTarget : new()
        {
            // Method has "where TTarget : new()" to ensure the target object has an empty constructor.
            // Uses reflection to get the properties of the objects during runtime. Note that this does not get the values of the properties.
            var target = new TTarget();
            var sourceProps = typeof(TSource).GetProperties();
            var targetProps = typeof(TTarget).GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                var targetProp = targetProps.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);

                if (targetProp != null && targetProp.CanWrite)
                {
                    // Gets the value of the source property and sets it to the targets property of equivalent name and type.
                    var value = sourceProp.GetValue(source);
                    targetProp.SetValue(target, value);
                }
            }

            return target;
        }
    }
}
