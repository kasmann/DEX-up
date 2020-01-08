using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Unit_DeepCloning
{

    public static class Cloner
    {
        const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static T Clone<T>(this T obj)
        {
            if (typeof(T).IsValueType)
            {
                return obj;
            }
            if (!obj.IsSerializable())
            {
                return obj.CloneReflect();
            }
            if (obj is ICloneable cloneable)
            {
                return (T) cloneable.Clone();
            }
            var b = new BinaryFormatter();
            byte[] buffer;
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, obj);
                buffer = stream.GetBuffer();
            }

            T result;
            using (var stream = new MemoryStream(buffer))
            {
                result = (T) b.Deserialize(stream);
            }
            return result;
        }

        private static bool IsSerializable<T>(this T obj)
        {
            //return typeof(T).Attributes.HasFlag(TypeAttributes.Serializable) || obj is ISerializable;
            return (typeof(T).Attributes & TypeAttributes.Serializable) != 0 || obj is ISerializable;
        }

        private static T CloneReflect<T>(this T obj)
        {
            try
            {
                var type = obj.GetType();
                if (type.IsValueType || obj is string)
                    return obj;


                T copy;

                try
                {
                    copy = Activator.CreateInstance<T>();
                }
                catch
                {
                    var constr = type.GetConstructors(Flags).First();
                    var parameterInfos = constr.GetParameters();
                    var parameters =
                        parameterInfos.Select(x => x.ParameterType)
                            .Select(t => t.IsValueType ? Activator.CreateInstance(t) : null)
                            .ToArray();
                    copy = (T) constr.Invoke(parameters);
                }


                foreach (var fieldInfo in type.GetFields(Flags))
                {
                    var value = fieldInfo.GetValue(obj).Clone();
                    fieldInfo.SetValue(copy, value);
                }

                foreach (var propertyInfo in type.GetProperties(Flags))
                {
                    var value = propertyInfo.GetValue(obj, null).Clone();
                    propertyInfo.SetValue(copy, value, null);
                }

                return copy;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Не удается получить данные о типе", ex);
            }
        }
    }
}