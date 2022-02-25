# yamldotnet-bug-report
Minimum reproducible example for YamlDotNet bug report

## How to run

You need dotnet CLI 6 or higher.

```
cd YamlDotNetBugReport
dotnet run
```

The output should look like this:
```
~~~ Trying to parse example1.yaml ~~~ 
Employees: 3
- Name: John Smith, Age: 30, Title: Software Developer
- Name: John Smith, Age: 30, Title: Software Developer
- Name: Mary Jane, Age: 30, Title: Software Developer 

~~~ Done with example1.yaml ~~~
~~~ Trying to parse example2.yaml ~~~ 
Employees: 2
- Name: John Smith, Age: 30, Title: Software Developer
- Name: Mary Jane, Age: 30, Title: Software Developer

~~~ Done with example2.yaml ~~~
~~~ Trying to parse example3.yaml ~~~
Failed parsing example3.yaml! Exception message:
(Line: 9, Col: 5, Idx: 269) - (Line: 9, Col: 16, Idx: 280): Alias $swdev_30yo cannot precede anchor declaration
```