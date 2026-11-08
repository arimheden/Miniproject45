# Asset Management Application

This is a console application that lets you manage a list of company assets such as desktop/laptop computers and mobile phones.

It will keep track of assets for offices in USA, Sweden and Germany and will display purchase prices in the currency local to the office an asset belongs to.

The application will also keep track of the asset's age and warn with color coding if an asset is older than 3 years. 
If it is more than 3 months older than 3 years, the asset will be displayed with yellow color. If it is more than 6 months older than 3 years it will be red.

## Usage

To use the asset manager you select from 6 menu options, which are shown when the application starts.

The first option is to add an asset. You will need to enter the details of your asset(s) and then enter the letter 'q' to exit this mode and go back
to the main menu.

The second option is to view assets, which will display a list of all available assets sorted by asset type and purchase date.

The third option will let you search for an asset by type, brand or model name.

The fourth option will let you delete an asset from the list by entering its' model name.

The fifth option will save the asset list to a file, encoded in json format, which will automatically be loaded when the application starts.

And the sixth and final option will exit the application.
