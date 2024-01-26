namespace InheritanceAndCompositionA03
{
    public class Vehicle
    {
        public string Make { get; set; }
        public short Year { get; set; }
        public double Speed { get; set; }
        public Engine Engine { get; set; }

        public void Accelerate(int amount)
        {
            Speed += amount;
        }

        //We always want our vehicle to have an engine
        public Vehicle() 
        {
            Engine = new Engine();
        }
        //We can also instantiate a vehicle and provide an engine object
        public Vehicle(Engine engine)
        {
            Engine = engine;
        }

    }
}
