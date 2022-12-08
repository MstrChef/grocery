
///main section
class grocery 
{
    static void Main(string[]args)
    {
        /// prints the options that are at the store for purchase
        Console.WriteLine("Welcome to Walmart");
        Console.WriteLine("Our current options are:");
        Console.WriteLine("Apples - $1.00");
        Console.WriteLine("Oranges - $1.00");
        Console.WriteLine("Bananas - $1.00");
        Console.WriteLine("Ham - $3.50");
        Console.WriteLine("Turkey - $3.50");
        Console.WriteLine("Cheese - $3.00");
        Console.WriteLine("Plates - $2.50");
        Console.WriteLine("Napkins - $2.50");
        Console.WriteLine("Due to some problems, we will be limiting purchases to 8 items max.");
        Console.WriteLine("Please enter your items below: ");
        Console.WriteLine("Enter 'Done' when you finish your list or if you have less than 8 items.");

        var Apples = new Item(1.00, "Apples", true);
        var Oranges = new Item(1.00, "Oranges", true);
        var Bananas = new Item(1.00, "Bananas", true);
        var Ham = new Item(3.50, "Ham", true);
        var Turkey = new Item(3.50, "Turkey", true);
        var Cheese = new Item(3.00, "Cheese", true);
        var Plates = new Item(2.50, "Plates", false);
        var Napkins = new Item(2.50, "Napkins", false);

        /// has the values for each item in store
        var WalmartItems = new Dictionary <string,Item>();
        WalmartItems.Add("Apples", Apples); ///, "Apples", object with relation to taxable or not and the price
        WalmartItems.Add("Oranges", Oranges);
        WalmartItems.Add("Bananas", Bananas);
        WalmartItems.Add("Ham", Ham);
        WalmartItems.Add("Turkey", Turkey);
        WalmartItems.Add("Cheese", Cheese);
        WalmartItems.Add("Plates", Plates);
        WalmartItems.Add("Napkins", Napkins);

        List<Item>itemList = items(WalmartItems);
        
        double total = computeTotal(itemList);

        double subTotal = computeSubTotal(itemList);

        double taxValue = computeTax(total, subTotal);
        
        receipt(subTotal, taxValue, total);
    
    }



/// takes user input to create a list of items
static List<Item> items(Dictionary <string,Item> WalmartItems) {
    var listTotal = 0; 
    List<Item> itemList = new List<Item>(); 
    /// gets the first value
    string input = Console.ReadLine();     
    itemList.Add(WalmartItems[input]);
    listTotal ++;

        while (listTotal < 8){
        
        /// checks to make sure the item is in the store

        if (WalmartItems.ContainsKey(input)) {
            string inputNewItem = Console.ReadLine();

            if (inputNewItem == "Done"){
                listTotal = 8;
            }
            /// gets the next value and will repeat this
            else {
                itemList.Add(WalmartItems[inputNewItem]);
                listTotal ++;
            }
        }
        /// if statement to show that item is not valid
        else{
            Console.WriteLine("Invalid item, please enter item again.");
        }
    }    
    return itemList;
}

/// adds the items together to get the total price
 static  double computeTotal(List<Item> itemList) {
    double total = 0;
    foreach (Item item in itemList) {
        if (item.getisTaxable() == true) {
            double tax = item.getPrice() * 0.08;
            total = tax + item.getPrice() + total;
        }
        else {
            total = item.getPrice() + total;
        }
    }
    return total;
 }

static double computeSubTotal(List<Item> itemList) {
    double subTotal = 0;
        foreach (Item item in itemList) {
            subTotal = item.getPrice() + subTotal;
        }
        return subTotal;
}
/// multiples the total item value by the tax amount
static double computeTax(double total, double subTotal) {
       double taxValue = total - subTotal;
       return taxValue;
}

/// creates the receipt with the total price
static void receipt(double subTotal, double taxValue, double total) {
    Console.WriteLine("Here is your receipt");
    Console.WriteLine("Total: $" + subTotal);
    Console.WriteLine("Tax: $" + taxValue);
    Console.WriteLine("Total Due: $" + total);
    }
}

class Item {
    private double price;
    private string name;
    private bool isTaxable;
    public Item(double price, string name, bool isTaxable){
        this.price = price;
        this.name = name;
        this.isTaxable = isTaxable;
    }
    public double getPrice() {
        return price;
    }
    public bool getisTaxable() {
        return isTaxable;
    }
}

class TaxableItem : Item {
    public TaxableItem(double price, string name, bool isTaxable) : base(price, name, isTaxable) ///base references to the Item class
    {
    }
}