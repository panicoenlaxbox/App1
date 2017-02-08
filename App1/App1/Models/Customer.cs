namespace App1.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
            Image = "http://lorempixel.com/50/50/people/";
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}