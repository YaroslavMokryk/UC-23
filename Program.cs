namespace UC_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating test data...");
            var testDataGenerator = new TestDataGenerator();
            testDataGenerator.GenerateTestData();
            Console.WriteLine("Test data generation completed.");
        }
    }
}
