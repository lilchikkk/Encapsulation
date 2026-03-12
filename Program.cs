using System.Threading.Channels;
using Encapulation.Service;

namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Encapsulation e kapseldamine");

            //liigipääs classile student ei ole piiratud kuna 
            //asub samas projektis
            Student student = new Student();

            //miks ei näita Student2 rohelisena???
            //Student2 ei tohi public classiks
            //koodi ei tohi parandada, aga pead aru saama, miks on viga

            //miks internal classe ei saa viidata teisest projectist;
            //aga samas projectis olevat saab?
            //kui on tegemist internal classiga siis ei saa teisest
            //projectist neid esile kutsuda
            //Student2 student2 = new Student2();

            student.Id = 101;
            student.Name = "test";
            student.Email = "test@test.com";

            Console.WriteLine("Id = " + student.Id);
            Console.WriteLine("Name = " + student.Name);
            Console.WriteLine("Email = " + student.Email);

            //kasutame ProtectedStudent classi 
            ProtectedStudent protectedStudent = new ProtectedStudent();
            //protectedStudent.DoSomething();
            // ei saa kasutada kuna asub teises clasis aga samas projectis
            //teha Program.cs classi meetod nimega DoSomethingInProgramClass
            //ja kutsuda see esile Program meetodis
            Console.WriteLine("---------------------");
            Program program = new Program();
            program.DoSomethingInProgramClass();

            //kutsuda PrivateProtectedInProgrmClass esile
            Console.WriteLine("----PrivateProtectedInProgrmClass----");
            Program pp = new Program();
            Console.WriteLine(pp.PrivateProtectedInProgrmClass =
                "PrivateProtectedInProgrmClass");

            //soovime kasutada PrivateProtectedStudent classis olevat
            //meetodi ja kutsuda see esile Main meetodis.
            var PrivateProtectedStudent1 = new PrivateProtectedStudent();
            //kui annab samas clasis, siis saab kasutada,
            //aga teises classis ei saa
            //PrivateProtectedStudent1.PrivateProtectedStudent1 = "asdsad";


            //sealed classi kasutamine
            Console.WriteLine("----Sealed Class----");
            //
            var sc = new SealedStudent();
            sc.Id = 123;
            sc.Name = "test";
            sc.Email = "Sealedtest@sealed.com";
            //$ - string format e saan kasutada stringivälised muutujad
            Console.WriteLine($"Id on {sc.Id}, Name on {sc.Name} ja " +
                $"Email on {sc.Email}");
        }

        protected void DoSomethingInProgramClass()
        {
            Console.WriteLine("DoSomethingInProgramClass");
        }
        private protected string PrivateProtectedInProgrmClass =
            "PrivateProtectedInProgrmClass";
    }
}
