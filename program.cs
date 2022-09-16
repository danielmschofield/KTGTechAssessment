using KTGTech;

class Program
{
    static void Main(string[] args)
    {
        InternalTransfer internalTransfer = new InternalTransfer();
        // Default Order list for Internal Transfer method
        List<Order> OrderList = new List<Order>();
        OrderList.Add(new Order(1, -5, 100));
        OrderList.Add(new Order(2, 10, 100));
        OrderList.Add(new Order(3, 10, 100));
        OrderList.Add(new Order(4, 5, 100));
        OrderList.Add(new Order(5, 5, 100));
        OrderList.Add(new Order(6, 5, 100));

        // Default Order list and target for Min Over Cancellation method
        MinOverCancellation minOverCancellation = new MinOverCancellation();
        int target = 13;
        List<Order> OrderList2 = new List<Order>();
        OrderList2.Add(new Order(1, 5, 100));
        OrderList2.Add(new Order(2, 10, 100));
        OrderList2.Add(new Order(3, 10, 100));
        OrderList2.Add(new Order(4, 5, 100));
        OrderList2.Add(new Order(5, 5, 100));
        OrderList2.Add(new Order(6, 3, 100));

        // Default call to Methods
        Console.WriteLine(string.Format("Internal Transfer Id List: [{0}]", string.Join(", ", internalTransfer.Collect(OrderList).Select(e => e.Id))));
        //Big O: Time O(n!) Space O(n^2)

        Console.WriteLine(string.Format("Min Over Cancellation Id List: [{0}]", string.Join(", ", minOverCancellation.Collect(OrderList2, target).Select(e => e.Id))));
        //Big O:  Time O(2^(n-1)) Space O(n^2)

    }
}