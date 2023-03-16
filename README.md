# Sportradar.Scoreboard
## Live Football World Cup Score Board Library
This is a simple .NET 6 library that implements a live score board for the Football World Cup. It allows users to view the scores of matches in real-time, as well as the current standings of teams in the tournament.

Task Instructions [here](/docs/Instructions.txt)
## Implementation

The solution has been implemented using C# in .NET 6 and following Object-Oriented Programming (OOP) and the code also adheres to the SOLID design principles, ensuring that it is easy to understand, maintain, and extend.

An in-memory store has been used to store the necessary information required to display the live score board. This solution uses collections to store the match results, teams, and their respective scores.

This project was developed using Test-Driven Development (TDD), an iterative development process that emphasizes writing automated tests before writing production code. By following TDD, I was able to ensure that the code is reliable and meets the requirements, as well as improve the design of the code by iteratively refining and refactoring the tests and the code.

  ![Schema](https://www.perfecto.io/sites/default/files/image/2022-08/image-blog-test-driven-data.jpg)
(image
  credit: [Perfecto blog](https://www.perfecto.io/blog/test-driven-development))

## Technology Stack
 - .NET 6
 - Xunit
 
## How to Use

To use this library, simply include the necessary classes in your project, instantiate the score board, and use the provided methods to display the scores and standings.


```csharp
// Example usage
var newScoreboard = new Scoreboard("Worldcup");
var newMatch_Ger_Fra = new Match(new Team("Germany"), new Team("France"));
newScoreboard.AddMatch(newMatch_Ger_Fra);
	newMatch_Ger_Fra.StartMatch();
	newMatch_Ger_Fra.UpdateScore(2, 2);
	newMatch_Ger_Fra.EndMatch();

// you can get list of online matches from : newScoreboard.GetOnlineMatches()

newMatch_Ger_Fra.GetMatchResultSummary() \\ retuns: Germany 2 - France 2
//or 
newScoreboard.GetAllMatches()[0].GetMatchResultSummary()
```
## Installation
Clone this repository and open the solution file with Visual Studio or any other compatible IDE.

## Usage
Run the Xunit tests to see the implementation of the Live Football World Cup Score Board.

## Contribution

This solution was developed as a part of a programming task. However, if you find any issues or have suggestions for improvements, please feel free to create a pull request or open an issue in the repository.