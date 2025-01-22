# basketball-league
C# application with a 4-layered architecture: 
- data access layer ([domain package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/domain))
- persistence layer ([repository package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/repository))
- business layer ([service package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/service))
- presentation layer ([user interface package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/userInterface)).

The data are saved in txt files ([data package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/data)). Validation classes have been created for data entities ([validator package](https://github.com/Iri25/basketball-league/tree/main/League/League/League/validator)). Interaction with the user is done from the console.

## Key concepts:
- abstraction
- encapsulation
- inheritance
- polymorphism
- validations
- exceptions
- reading from files
- storing in files
- Generics
- Delegates
- LINQ

## Requirements:
Application for a basketball league. Several schools participate in the competition, where each school is represented by 15 students. Some students may play in several matches, participate as a substitute, or may not participate at all. There are data about teams, players, matches and active players and it is requested:
1. Display all players of a given team
2. Display all active players of a team in a specific match
3. Displaying all matches from a certain calendar period
4. Determine and display the score of a specific match
