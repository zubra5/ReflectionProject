using System;

namespace ReflectionProject
{
    /// <summary>
    /// представляет собой определенную метку
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MySimpleAttribute: Attribute
    {
        public int Number { get; set; }
    }
}
