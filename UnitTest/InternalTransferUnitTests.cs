namespace KTGTechAssessment;
using KTGTech;
public class InternalTransferUnitTest
{
    [Fact]
    public void Test_multiplePossibleScenarios()
    {
        InternalTransfer internalTransfer = new InternalTransfer();
        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, -5, 100));
        OrderList.Add(new Order(2, -15, 100));
        OrderList.Add(new Order(3, 10, 100));
        OrderList.Add(new Order(4, 15, 100));
        OrderList.Add(new Order(5, 5, 100));
        OrderList.Add(new Order(6, 5, 100));

        List<Order> expectedList = new List<Order>();
        expectedList.Add(new Order(1, -5, 100));
        expectedList.Add(new Order(2, -15, 100));
        expectedList.Add(new Order(3, 10, 100));
        expectedList.Add(new Order(5, 5, 100));
        expectedList.Add(new Order(6, 5, 100));

        List<Order> resultList = internalTransfer.Collect(OrderList);

        //  Console.WriteLine(string.Format("Test_multiplePossibleScenarios: Id List: [{0}]", string.Join(", ", resultList.Select(e => e.Id))));

        Assert.Equal(5, resultList.Count);
        Assert.Equal(expectedList[0].Id, resultList[0].Id);
        Assert.Equal(expectedList[1].Id, resultList[1].Id);
        Assert.Equal(expectedList[2].Id, resultList[2].Id);
        Assert.Equal(expectedList[3].Id, resultList[3].Id);
        Assert.Equal(expectedList[4].Id, resultList[4].Id);

    }

    [Fact]
    public void Test_emptyOrderList()
    {
        InternalTransfer internalTransfer = new InternalTransfer();
        List<Order> OrderList = new List<Order>();

        Assert.Empty(internalTransfer.Collect(OrderList));

    }

    [Fact]
    public void Test_largeQuantityRange()
    {
        InternalTransfer internalTransfer = new InternalTransfer();

        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, -5000, 100));
        OrderList.Add(new Order(2, 4000, 100));
        OrderList.Add(new Order(3, -1000, 100));
        OrderList.Add(new Order(4, 1000, 100));
        OrderList.Add(new Order(5, 20000, 100));
        OrderList.Add(new Order(6, 1000, 100));

        List<Order> expectedList = new List<Order>();
        expectedList.Add(new Order(1, -5000, 100));
        expectedList.Add(new Order(2, 4000, 100));
        expectedList.Add(new Order(3, -1000, 100));
        expectedList.Add(new Order(4, 1000, 100));
        expectedList.Add(new Order(6, 1000, 100));

        List<Order> resultList = internalTransfer.Collect(OrderList);

        //  Console.WriteLine(string.Format("Test_largeQuantityRange: Id List: [{0}]", string.Join(", ", resultList.Select(e => e.Id))));
        Assert.Equal(5, resultList.Count);
        Assert.Equal(expectedList[0].Id, resultList[0].Id);
        Assert.Equal(expectedList[1].Id, resultList[1].Id);
        Assert.Equal(expectedList[2].Id, resultList[2].Id);
        Assert.Equal(expectedList[3].Id, resultList[3].Id);
        Assert.Equal(expectedList[4].Id, resultList[4].Id);

    }

    [Fact]
    public void Test_noSolution()
    {
        InternalTransfer internalTransfer = new InternalTransfer();

        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, 500, 100));
        OrderList.Add(new Order(2, 400, 100));
        OrderList.Add(new Order(3, 1000, 100));
        OrderList.Add(new Order(4, 1000, 100));
        OrderList.Add(new Order(5, 20, 100));
        OrderList.Add(new Order(6, 100, 100));

        Assert.Empty(internalTransfer.Collect(OrderList));
    }
}