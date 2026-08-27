using System.Reflection;

namespace C48_G02_ADV01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1: What is a generic class? Why use generics?
            /*
             What is a generic class?
                --> allow to write classes , interfaces and methodes with type parameters
             
            Why use generics?
                --> type safe
                --> reusable
                --> better performance
                --> cleaner code
             */
            #endregion

            #region Q2: 
            //Conteiner<int> intValue = new Conteiner<int>();
            //intValue.Add(1);
            //Console.WriteLine(intValue.GetValue());

            //Console.WriteLine();
            //Conteiner<string> stringValue = new Conteiner<string>();
            //stringValue.Add("string");
            //Console.WriteLine(stringValue.GetValue());
            #endregion

            #region Q3
            //Pair<int, string> pair = new Pair<int, string>(1, "Ali");
            //Console.WriteLine($"pair.key type : {pair.key.GetType().Name}");
            //Console.WriteLine($"pair.value type : {pair.value.GetType().Name}");
            #endregion

            #region Q4
            /*
             What is a generic method? 
                --> it is write a methode with type parameters
             */


            //int x = 5;
            //int y = 10;
            //Console.WriteLine($"x: {x} , y : {y}");
            //Console.WriteLine();
            //Swap(ref x, ref y);
            //Console.WriteLine($"x: {x} , y : {y}");
            #endregion

            #region Q5
            //Console.WriteLine(FindMax([1, 2, 3, 4, 1, 1]));  //4
            #endregion

            #region Q6
            /*
             What is a generic interface?
                --> a contract that uses type parameters, allowing you to define strongly-typed, 
                    reusable interfaces that can work with any data type without sacrificing performance or type safety
             */

            //IRepository<int> repository;
            #endregion

            #region Q7
            /*
             What is the 'struct' constraint? 
                --> allow only value types 
             */

            //StructConstraint<int> structConstraint_1=new StructConstraint<int>();
            //StructConstraint<short> structConstraint_2=new StructConstraint<short>();
            ////// StructConstraint<string> structConstraint_3=new StructConstraint<string>(); //string is class
            #endregion

            #region Q8
            /*
             What is the 'class' constraint? 
                --> allow only ref types 
             */

            /////  ClassConstraint<int> classConstraint_1=new ClassConstraint<int>(); // int value type(struct)
            //ClassConstraint<string> classConstraint_3 = new ClassConstraint<string>(); 
            #endregion

            #region Q9
            /*
                What is the ''new()' constraint? 
                    --> allow only struct with no impelement  parametarless constractor or
                        class which has parametarless constractor 
           */

            //Factory<Pirson> factory = new Factory<Pirson>();
            //Pirson p= factory.Create();
            //Console.WriteLine(p.Id);
            #endregion

            #region Q10
            /*
             What is the interface constraint? 
                --> T must Implement interface
             */

            //Printer<Document> printer = new Printer<Document>();
            //printer.PrintItem(new Document());
            #endregion

            #region Q11
            /*
             What is the base class constraint? 
                --> T or its derived types must inherit from BaseClass.
             */

            //Test<Dog> dogTest = new Test<Dog>(); 
            //Test<Cat> catTest = new Test<Cat>();
            #endregion

            #region Q12
            /*
             Q12: How do you apply multiple constraints? 
                --> by using the where keyword and separating the constraints with commas
             */

            //Test<Dog> test = new Test<Dog>(); 
            #endregion

            #region Q13
            /*
             What does the 'default' keyword do in generics?
                --> return null    -> ref type
                --> return 0/false -> value type
             */
            #endregion

            #region Q14
            //SafeList<int> intList = new SafeList<int>();
            //intList.Add(1);
            //Console.WriteLine($"valid Index (0) : {intList.GetItem(0)}");
            //Console.WriteLine($"Invalid Index (5) : {intList.GetItem(5)}");

            //Console.WriteLine();

            //SafeList<string> stringList = new SafeList<string>();
            //stringList.Add("HI");
            //Console.WriteLine($"valid Index (0) : {stringList.GetItem(0)}");
            //Console.WriteLine($"Invalid Index (5) : {stringList.GetItem(5) ?? "NULL"}");
            #endregion

            #region Q15
            /*
             Q15: What is covariance? 
                perant ref refare to chiled obj
             */

            //CatShilter catShilter = new CatShilter();
            //IShelter<Cat> catShilter02 = catShilter;

            //IShelter<Animal> animalShelter = catShilter;

            //Animal animal = animalShelter.GetAnimale();
            //Cat cat= (Cat)animalShelter.GetAnimale();

            //Console.WriteLine(animal.Name);
            //Console.WriteLine(cat.Name);
            #endregion

            #region Q16
            /*
             What is contravariance? 
               chiled ref refare to perant obj
             */

            //AnimalShelter animalShelter = new AnimalShelter();
            //IShelter<Animal> animalShelter02 = animalShelter;

            //IShelter<Cat> catShelter = animalShelter;

            //////Cat cat= catShelter.GetAnimale();   can return Dog To Type Cat 
            //catShelter.Treat(new Cat("01"));
            #endregion

            #region Q17
            /*
             What is the difference between covariance and contravariance?
                    -> contravariance [in]
                      chiled ref refare to perant obj

                    -> covariance [out] 
                        perant ref refare to chiled obj
             */
            #endregion

            #region Q18
            /*
             How do static members work in generic types?
               --> static members in a generic class are shared for each specific type argument.  
             */
            #endregion

            #region Q19
            /*
             How can you inherit from a generic class?
                class Base<T>{}
                
                class Dreved : Base<DataType>{}
              or
                class Dreved<T> : Base<T>{}
             */
            #endregion

            #region Q20
            //Cache<int,string> cache = new Cache<int, string>();

            //cache.Add(1, "ali");
            //cache.Add(1, "al222");
            //cache.Add(20, "mohamed");

            //Console.WriteLine(cache.Contains(1));

            //Console.WriteLine(cache.Get(1));
            //Console.WriteLine(cache.Get(2));
            //Console.WriteLine(cache.Get(20));
            #endregion

        }
        static void Swap<T>(ref T a, ref T b)
        {
            T x = a;
            a = b;
            b = x;
        }
        static T? FindMax<T>(T[] values) where T : IComparable<T>
        {

            if (values is not null && values.Length > 0)
            {
                T max = values[0];
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].CompareTo(max) > 0)
                        max = values[i];
                }
                return max;
            }

            return default(T);
        }


        #region Q7
        //struct StructConstraint<T> where T : struct
        //{
        //    public T Value { get; set; }
        //}
        #endregion

        #region Q8
        //class ClassConstraint<T> where T : class
        //{
        //    public T Value { get; set; }
        //}

        #endregion

        #region Q9
        //class Pirson
        //{
        //    public int Id { get; set; }
        //    public Pirson()
        //    {
        //        Id = 10;
        //    }
        //}
        //class Factory<T> where T : new()
        //{
        //    public T Create()
        //    {
        //        return new T();
        //    }
        //}
        #endregion

        #region Q10
        //interface IPrint
        //{
        //    void print();
        //}

        //class Document : IPrint
        //{
        //    public void print()
        //    {
        //        Console.WriteLine("Docoment");
        //    }
        //}

        //class Printer<T> where T : IPrint
        //{
        //    public void PrintItem(T item)
        //    {
        //        item.print();
        //    }
        //}
        #endregion

        #region Q11
        //class Animal
        //{
        //}
        //class Dog : Animal
        //{
        //}
        //class Cat : Animal
        //{
        //}
        //class Test<T> where T : Animal
        //{
        //    public void Print()
        //    {
        //        Console.WriteLine("T must inherit from Animal");
        //    }
        //}

        #endregion

        #region Q12
        //class Animal
        //{
        //}
        //interface IMovable
        //{
        //}
        //class Dog : Animal, IMovable 
        //{
        //}
        //class Cat : Animal, IMovable
        //{
        //}
        //class Test<T> where T : Animal, IMovable
        //{
        //    public void Print()
        //    {
        //        Console.WriteLine("T must inherit from Animal and implement IMovable");
        //    }
        //}


        #endregion

        #region Q14
        //class SafeList<T>
        //{
        //    private readonly List<T> _list = [];
        //    public void Add(T item)
        //    {
        //        _list.Add(item);

        //    }
        //    public T? GetItem(int index)
        //    {
        //        if (index >= 0 && index < _list.Count)
        //        {
        //            return _list[index];
        //        }
        //        return default(T);
        //    }
        //}
        #endregion

        #region Q15
        //class Animal
        //{
        //    public string Name { get; set; }

        //    public Animal(string name)
        //    {
        //        Name = name;
        //    }

        //}
        //class Cat : Animal
        //{
        //    public Cat(string name) : base(name)
        //    {
        //    }
        //}

        //class Dog : Animal
        //{
        //    public Dog(string name) : base(name)
        //    {
        //    }
        //}

        //interface IShelter<out T>
        //{
        //    T GetAnimale();

        //    ////void Treat(T animale);
        //}

        //class CatShilter : IShelter<Cat>
        //{
        //    public Cat GetAnimale()
        //    {
        //        return new Cat("c01");
        //    }

        //    public void Treat(Cat cat)
        //    {
        //        Console.WriteLine($"cat Name: {cat.Name}");
        //    }
        //}
        #endregion

        #region Q16
        //class Animal
        //{
        //    public string Name { get; set; }

        //    public Animal(string name)
        //    {
        //        Name = name;
        //    }

        //}
        //class Cat : Animal
        //{
        //    public Cat(string name) : base(name)
        //    {
        //    }
        //}

        //class Dog : Animal
        //{
        //    public Dog(string name) : base(name)
        //    {
        //    }
        //}

        //interface IShelter< in T>
        //{
        //     //// T GetAnimale();

        //    void Treat(T animale);
        //}

        //class CatShilter : IShelter<Cat>
        //{
        //    public Cat GetAnimale()
        //    {
        //        return new Cat("c01");
        //    }

        //    public void Treat(Cat cat)
        //    {
        //        Console.WriteLine($"cat Name: {cat.Name}");
        //    }
        //}
        //class AnimalShelter : IShelter<Animal>
        //{
        //    public Animal GetAnimale()
        //    {
        //        return new Animal("a01");
        //    }

        //    public void Treat(Animal animal)
        //    {
        //        Console.WriteLine($"Animal Name: {animal.Name}");
        //    }
        //}

        #endregion






    }
}
