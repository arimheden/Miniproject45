using System;
using System.Collections.Generic;
using System.Text;

namespace Miniproject45;
public abstract class Asset
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double PriceUSD { get; set; }
    public double PriceLocal { get; set; }
    public string Office { get; set; }
    public string AssetType { get; set; }

    static public int currentId = 1000;
}

public class Computer : Asset
{
    public Computer(string Brand, string Model, DateTime PurchaseDate, double Price, string Office)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceLocal = Price;
        this.Office = Office;
        this.AssetType = "Desktop Computer";
        currentId++;
        this.Id = currentId;

        if (Office == "USA") this.PriceUSD = Price;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "EUR");
    }
}

public class Laptop : Asset
{
    public Laptop(string Brand, string Model, DateTime PurchaseDate, double Price, string Office)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceLocal = Price;
        this.Office = Office;
        this.AssetType = "Laptop";
        currentId++;
        this.Id = currentId;

        if (Office == "USA") this.PriceUSD = Price;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "EUR");
    }
}

public class MobilePhone : Asset
{
    public MobilePhone(string Brand, string Model, DateTime PurchaseDate, double Price, string Office)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceLocal = Price;
        this.Office = Office;
        this.AssetType = "Mobile Phone";
        currentId++;
        this.Id = currentId;

        if (Office == "USA") this.PriceUSD = Price;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(Price, "USD", "EUR");
    }
}