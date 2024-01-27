# Pierre's Bakery

#### By Noah Kise

#### A C# web application to allow a bakery owner to keep track of orders.

## Technologies Used

* C#
* MSTest
* Javascript

## Description

This is a simple web application to help a fictional bakery owner keep track of their orders.  It allows the user to fill out a form to add vendors to a master list, and then allows the user to click on any vendor name to see orders for that vendor, as well as a link to a form to fill out to create a new order for that vendor.

## Setup/Installation Requirements

* .NET must be installed. Latest version can be found [here](https://dotnet.microsoft.com/en-us/).
* To run locally on your computer, clone the main branch of this [repository](https://github.com/NoahKise/vendor-and-order-tracker).
* In your terminal, navigate to the root folder of this project and run `dotnet restore`.
* Navigate to the "Pierre" directory and run `dotnet run`.

## Known Bugs

* Near the end of the day I realized a pretty significant bug, which is that if you attempt to add two different items to an order and enter the same quantity for each, the program will crash.  This is because the orders are currently being stored as a dictionary, with quantities being keys and item names being values.  Because you can't have matching keys in a dictionary, the program crashes.  I am planning to refactor the code to store the items in a list instead of a dictionary, but at time of submission this bug persists.

## License

Code licensed under [GPL](LICENSE.txt)

Any suggestions for ways I can improve this app? Reach out to me at noah@kisefamily.com

Copyright (c) January 26 2024 Noah Kise