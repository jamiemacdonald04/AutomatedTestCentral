##Coffee Select 

Creating the right cup of coffee takes time.  In this example we are not interested in the individual parts of making a 
coffee such as grinding beans etc.   We are more interested in the mechanism of making a coffee.  What hapens if there
is no coffee beans or the griding fails.  This process should be seperate from the grinding and getting of said beans. 
Enabling it to be used many times by many different grinding processes and bean getters.

### Abstracted Methods for Mocking
You will see the inteface/abstact class used to stub out the following methods:

1. GrindBeans()
2. GetBeans()

These methods may not be implemented, the may deliver sub par coffee beans.  We don't care, we are only interested in
testing the Coffee Makers ability to make coffee when we walk through each of the scenarios.

Out of scope of this project is what will happen if the mocked methods throw and exception.
### Supported Languages 
There are four examples of this library that essentially using different toolsets, these are:
* Golang 
* CSharp
* Python
* Java

### IDE

I use either the jetbrains IDE's or visual studio code.  You can download vs code via this link:

https://code.visualstudio.com

When editing each of the languages I suggest navigating to the language folder before opening it in your IDE.

### Running the code 
```
# python
python make_coffee.py

# csharp
nuget restore
dotnet run --project CoffeeMakerUI/CoffeeMakerUI.csproj

```

### Running the tests
You can run these test by navigating to the code directory and running the following:
```
# python
python -m unittest

# GoLang
go mod tidy
go test -v

# java 
mvn clean test

# csharp
dotnet test 
```
