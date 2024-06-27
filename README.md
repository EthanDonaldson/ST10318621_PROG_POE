Overview This is a simple console application for managing recipes. It allows users to add recipes, list existing recipes, and interact with them by scaling ingredients, resetting quantities, and more.

Github Link:https://github.com/EthanDonaldson/ST10318621_PROG_POE



Prerequisites:
Visual Studio: Ensure you have Visual Studio installed on your computer. This guide assumes you are using Visual Studio for development.

Project Setup: Make sure your RecipeWPF project is set up correctly with all necessary files, including MainWindow.xaml, AddRecipeWindow.xaml, and their corresponding code-behind files (MainWindow.xaml.cs, AddRecipeWindow.xaml.cs).

Compilation and Running Steps:
Open Visual Studio:

Launch Visual Studio from your Start menu or desktop shortcut.
Open Your Solution:

Go to File > Open > Project/Solution....
Navigate to the folder where your RecipeWPF project is located and select the solution file (typically ends with .sln).
Build the Solution:

Once your solution is open in Visual Studio, go to Build > Build Solution (or simply press Ctrl + Shift + B).
This will compile your project, including all code files and XAML resources, into an executable format.
Set Startup Project (if not set):

Right-click on your main project in the Solution Explorer.
Select Set as StartUp Project. This ensures that when you run your solution, the correct project starts.
Run the Application:

Press F5 or go to Debug > Start Debugging to run your application.
Alternatively, you can also use Ctrl + F5 for Start Without Debugging.
This action will launch your WPF application in a new window.
Interact with Your Application:

Once the application window appears, you can interact with it as designed:
Use buttons like Add Recipe to open new windows (AddRecipeWindow) for adding recipes.
Use filters and buttons (Filter Recipes) in MainWindow to filter and display recipes.
Verify that data binding between UI elements and your RecipeManager is functioning as expected.
Debugging and Troubleshooting:

If any errors occur during compilation or runtime, Visual Studio will provide error messages in the Output window or Error List. Address these errors based on the messages provided.
Stopping the Application:

Close the application window by clicking the close button (X) in the top-right corner of the window.


How i Improved my code from part 2:

In enhancing the Recipe Manager application, several key features were implemented to improve functionality and user experience.
Firstly, the display was refined with structured separators (**********) and increased spacing, enhancing readability and organization of recipe details. 
Secondly, a comprehensive explanation was integrated to clarify the significance of calorie values and food groups, aiding users in making informed dietary choices.

Additionally, users can now select food groups from specified options, facilitating streamlined data input and categorization within recipes. 
The application now calculates and displays the total calories for each recipe, accompanied by contextual messages based on calorie ranges: low calories suitable for snacks, moderate for balanced meals, and high for occasional consumption.
These enhancements provide users with immediate insights into nutritional aspects, fostering healthier decision-making.

Moreover, the code was annotated with comments elucidating variable names, method functionalities, and programming logic across all classes. 
This ensures transparency and ease of comprehension for developers maintaining or expanding the application in the future. 
Overall, these improvements make the Recipe Manager more user-friendly, informative, and robust in supporting dietary management and recipe customization.



Reference List: Change forground colour according to GeeksforGeeks (2019), How to change Foreground Color of Text in Console [Online] available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/ [Accessed may 17 2024]

Array clear method according to GeeksforGeeks (2019), C# | Array.Clear() Method. [Online] available at : https://www.geeksforgeeks.org/c-sharp-array-clear-method/

Tutorials teacher (2020), C# - if, else if, else Statements [Online] available at : https://www.tutorialsteacher.com/csharp/csharp-if-else

Troeleson, A. Japikse, P. 2022. Pro C# with .NET 6 Foundational principles and practices in programming. Chamsbersburg, PA, USA

Khandelwal, V. An Ultimate One-Stop Solution Guide to Collections in C# Programming With Examples [Online] available at :https://www.simplilearn.com/tutorials/c-sharp-tutorial/collections-in-c-sharp [Accessed 30 May 2024]
