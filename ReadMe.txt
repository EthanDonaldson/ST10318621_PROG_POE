Overview This is a simple console application for managing recipes. It allows users to add recipes, list existing recipes, and interact with them by scaling ingredients, resetting quantities, and more.

Github Link:https://github.com/EthanDonaldson/ST10318621_PROG_POE


Compilation and Execution Prerequisites .NET Core SDK installed on your machine. Compilation and Execution Clone this repository to your local machine: git clone https://github.com/EthanDonaldson/EthanDonaldson_ST10318621_PROG6221_POE Navigate to the project directory: cd EthanDonaldson_ST10318621_PROG6221_POE

Compile the application using the .NET CLI: dotnet build

Run the compiled application: dotnet run


How to Use the Application Add Recipe: Choose option 1 from the menu to add a new recipe. Follow the prompts to enter the recipe name, ingredients, and steps.

List Recipes: Choose option 2 from the menu to list all existing recipes. You can then select a recipe to view its details.

Scale Recipe: When adding or viewing a recipe, you have the option to scale its quantities. Choose "yes" when prompted and enter a scale factor (e.g., 0.5 for half, 2 for double, 3 for triple).

Reset Quantities: After scaling a recipe, you can choose to reset its quantities to their original values by selecting "yes" when prompted.

Clear Data: If you want to clear the data of a recipe and add a new one, choose "yes" when prompted after scaling or viewing a recipe.

Exit the Application: To exit the application, choose option 3 from the main menu, or press Ctrl + C in the terminal/command prompt.



How i Improved my code from part 1:

We used strong error handling in my project to deal with null data more skillfully. I guarantee application stability and prevent unexpected crashes by adding null checks to key code points, like user inputs and method arguments.

To guarantee accurate and trustworthy conversions between various units of measurement, I have improved the unit conversion feature. This required careful conversion method testing and validation to handle a range of input possibilities.
Now, users can depend on the application to convert amounts between different units precisely and error-free.

Also, by including thorough comments all across the source, I aimed to improve the readability and maintainability of the code. 
These comments offer insightful explanations of the reasoning behind each technique.



Reference List: Change forground colour according to GeeksforGeeks (2019), How to change Foreground Color of Text in Console [Online] available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/ [Accessed may 17 2024]

Array clear method according to GeeksforGeeks (2019), C# | Array.Clear() Method. [Online] available at : https://www.geeksforgeeks.org/c-sharp-array-clear-method/

Tutorials teacher (2020), C# - if, else if, else Statements [Online] available at : https://www.tutorialsteacher.com/csharp/csharp-if-else

Troeleson, A. Japikse, P. 2022. Pro C# with .NET 6 Foundational principles and practices in programming. Chamsbersburg, PA, USA

Khandelwal, V. An Ultimate One-Stop Solution Guide to Collections in C# Programming With Examples [Online] available at :https://www.simplilearn.com/tutorials/c-sharp-tutorial/collections-in-c-sharp [Accessed 30 May 2024]
