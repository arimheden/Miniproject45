using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Miniproject45;

/* 
 * Helper class for asset list management
 * 
 */
internal class AssetManager
{
    // Request user input for product name
    public String userInput()
    {
        string userInput = Console.ReadLine();
        userInput = userInput.Trim();
        return userInput;
    }

    // Validate user input for product name
    public bool validateInput(string inputToValidate, string validateType)
    {
        if (String.IsNullOrEmpty(inputToValidate))
        {
            throw new ArgumentException("Input can not be empty!");
            return false;
        }

        // Validate price
        if (validateType == "price")
        {
            decimal price;
            if (Decimal.TryParse(inputToValidate, out price))
            {
                if (price > 0) return true;
                else
                {
                    throw new ArgumentException("Price can not be negative!");
                }
            }
            else
            {
                throw new ArgumentException("Price must be a decimal number!");
                return false;
            }

        }

        if (validateType == "id")
        {
            int id;
            if (Int32.TryParse(inputToValidate, out id))
            {
                if (id > 1000) return true;
                else
                {
                    throw new ArgumentException("Asset id must be a number greater than 1000!");
                }
            }
            else
            {
                throw new ArgumentException("Asset id must be a number!");
                return false;
            }
        }

        if (validateType == "office")
        {
            int office;
            if (Int32.TryParse(inputToValidate, out office))
            {
                if (office > 0 && office < 4) return true;
                else
                {
                    throw new ArgumentException("Office number must be either 1, 2 or 3!");
                }
            }
            else
            {
                throw new ArgumentException("Office must be a number!");
                return false;
            }
        }

        if (validateType == "assettype")
        {
            int assetType;
            if (Int32.TryParse(inputToValidate, out assetType))
            {
                if (assetType > 0 && assetType < 4) return true;
                else
                {
                    throw new ArgumentException("Asset type must be either 1, 2 or 3!");
                }
            }
            else
            {
                throw new ArgumentException("Asset type must be a number!");
                return false;
            }
        }

        if (validateType == "date")
        {
            DateTime inputDate;
            if (DateTime.TryParse(inputToValidate, out inputDate))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Purchase date must be a date!");
                return false;
            }
        }

