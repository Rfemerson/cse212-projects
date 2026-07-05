public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1.Create a list to store the results.
        // 2.Use a for loop to iterate through all possibilities for the length, 
        // starting at one and continuing until the index is less than or equal to the length.
        // 3.Add the result of `number * index` to the list.
        // 4.Return the list converted to an array as the result.

        List<double> results = new();
        for (double i = 1; i <= length; i++)
        {
            results.Add(number * i);
        }

        return results.ToArray(); 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1.Calculate the point where the original list will be "split." From this index onwards, the elements will occupy the beginning of the new list.
        // 2.Create a temporary list to store the elements in the new order.
        // 3.Iterate through each position of the result list. Calculate the corresponding index in the original list. 
        // When the index goes beyond the last element, it automatically wraps back to index 0.
        // 4.Add the element located at the calculated index of the original list to the `result` list.
        // 5.Replace the contents of the list received as a parameter:clear the original list and copy all elements from `result` to `data`.

        int splitIndex = data.Count - amount;

        List<int> result = new();

        for (int i = 0; i < data.Count; i++)
        {
            int originalIndex = (i + splitIndex) % data.Count;
            result.Add(data[originalIndex]);
        }

        data.Clear();
        data.AddRange(result);

    }
}
