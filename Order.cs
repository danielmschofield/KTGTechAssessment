namespace KTGTech;
public class Order {
    private int id;
    private int quantity;
    private decimal price;

    public Order(int Id, int Quantity, decimal Price){

        this.Id = Id;
        this.Quantity = Quantity;
        this.Price = Price;
    }

    public int Id
    {
        get { return id;  }
        set { id = value; }
    }

    public int Quantity
    {
        get { return quantity;  }
        set { quantity = value; }
    }

    public decimal Price
    {
        get { return price;  }
        set { price = value; }
    }

}