        return true;
    }

    public void AddAsset(List<Asset> assets)
    {
        // Adding assets
        Console.WriteLine("Type 'q' to finish.");

        Console.WriteLine();
        int inputLine = 1;
        int assetType = 0;
        string brand = "";
        string model = "";
        double assetPrice = 0;
        DateTime assetDate = DateTime.MinValue;
        string office = "USA";

        while (true)
        {

            // Request user input
            switch (inputLine)
            {
                case 1:
                    Console.Write("Select office location. 1. USA, 2. Sweden, 3. Germany: ");
                    break;
                case 2:
                    Console.Write("Select asset type. 1. Desktop Computer, 2. Laptop, 3. Mobile Phone: ");
                    break;
                case 3:
                    Console.Write("Enter asset brand: ");
                    break;
                case 4:
                    Console.Write("Enter asset model: ");
                    break;
                case 5:
                    Console.Write("Enter purchase date (YY/MM/DD): ");
                    break;
                case 6:
                    Console.Write("Enter asset price: ");
                    break;
            }

            string userInput = this.userInput();

            // Terminate execution on "q"
            if (userInput == "q")
            {
                break;
            }

            switch (inputLine)
            {
                case 1:
                    // Validate user input
                    try
                    {
                        this.validateInput(userInput, "office");
                        if (userInput == "1") office = "USA";
                        else if (userInput == "2") office = "Sweden";
                        else if (userInput == "3") office = "Germany";
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case 2:
                    try
                    {
                        this.validateInput(userInput, "assettype");
                        Int32.TryParse(userInput, out assetType);
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case 3:
                    try
                    {
                        this.validateInput(userInput, "brand");
                        brand = userInput;
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case 4:
                    try
                    {
                        this.validateInput(userInput, "model");
                        model = userInput;
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case 5:
                    try
                    {
                        this.validateInput(userInput, "date");
                        DateTime.TryParse(userInput, out assetDate);
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case 6:
                    try
                    {
                        this.validateInput(userInput, "price");
                        assetPrice = Convert.ToDouble(userInput);
                        inputLine++;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
            }

            if (inputLine > 6)
            {
                inputLine = 1;
                if (assetType == 1) assets.Add(new Computer(brand, model, assetDate, assetPrice, office));
                else if (assetType == 2) assets.Add(new Laptop(brand, model, assetDate, assetPrice, office));
                else if (assetType == 3) assets.Add(new MobilePhone(brand, model, assetDate, assetPrice, office));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Asset has been added!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
            }


        }

    }

    // Show statistics
    public void AssetStatistics(ref List<Asset> assets)
    {
        Console.WriteLine("========= STATISTICS =========");
        Console.WriteLine();

        if (assets.Count() > 0) {
            Asset expensiveProduct = assets.OrderByDescending(a => a.PriceUSD).First();
            Asset cheapProduct = assets.OrderBy(a => a.PriceUSD).First();
            double average = assets.Average(a => a.PriceUSD);

            Console.WriteLine("Most Expensive Product:");
            Console.WriteLine();

            Console.WriteLine(expensiveProduct.Model + " - " + expensiveProduct.PriceUSD);

            Console.WriteLine("Cheapest Product:");

            Console.WriteLine(cheapProduct.Model + " - " + cheapProduct.PriceUSD);
            Console.WriteLine();

            Console.WriteLine("Average Price:");

            Console.WriteLine(average + " kr");
            Console.WriteLine();

            Console.WriteLine("Assets per Category:");
            var categories = assets.DistinctBy(a => a.AssetType);
            foreach (var category in categories) {
                Console.Write(category.AssetType + ": ");
                decimal categorySum = assets.Where(a => a.AssetType.Equals(category.AssetType)).Count();
                Console.WriteLine(categorySum);
            }

        }
    }

    // Sort and show products
    public void ShowAssets(List<Asset> assets)
    {
        Console.WriteLine();
        Console.WriteLine("ASSET LIST");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Office".PadRight(10)+" | "+"Type".PadRight(18)+" | "+"Brand".PadRight(18)+" | "+"Model".PadRight(18)+" | " + "Price (USD)".PadRight(15) + " | " + "Price (Local)".PadRight(15) + " | " + "Purchase Date".PadRight(15));
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
        foreach (Asset asset in assets.OrderBy(asset => asset.AssetType).ThenBy(asset => asset.PurchaseDate))
        {
            TimeSpan assetAge = DateTime.Now - asset.PurchaseDate;
            if (assetAge.Days  >= 1275) Console.ForegroundColor = ConsoleColor.Red;
            else if (assetAge.Days >= 1185) Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(asset.Office.PadRight(10) + " | " + asset.AssetType.PadRight(18) + " | " + asset.Brand.PadRight(18) + " | " + asset.Model.PadRight(18) + " | " + asset.PriceUSD.ToString("F").PadRight(15) + " | " + asset.PriceLocal.ToString("F").PadRight(15) + " | " + asset.PurchaseDate.ToString().PadRight(15));
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    // Search products by category or name
    public void SearchAssets(List<Asset> assets)
    {
        Console.Write("Search Asset: ");

        // Request user input
        string searchString = this.userInput();

        Console.WriteLine();
        Console.WriteLine("FOUND ASSETS:");
        Console.WriteLine();

        var assetQuery = from asset in assets where asset.AssetType.ToLower().Contains(searchString.ToLower())
                        || asset.Model.ToLower().Contains(searchString.ToLower()) select asset;

        foreach (Asset asset in assetQuery) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(asset.AssetType.PadRight(12) + " | " + asset.Model.PadRight(12) + " | " + asset.PriceUSD.ToString().PadRight(12));
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    // Delete asset by Id
    public void DeleteAsset(ref List<Asset> assets)
    {

        Console.Write("Delete Asset: ");

        // Request user input
        string deleteString = this.userInput();

        // Validate user input
        try
        {
            this.validateInput(deleteString, "id");
            if (assets.Any(asset => asset.Id == Convert.ToInt32(deleteString)))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Asset has been removed!");
                Console.ForegroundColor = ConsoleColor.Gray;
                assets.RemoveAll(asset => asset.Id.Equals(Convert.ToInt32(deleteString)));
            }
            else throw new ArgumentException("Asset does not exist!");

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    // Edit asset by Id
    public void EditAsset(ref List<Asset> assets)
    {

        Console.Write("Edit Asset: ");

        // Request user input
        string editString = this.userInput();

        // Validate user input
        try
        {
            this.validateInput(editString, "id");
            if (assets.Any(asset => asset.Id == Convert.ToInt32(editString)))
            {
                Console.Write("Enter new category (blank to keep existing): ");
                string newCategory = this.userInput();
                if (!String.IsNullOrEmpty(newCategory))
                {
                    this.validateInput(newCategory, "category");
                    try
                    {
                        foreach (Asset asset in assets.Where(w => w.Id == Convert.ToInt32(editString)))
                        {
                            asset.AssetType = newCategory;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }

                Console.Write("Enter new name (blank to keep existing): ");
                string newName = this.userInput();
                if (!String.IsNullOrEmpty(newName))
                {
                    this.validateInput(newName, "name");
                    try
                    {
                        foreach (Asset asset in assets.Where(w => w.Id == Convert.ToInt32(editString)))
                        {
                            asset.Model = newName;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                    
                Console.Write("Enter new price (blank to keep existing): ");
                string userInput = this.userInput();
                if (!String.IsNullOrEmpty(userInput))
                {
                    this.validateInput(userInput, "price");
                    try
                    {
                        double newPrice = Convert.ToDouble(userInput);
                        foreach (Asset asset in assets.Where(w => w.Id == Convert.ToInt32(editString)))
                        {
                            asset.PriceUSD = newPrice;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            else throw new ArgumentException("Asset does not exist!");

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    // Save products to json file
    public void SaveAssets(List<Asset> assets)
    {
        StreamWriter sw = new StreamWriter("assets.json");
        var jsonAssetList = JsonSerializer.Serialize(assets);
        sw.Write(jsonAssetList.ToString());
        sw.Close();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product list has been saved!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    // Save products to json file
    public void LoadAssets(ref List<Asset> assets)
    {
        string json = File.ReadAllText("assets.json");
        var jsonAssetList = JsonSerializer.Deserialize<List<Asset>>(json);
        assets = jsonAssetList;
        Asset.currentId = assets.Max(a => a.Id);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Asset list has been loaded!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    // Display menu and wait for key press
    public string AssetListMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Add Asset");
        Console.WriteLine("2. View Assets");
        Console.WriteLine("3. Search Asset");
        Console.WriteLine("4. Delete Asset");
        Console.WriteLine("5. Edit Asset");
        Console.WriteLine("6. Statistics");
        Console.WriteLine("7. Save Assets");
        Console.WriteLine("8. Load Assets");
        Console.WriteLine("9. Exit");
        Console.WriteLine();

        ConsoleKeyInfo keypressed;
        string numKey;
        do
        {
            keypressed = Console.ReadKey(true);
            numKey = keypressed.Key.ToString().Trim('D');

        } while (!Regex.IsMatch(numKey, @"^[1-9]+\z"));
        return numKey;
    }
}




