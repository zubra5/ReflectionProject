using System;
using System.Reflection;

namespace ReflectionProject
{
    class Program
    {
        private static void Main(string[] args)
        {
            UsingAttributes();
        }

        private static void LookAtBehind()
        {
            Type type = Type.GetType("ReflectionProject.Student");
            var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine(memberInfo.Name);
            }

            Console.ReadLine();
        }

        private static void SetterStudent()
        {
            Student student = new Student();

            Type type = student.GetType();

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == "_temp")
                {
                    var value = fieldInfo.GetValue(student);
                    Console.WriteLine("Before: {0}", value);

                    fieldInfo.SetValue(student, 15);

                    value = fieldInfo.GetValue(student);

                    Console.WriteLine("After: {0}", value);
                }
            }

            Console.ReadLine();
        }

        private static void NewWay()
        {
            Type type = typeof(Student);

            ConstructorInfo constructorInfo = type.GetConstructor(new Type[]{});//содержит описание параметров консутрутора
            //получаем не типизированный объекты
            object student = constructorInfo.Invoke(new object[] { });//вызываем реальный конструктор с параметрами

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == "_temp")
                {
                    var value = fieldInfo.GetValue(student);
                    Console.WriteLine("Before: {0}", value);

                    fieldInfo.SetValue(student, 15);

                    value = fieldInfo.GetValue(student);

                    Console.WriteLine("After: {0}", value);
                }
            }

            Console.ReadLine();
        }

        private static void UsingAttributes()
        {
            Student student =new Student();
            Type type = student.GetType();

            var properties = type.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(MySimpleAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = (MySimpleAttribute) attributes[0];
                    Console.WriteLine("Property name: {0}, attribute value: {1}",propertyInfo.Name, attribute.Number);
                }
            }
            Console.ReadLine();
        }
    }
}
