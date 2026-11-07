using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Miniproject45;

[JsonDerivedType(derivedType: typeof(Computer), typeDiscriminator: "Computer")]
[JsonDerivedType(derivedType: typeof(Laptop), typeDiscriminator: "Laptop")]
[JsonDerivedType(derivedType: typeof(MobilePhone), typeDiscriminator: "MobilePhone")]
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
    public Computer(int Id, string Brand, string Model, DateTime PurchaseDate, double PriceUSD, double PriceLocal, string Office)
    {
        this.Id = Id;
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceUSD = PriceUSD;
        this.PriceLocal = PriceLocal;
        this.Office = Office;
        this.AssetType = "Desktop Computer";
        currentId++;
        this.Id = currentId;

        if (Office == "USA") this.PriceUSD = PriceLocal;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "EUR");
    }
}

public class Laptop : Asset
{
    public Laptop(int Id, string Brand, string Model, DateTime PurchaseDate, double PriceUSD, double PriceLocal, string Office)
    {
        this.Id = Id;
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceUSD = PriceUSD;
        this.PriceLocal = PriceLocal;
        this.Office = Office;
        this.AssetType = "Laptop";
        currentId++;
        this.Id = currentId;

        if (Office == "USA") this.PriceUSD = PriceLocal;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "EUR");
    }
}

public class MobilePhone : Asset
{
    public MobilePhone(int Id, string Brand, string Model, DateTime PurchaseDate, double PriceUSD, double PriceLocal, string Office)
    {
        this.Id = Id;
        this.Brand = Brand;
        this.Model = Model;
        this.PurchaseDate = PurchaseDate;
        this.PriceUSD = PriceUSD;
        this.PriceLocal = PriceLocal;
        this.Office = Office;
        this.AssetType = "Mobile Phone";
        currentId++;
        this.Id = currentId;

        Console.WriteLine("Price = "+PriceLocal);

        if (Office == "USA") this.PriceUSD = PriceLocal;
        else if (Office == "Sweden") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "SEK");
        else if (Office == "Germany") this.PriceUSD = LiveCurrency.Convert(PriceLocal, "USD", "EUR");
    }
}