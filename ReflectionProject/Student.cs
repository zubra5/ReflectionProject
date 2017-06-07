
namespace ReflectionProject
{
    public class Student
    {
        
        private int _temp = 7;

        public string Name { get; set; }

        /// <summary>
        /// пометили свойство Age класса Student аттрибутом MySimple
        /// </summary>
        [MySimpleAttribute(Number=5)]
        public string Age { get; set; }
    }
}
