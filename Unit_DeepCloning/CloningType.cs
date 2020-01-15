using System;
using System.Linq;
using System.Reflection;

namespace Unit_DeepCloning
{

    public static class Cloner
    {
        public static T Clone<T>(this T obj)
        {
            var type = obj.GetType();
            
            if (type.IsValueType || obj is string)
            {
                return obj;
            }

            if (obj is ICloneable cloneable)
            {
                return (T) cloneable.Clone();
            }

            return obj.CloneReflect();
        }

        private static T CloneReflect<T>(this T obj)
        {
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var type = obj.GetType();
            
            try
            {
                T copy;
                
                 if (type.IsValueType) return obj;

                try
                {
                    copy = Activator.CreateInstance<T>();
                }
                catch
                {
                    var constructorInfo = type.GetConstructors(Flags).First();
                    var parameterInfos = constructorInfo.GetParameters();

                    var parameters =
                        parameterInfos.Select(x => x.ParameterType)
                            .Select(t => t.IsValueType ? Activator.CreateInstance(t) : null)
                            .ToArray();

                    copy = (T) constructorInfo.Invoke(parameters);
                }
                
                foreach (var fieldInfo in type.GetFields(Flags))
                {
                    var fieldValue = fieldInfo.GetValue(obj);
                    if (fieldValue != null)
                    {
                        var value = fieldValue.Clone();
                        fieldInfo.SetValue(copy, value);
                    }
                }

                foreach (var propertyInfo in type.GetProperties(Flags))
                {
                    var propertyValue = propertyInfo.GetValue(obj, null);
                    if (propertyValue != null)
                    {
                        var value = propertyValue.Clone();
                        propertyInfo.SetValue(copy, value, null);
                    }
                }

                return copy;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Не удается получить данные о типе", ex);
            }
        }
    }

    public class Student
    {
        private readonly string _fullName;
        private readonly int _ages;
        private readonly bool _fellowshipHolder;
        private readonly Gender _gender;

        public Student() { }

        public Student(string fullName, int ages, bool fellowshipHolder, Gender gender)
        {
            _fullName = fullName;
            _ages = ages;
            _fellowshipHolder = fellowshipHolder;
            var genderValue = gender == null ? "" : gender.Value;
            _gender = new Gender(genderValue);
        }
 
        public bool Equals(Student other)
        {
            return _fullName == other._fullName
                   && _ages == other._ages
                   && _fellowshipHolder == other._fellowshipHolder
                   && _gender.Equals(other._gender);
        }
 
        public override string ToString()
        {
            return $"{_fullName}\t{_ages}\t{_fellowshipHolder}\t{_gender.Value}";
        }
    }

    public class Gender : ICloneable
    {
        public readonly string Value;

        public Gender(string value)
        {
            Value = value;
        }

        public bool Equals(Gender another)
        {
            return Value == another.Value;
        }

        public object Clone()
        {
            return new Gender(Value);
        }

        public string ToString()
        {
            return "some gender object with value " + Value;
        }
    }
}