using System;

namespace HFCShExtendingBaseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Bird bird;
                Console.WriteLine("\nPress P for pigeon, O for ostrich: ");
                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (key)
                {
                    case 'P':
                        bird = new Pigeon();
                        break;
                    case 'O':
                        bird = new Ostrich();
                        break;
                    default:
                        return;
                }
                Console.Write("\n How many eggs should it lay?");
                if (!int.TryParse(Console.ReadLine(), out int numberOfEggs))
                    return;
                Egg[] eggs = bird.LayEggs(numberOfEggs);
                foreach (Egg egg in eggs)
                {
                    Console.WriteLine(egg.Description);
                }

            }


        }
    }

    class Bird
    {
        public static Random Randomiser = new Random();
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("ERROR: Bird.LayEggs should never get called ");
            return new Egg[0];
        }
    }

    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomiser.NextDouble() + 12, "speckled");
            }
            return eggs;
        }
    }

    class Pigeon: Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomiser.NextDouble() * 2 + 1, "white");
            }
            return eggs;
        }
    }

    class Egg
    {
        public double Size { get; private set; }
        public string Color { get; private set; }
        public Egg(double size, string color)
        {
            Size = size;
            Color = color;

        }
        public string Description
        {
            get
            {
                return $"A {Size:0.0}cm {Color} egg";
            }
        }
        }
    }




