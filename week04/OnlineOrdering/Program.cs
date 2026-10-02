using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------
        // ORDER 1 - USA CUSTOMER
        // -------------------------

        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Keyboard",
            "K100",
            25.99,
            2
        );

        Product product2 = new Product(
            "Mouse",
            "M200",
            15.50,
            1
        );

        Product product3 = new Product(
            "USB Cable",
            "U300",
            8.99,
            3
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // -------------------------
        // ORDER 2 - INTERNATIONAL CUSTOMER
        // -------------------------

        Address address2 = new Address(
            "45 Reforma Avenue",
            "Mexico City",
            "CDMX",
            "Mexico"
        );

        Customer customer2 = new Customer(
            "Maria Garcia",
            address2
        );

        Order order2 = new Order(customer2);

        Product product4 = new Product(
            "Laptop Stand",
            "L400",
            45.99,
            1
        );

        Product product5 = new Product(
            "Webcam",
            "W500",
            59.99,
            2
        );

        Product product6 = new Product(
            "Headphones",
            "H600",
            35.00,
            1
        );

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        // -------------------------
        // DISPLAY ORDER 1
        // -------------------------

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine();

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");

        Console.WriteLine();


        // -------------------------
        // DISPLAY ORDER 2
        // -------------------------

        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}