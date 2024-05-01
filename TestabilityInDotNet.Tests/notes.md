To get code coverage from the CLI, run this:

```
dotnet test --collect:"XPlat Code Coverage"
```

You'll get an XML file with coverage information, but...that's not fun to read. Install this tool:

```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

And then run this command:

```
reportgenerator -reports:"path-to-coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```