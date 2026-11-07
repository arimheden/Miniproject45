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

// Load list from file
if (File.Exists("assets.json")) assetManager.LoadAssets(ref assets);

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

        // Perform asset search
        case "3":
            assetManager.SearchAssets(assets);
            break;

        // Delete asset from list
        case "4":
            assetManager.DeleteAsset(ref assets);
            break;

        // Save asset list and exit program
        case "5":
            assetManager.SaveAssets(assets);
            break;

        // Exit program
        case "6":
            Environment.Exit(0);
            break;
    }
}


