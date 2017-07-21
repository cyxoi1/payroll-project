# C# Project - A Simple Payroll Software

## <a name="1"></a>Objectives

We are going to get our feet wet by coding a complete console application that generates the salary slips of a small company.

## <a name="2"></a>Overview

First, let’s create a new console application and name it `CSProject`.

This application consists of six classes as shown below.
```
Staff
Manager : Staff
Admin : Staff
FileReader
PaySlip
Program
```
The `Staff` class contains information about each staff in the company. It also contains a virtual method called `CalculatePay()` that calculates the pay of each staff.

The `Manager` and `Admin` classes inherit the `Staff` class and override the `CalculatePay()` method.

The `FileReader` class contains a simple method that reads from a .txt file and creates a list of `Staff` objects based on the contents in the .txt file.

The `PaySlip` class generates the pay slip of each employee in the company. In addition, it also generates a summary of the details of staff who worked less than 10 hours in a month.

Finally, the `Program` class contains the `Main()` method which acts as the main entry point of our application.

