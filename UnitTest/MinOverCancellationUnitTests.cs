namespace KTGTechAssessment;
using KTGTech;

public class MinOverCancellationTests
{
    [Fact]
    public void Test_multiplePossibleScenarios()
    {

        MinOverCancellation minOverCancellation = new MinOverCancellation();

        int target = 13;

        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, 5, 100));
        OrderList.Add(new Order(2, 10, 100));
        OrderList.Add(new Order(3, 10, 100));
        OrderList.Add(new Order(4, 5, 100));
        OrderList.Add(new Order(5, 5, 100));
        OrderList.Add(new Order(6, 3, 100));

        List<Order> resultList = minOverCancellation.Collect(OrderList, target);

        int expectedResult = 13;

        // Console.WriteLine(string.Format("Test_multiplePossibleScenarios: Id List: [{0}]", string.Join(", ", resultList.Select(e => e.Id))));

        Assert.Equal(expectedResult, resultList.Sum(order => order.Quantity));
    }

    [Fact]
    public void Test_emptyOrderList()
    {
        MinOverCancellation minOverCancellation = new MinOverCancellation();

        int target = 100;

        List<Order> OrderList = new List<Order>();

        List<Order> resultList = minOverCancellation.Collect(OrderList, target);

        Assert.Empty(resultList);

    }

    [Fact]
    public void Test_largeQuantityRange()
    {
        MinOverCancellation minOverCancellation = new MinOverCancellation();

        int target = 150005;

        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, 50000, 100));
        OrderList.Add(new Order(2, 60000, 100));
        OrderList.Add(new Order(3, 10, 100));
        OrderList.Add(new Order(4, 50000, 100));
        OrderList.Add(new Order(5, 100000, 100));
        OrderList.Add(new Order(6, 300, 100));

        int expectedResult = 150010;

        List<Order> resultList = minOverCancellation.Collect(OrderList, target);

        // Console.WriteLine(string.Format("Test_multiplePossibleScenarios: Id List: [{0}]", string.Join(", ", resultList.Select(e => e.Id))));

        Assert.Equal(expectedResult, resultList.Sum(order => order.Quantity));
    }

    [Fact]
    public void Test_noSolution()
    {
        MinOverCancellation minOverCancellation = new MinOverCancellation();

        int target = 5001;

        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, 500, 100));
        OrderList.Add(new Order(2, 400, 100));
        OrderList.Add(new Order(3, 1000, 100));
        OrderList.Add(new Order(4, 1000, 100));
        OrderList.Add(new Order(5, 20, 100));

        Assert.Empty(minOverCancellation.Collect(OrderList, target));
    }
}