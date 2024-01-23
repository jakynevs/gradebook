# Introduction to C# Gradebook

## Overview
The Introduction to C# Gradebook is a tutorial project that demonstrates fundamental C# programming concepts. It allows users to enter and manage student grades with rigorous validation and provides statistical analysis of the grades. The project showcases event-driven programming, interface implementation, file I/O, and exception handling in C#.

## Features
- **Grade Input with Validation:** Users can enter grades, validated to be between 0 and 100.
- **Event-Driven Programming:** Utilizes `GradeAddedDelegate` to handle grade addition events.
- **Interfaces and Abstraction:** Implements the `IBook` interface and an abstract `Book` class.
- **InMemoryBook and DiskBook Classes:**
  - `InMemoryBook`: Manages grades in memory.
  - `DiskBook`: Stores grades in a text file, demonstrating file I/O operations.
- **Exception Handling:** Implements robust exception handling in the `AddGrade` method.
- **Statistics Computation:** Calculates minimum, maximum, and average grades using the `GetStats` method.
- **Generics Usage:** Manages grades using a `List<double>`.

## Technologies Used
- C#
- .NET Framework

## Installation

To run this Gradebook project, ensure you have the .NET Framework installed on your system. 

1. Clone the repository:
`git clone https://github.com/jakynevs/gradebook`
2. Navigate to the project directory:
`cd src/Gradebook`
3. Compile the project:
`dotnet build`
4. Run the application:
`dotnet run`

## Usage

Once the application is running:
- Enter grades as prompted.
- The system will automatically calculate and display the minimum, maximum, and average grades after each entry.

## Unit Testing

To run unit tests:
- Navigate to the test project directory.
- Use the command `dotnet test`.



