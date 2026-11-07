using Miniproject45;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text.Json.Serialization;


// Display instructions
Console.WriteLine("--------------------------------");
Console.WriteLine("   ASSET MANAGER - LEVEL 4");
Console.WriteLine("--------------------------------");
Console.WriteLine();

// Get currency rates
LiveCurrency.FetchRates();

// Initialize list
List<Asset> assets = new List<Asset>();

// Initialize helper class'
AssetManager assetManager = new AssetManager();

while (true)
{

    string menuOption = assetManager.AssetListMenu();

    switch (menuOption)
    {
        case "1":
            assetManager.AddAsset(assets);
            break;
                
        // Perform product sort and display
        case "2":
            assetManager.ShowAssets(assets);
            break;

        // Perform product search
        case "3":
            assetManager.SearchAssets(assets);
            break;

        // Delete product from list
        case "4":
            assetManager.DeleteAsset(ref assets);
            break;

        // Edit product
        case "5":
            assetManager.EditAsset(ref assets);
            break;

        // Show statistics
        case "6":
            assetManager.AssetStatistics(ref assets);
            break;

        // Save product list and exit program
        case "7":
            assetManager.SaveAssets(assets);
            break;

        // Load product list and exit program
        case "8":
            assetManager.LoadAssets(ref assets);
            break;

        // Exit program
        case "9":
            Environment.Exit(0);
            break;
    }
}


