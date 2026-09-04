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
        // Plan:
        // 1. The function needs to return an array of numbers, and we already know
        //    exactly how many numbers we need -- that's the 'length' parameter -- so
        //    we can create the array with that exact size right away.
        // 2. We need to go through every empty spot in that array, one at a time,
        //    starting from the very first spot and ending at the very last spot.
        // 3. For the first spot, the answer should be the starting number multiplied
        //    by 1. For the second spot, it should be the starting number multiplied
        //    by 2. This means: as we move through the array, we multiply the
        //    starting number by increasing whole numbers (1, 2, 3, and so on).
        // 4. Once every spot in the array has been filled in this way, we give
        //    the finished array back as the result.
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
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
        // Plan:
        // 1. We need to figure out where to split the list into two pieces.
        //    The list has a certain total number of items (data.Count), and we
        //    are told how many items ('amount') need to move from the end to
        //    the front. So the split point is: total items minus amount.
        // 2. The second piece (the "tail") is the last 'amount' items in the
        //    list -- these are the ones that need to move to the front.
        // 3. The first piece (the "head") is everything before the split
        //    point -- these items stay in the same order but shift toward
        //    the end of the list.
        // 4. Once we have both pieces separated out, we clear the original
        //    list and rebuild it by adding the tail piece first, followed
        //    by the head piece. This gives us the rotated result.
        int splitPoint = data.Count - amount;
        List<int> tail = data.GetRange(splitPoint, amount);
        List<int> head = data.GetRange(0, splitPoint);
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}