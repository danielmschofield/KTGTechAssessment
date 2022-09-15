namespace KTGTech;
public class InternalTransfer
{
    private static int _solutionLen = 0;
    private static List<Order> _solution = new List<Order>();
    private static int _test = 0;

    public static List<Order> Collect(List<Order> orders)
    {
        if (orders.Sum(order => order.Quantity) == 0)
        {
            return orders;
        }

        bruteForceOrders(new List<Order>(), orders, 0, 0);

        // Console.WriteLine(_test);

        return _solution;
    }

    private static void bruteForceOrders(List<Order> potentialFinalList, List<Order> remainingList, int sum, int len)
    {
        _test++;
        for (int i = 0; i < remainingList.Count; i++)
        {
            Order currentValue = remainingList[i];
            List<Order> newPotentialFinalList = new List<Order>(potentialFinalList);
            newPotentialFinalList.Add(currentValue);

            List<Order> newRemainingList = new List<Order>(remainingList);
            newRemainingList.Remove(currentValue);

            int newSum = sum + currentValue.Quantity;
            int newLen = len + 1;

            if (newSum == 0 && newLen > _solutionLen)
            {
                _solution = newPotentialFinalList;
                _solutionLen = newLen;
            }

            if (newRemainingList.Count > 0)
            {
                bruteForceOrders(newPotentialFinalList, newRemainingList, newSum, newLen);
            }
        }
    }
    // Time O(n!) Space O(n^2)

}
