using NUnit.Framework;
using OnlineStrategyGame.Base.Names;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Base.Tests
{
    public class NamesGeneratorTests
    {

        [Test]
        public void TestPlanetsNamesGenerator()
        {
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1,1));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1,2));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1,3));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1,4));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1,5));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(1, 6));

            Console.WriteLine( NamesGenerator.GeneratePlanetName(2,1));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(2,2));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(2,3));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(2,4));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(2,5));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(2, 6));

            Console.WriteLine( NamesGenerator.GeneratePlanetName(3,1));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(3,2));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(3,3));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(3,4));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(3,5));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(3, 6));

            Console.WriteLine( NamesGenerator.GeneratePlanetName(4,1));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(4,2));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(4,3));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(4,4));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(4,5));
            Console.WriteLine( NamesGenerator.GeneratePlanetName(4, 6));
        }

        [Test]
        public void TestNamesGenerator()
        {
            Console.WriteLine(NamesGenerator.GenerateName(1, 1));
            Console.WriteLine(NamesGenerator.GenerateName(1, 2));
            Console.WriteLine(NamesGenerator.GenerateName(1, 3));
            Console.WriteLine(NamesGenerator.GenerateName(1, 4));
            Console.WriteLine(NamesGenerator.GenerateName(1, 5));
            Console.WriteLine(NamesGenerator.GenerateName(1, 6));

            Console.WriteLine(NamesGenerator.GenerateName(2, 1));
            Console.WriteLine(NamesGenerator.GenerateName(2, 2));
            Console.WriteLine(NamesGenerator.GenerateName(2, 3));
            Console.WriteLine(NamesGenerator.GenerateName(2, 4));
            Console.WriteLine(NamesGenerator.GenerateName(2, 5));
            Console.WriteLine(NamesGenerator.GenerateName(2, 6));
        }
        [Test]
        public void TestDoubleNamesGenerator()
        {
            Console.WriteLine(NamesGenerator.GenerateDoubleName(1));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(2));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(3));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(4));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(5));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(6));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(7));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(8));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(9));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(10));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(11));
            Console.WriteLine(NamesGenerator.GenerateDoubleName(12));
        }
    }
}
