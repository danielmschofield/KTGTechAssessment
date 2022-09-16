namespace KTGTech;
public class MinOverCancellation
{
    private int _solutionSum = 0;
    private int _cancelTarget;
    private List<Order> _solution = new List<Order>();
    private int _test = 0;

    public List<Order> Collect(List<Order> orders, int target)
    {
        _cancelTarget = target;
        int sum = 0;

        bruteForceMinOverCancellation(new List<Order>(), orders, sum);

        return _solution;
    }

    private void bruteForceMinOverCancellation(List<Order> potentialFinalList, List<Order> remainingList, int sum)
    {
        _test++;
        for (int i = 0; i < remainingList.Count; i++)
        {
            Order currentValue = remainingList[i];
            List<Order> newPotentialFinalList = new List<Order>(potentialFinalList);
            newPotentialFinalList.Add(currentValue);

            // remove all elements before the index to avoid redundant checking of sums
            List<Order> newRemainingList = remainingList.Where((val, idx) => idx > i).ToList();

            int newSum = sum + currentValue.Quantity;

            // determine if candidate solution is better than the current solution
            if (newSum >= _cancelTarget && (newSum < _solutionSum || _solutionSum == 0))
            {
                _solution = newPotentialFinalList;
                _solutionSum = newSum;
            }
            else if (newRemainingList.Count > 0)
            {
                bruteForceMinOverCancellation(newPotentialFinalList, newRemainingList, newSum);
            }
        }
    }

}
