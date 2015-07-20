# Unit Testing Homework

## Task 1. Students and courses
*	Write three classes: `Student`, `Course` and `School`.
    *   Students should have name and unique number (inside the entire `School`).
        *   Name can not be empty and the unique number is between 10000 and 99999.
    *   Each course contains a set of students.
    *   Students in a course should be less than 30 and can join and leave courses.
*   Write VSTT tests
    *   Use 2 class library projects in Visual Studio: `School.csproj` and `School.Tests.csproj`
*   Execute the tests using Visual Studio and check the code coverage. Ensure it is at least 90%.

## Task 2. Unit test the `Deck` class from the `SantaseGameEngine`
*   [Deck.cs](https://github.com/NikolayIT/SantaseGameEngine/blob/master/Source/Santase.Logic/Cards/Deck.cs)
*   Use NUnit as a testing framework
*   Write at least one [Parameterized Test](http://nunit.org/index.php?p=parameterizedTests&r=2.6.1)

## Task 3*. Unit test the `PlayerActionValidater` class
*   Get known with the [Santase game rules](https://www.google.bg/search?q=%D0%BF%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0+%D1%81%D0%B0%D0%BD%D1%82%D0%B0%D1%81%D0%B5)
*   Download the [SantaseGameEngine](https://github.com/NikolayIT/SantaseGameEngine)
*   Review the [PlayerActionValidater.cs](https://github.com/NikolayIT/SantaseGameEngine/blob/master/Source/Santase.Logic/PlayerActionValidater.cs)
*   Write unit tests for the `IsValid` method
*   Ensure code coverage of 100% for the `PlayerActionValidater.cs` class
*   Fix any bugs you find during the unit testing
*   You can use testing framework of your choice
