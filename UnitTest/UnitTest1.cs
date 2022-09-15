namespace KTGTechAssessment;
using KTGTech;

public class InternalTransferUnitTest
{
    [Fact]
    public void Test1()
    {
        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, -5, 100));
        OrderList.Add(new Order(2, 10, 100));
        OrderList.Add(new Order(3, 10, 100));
        OrderList.Add(new Order(4, 5, 100));
        OrderList.Add(new Order(5, 5, 100));
        OrderList.Add(new Order(6, 5, 100));

        Console.WriteLine(string.Format("Internal Transfer Id List: [{0}]", string.Join(", ", InternalTransfer.Collect(OrderList).Select(e => e.Id))));
    }
}