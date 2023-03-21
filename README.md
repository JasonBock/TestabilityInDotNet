# TestabilityInDotNet

This repo contains demo code used for my "Testability in .NET" presentation. Following are notes on each of the projects:

## `TestabilityInDotNet`

Contains code that will be tested in various ways.

## `TestabilityInDotNet.Tests`

This project contains a number of test examples, all using NUnit, to test the code in `TestabilityInDotNet`. There are two mocking examples, one using Moq, the other using Rocks.

If you want to get code coverage numbers, you can run this from the project directory:

```
dotnet test --collect:"XPlat Code Coverage"
```

You can also install the following reporting tool:

```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

And run it passing in the generated XML file to get an HTML report:

```
reportgenerator -reports:"Path\To\TestProject\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

Example of this command:

```
reportgenerator -reports:"C:\Users\jason\source\repos\TestabilityInDotNet\TestabilityInDotNet.Tests\TestResults\0c6e276b-ecc7-4273-82b0-c464edb7eacf\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```