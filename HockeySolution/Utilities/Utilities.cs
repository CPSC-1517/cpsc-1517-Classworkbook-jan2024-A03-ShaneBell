namespace ValidationUtilities
{
    //We will create a static class with static methods
    //we do not instantiate objects from static classes
    //We can use methods in static classes without create instantiating an object
    /// <summary>
    /// Utilties class that provides validation methods
    /// </summary>
    public static class Utilities
    {
        public static bool IsNullOrEmptyOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNegative(int value)
        {
            //returns true if the value is negative/false if value is positive
            //bool result =false;
            //if (value < 0) 
            //{
            //    result = true;
            //}
            //OR
            //bool result;
            //result = value < 0 ? true : false;   ? is called a Ternary Operator
            //return result;
            //OR
            //return value < 0 ? true : false;
            //OR
            return value < 0;
        }


    }
}