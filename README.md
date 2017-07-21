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

## The Staff Class

First, let’s start with the `Staff` class. The `Staff` class contains basic information about an employee and provides a method for calculating basic pay. It serves as a parent class from which two other classes will be derived.

### Fields

This class has one private float field called `hourlyRate` and one private int field called `hWorked`.

### Properties

Next, declare three `public` auto-implemented properties for the class. The properties are `TotalPay`, `BasicPay` and `NameOfStaff`.

`TotalPay` is a float property and has a `protected` setter. `BasicPay` is a float property and has a `private` setter. `NameOfStaff` is a `string` property and has a `private` setter. The getters of all three properties are `public`. Hence, you do not need to declare the access modifiers of these getters as they have the same access level as the properties.

In addition to these three auto-implemented methods, the `Staff` class also has a `public` property called `HoursWorked`. The backing field for this property is the `hWorked` field.

This property has a getter that simply returns the value of `hWorked`. The setter checks if the value set for `HoursWorked` is greater than 0. If it is, it assigns value to `hWorked`. If it is not, it assigns 0 to `hWorked`.

### Constructor

The `Staff` class has a public constructor with two parameters, `name` (`string`) and `rate` (`float`). Inside the constructor, we assign the two parameters to the property `NameOfStaff` and the field `hourlyRate` respectively.

### Method

Now, let’s write the methods for the class.

First, we’ll code a virtual method called `CalculatePay()`.

`CalculatePay()` is `public`, has no parameters and does not return a value. The method does three things:

First, it prints the line “Calculating Pay…” on the screen. Next, it assigns the value of `hWorked*hourlyRate` to the `BasicPay` property. Finally, it assigns the value of `BasicPay` to the `TotalPay` property. In other words, BasicPay and TotalPay will have the same value.

Finally, write a `ToString()` method to display the values of the fields and properties of the `Staff` class. That’s all there is to the `Staff` class.

The table below shows a summary of the `Staff` class.

**_Fields_**
```
private float hourlyRate
private int hWorked (backing field for HoursWorked)
```

**_Properties_**
```
public float TotalPay
public float BasicPay
public string NameOfStaff
public int HoursWorked
```

**_Constructor_**
```
public Staff(string name, float rate)
```

**_Methods_**
```
public virtual void CalculatePay()
public override string ToString()
```

## The Manager : Staff Class

Next, let’s move on to code the `Manager` class.

## Fields

The `Manager` class is a child class of the `Staff` class. It has one `private` `const` field called `managerHourlyRate` that is of `float` type. Try declaring this field and initializing it with a value of 50.

## Properties

`Manager` also has a public auto-implemented property called `Allowance`. Allowance is of `int` type and has a `private` setter.

## Constructor

Now, let’s declare the constructor for `Manager`. The `Manager` class has a `public` constructor with a `string` parameter, `name`.

The task of the constructor is to call the base constructor and pass the parameter `name` and the field `managerHourlyRate` to the base constructor. Other than that, the child constructor does nothing. Hence, there is nothing within the curly braces of the child constructor. Try coding this constructor yourself. You can refer to the `Manager` class summary below for help if you have problems coding the constructor.

## Method

Next, let's code a method to override the `CalculatePay()` method in the `Staff` class. As `Manager` is derived from `Staff`, it has access to the `BasicPay`, `TotalPay` and `HoursWorked` properties declared in the `Staff` class. 
In addition, `Manager` also has its own property – `Allowance`. We’ll be making use of these four properties in this method.

First, let’s declare the method. `CalculatePay()` is `public` and does not return any value. We have to use the override keyword when declaring this method as it overrides the `CalculatePay()` method in the `Staff` class.

Within the `CalculatePay()` method in the `Manager` class, we shall first call the `CalculatePay()` method in the parent class and use it to set the values of `BasicPay` and `TotalPay`. To call a `virtual` method in the parent class, you have to use the base keyword. Add the following line to your `CalculatePay()` method.
```
base.CalculatePay();
```
This calls the `CalculatePay()` method in the base (parent) class, which sets the values of `BasicPay` and `TotalPay`. After setting the values of these two properties, let’s go on to set the value of `Allowance`. We’ll set the value to 1000.

Next, we want to change the value of `TotalPay`. Based on the `CalculatePay()` method in the base class, `TotalPay` is equal to `BasicPay`, both of which are equal to the product of `hWorked` and `hourlyRate`.

However, in the `Manager` child class, we want to update the value of `TotalPay` by adding an allowance to it. Suppose a manager is paid an allowance of $1000 if he/she worked more than 160 hours within that month. Try using an `if` statement to update the value of `TotalPay` based on the value of `HoursWorked`.

After updating the value of `TotalPay`, the `CalculatePay()` method is complete.

Finally, we need to code the `ToString()` method for the `Manager` class.

Once you are done, the `Manager` class is complete. The table below shows a summary of the `Manager` class.

**_Fields_**
```
private const float managerHourlyRate
```

**_Properties_**
```
public int Allowance
```

**_Constructor_**
```
public Manager(string name) : base(name, managerHourlyRate)
```

**_Methods_**
```
public override void CalculatePay()
public override string ToString()
```

## The Admin : Staff Class

The next class is the `Admin` class which is also derived from the `Staff` class.

### Fields

The `Admin` class has two `private` `const` fields: `overtimeRate` and `adminHourlyRate`. Both fields are of `float` type. Try declaring these two fields and initializing them with the values 15.5 and 30 respectively.

### Property

Next, try declaring a `public` auto-implemented property, `Overtime`.

`Overtime` is of `float` type and has a `private` setter.

### Constructor

Now, let’s declare the constructor. Similar to the constructor of the `Manager` class, the constructor of the `Admin` class is `public` and has one `string` parameter, `name`. Its job is to simply call the base constructor and pass the parameter `name` and the field `adminHourlyRate` to the base constructor.

### Method

Finally, we are ready to code the `CalculatePay()` method for the `Admin` class. The `CalculatePay()` method in the `Admin` class is very similar to the method in the `Manager` class. Let’s first declare the method.

Next, within the curly braces, we use the `CalculatePay()` method of the base class to set the `BasicPay` and `TotalPay` properties of an admin staff.

After setting the values of these two properties, we check if `HoursWorked` is greater than 160. If it is, we’ll update the value of the `TotalPay` property.

Suppose an admin staff is paid an overtime pay on top of the basic pay if he/she worked more than 160 hours. Try using an `if` statement to update the `TotalPay` property of an admin staff.

The overtime pay is calculated with the following formula
```
Overtime = overtimeRate * (HoursWorked - 160);
```
where `overtimeRate` is a `private` field in the `Admin` class and `Overtime` is a property in the same class. `HoursWorked` is a property inherited from the `Staff` class.

Now, go on to code the `ToString()` method. With that, the `Admin` class is complete. The table below shows a summary of the class.

**_Fields_**
```
private const float overtimeRate
private const float adminHourlyRate
```

**_Properties_**
```
public float Overtime
```

**_Constructor_**
```
public Admin(string name) : base(name, adminHourlyRate)
```

**_Methods_**
```
public override void CalculatePay()
public override string ToString()
```

## The FileReader Class

Now, we are ready to code the `FileReader` class. The `FileReader` class is relatively straightforward.

It consists of one `public` method called `ReadFile()` that has no parameter. The method returns a list of `Staff` objects. The method declaration is as follows:
```
public List<Staff> ReadFile()
{
}
```
The ReadFile() method reads from a .txt file that consists of the names and positions of the staff. The format is:
```
Name of Staff, Position of Staff
```
An example is:
```
Yvonne, Manager
Peter, Manager
John, Admin
Carol, Admin
```
The name of the text file is “staff.txt” and is stored in the same folder as the .exe file. Create this file yourself using Notepad and store it in the CSProject > CSProject > Bin > Debug folder where the .exe file is located.

Now, we can start coding the `ReadFile()` method. We first declare four local variables named `myStaff`, `result`, `path` and `separator` as shown below.
```
List<Staff> myStaff = new List<Staff>();
string[] result = new string[2];
string path = "staff.​txt";
string[] separator = {“, ”};
```
Next, we check if the file “staff.txt” exists using an `if` statement and the `File.Exists()` method. You need to add the directive
```
using System.IO;
```
in order to use the `File.Exists()` method.

If the file exists, we use a `StreamReader` object to read the text file line by line. Each time we read a line, we use the `Split()` method to split the line into two parts and store the result in the `result` array. For instance, when we read the first line, the `Split()` method splits it into two strings “Yvonne” and “Manager”. Hence, `result[0] = “Yvonne”` and `result[1] = “Manager”`.

Based on the value of `result[1]`, we use an `if` statement to create a `Manager` object if the value of `result[1]` is “Manager” or an `Admin` object if the value is “Admin”. We add these objects to the list `myStaff`.

After we finish reading the file, we close the file using the `Close()` method.

If the file does not exist, we display a message to inform users of the error.

Finally, we return the list `myStaff` to the caller after the `if-else` statement.

That’s all there is to the `FileReader` class. We do not need to declare a constructor for this class. We’ll just use the default constructor that C# creates for us automatically. The summary for the `FileReader` class is shown below:

**_Methods_**
```
public List<Staff> ReadFile()
```

## The PaySlip Class

Now, let’s code the `PaySlip` class. This class is slightly different from the other classes we’ve seen so far. In addition to having fields, properties, methods and constructors, the `PaySlip` class also has an `enum` called `MonthsOfYear`.

**_Fields_**

First, let’s declare the fields. The class has two `private` `int` fields named `month` and `year`.

**_Enum_**

Next, we shall declare an `enum` named `MonthsOfYear` inside the `PaySlip` class. `MonthsOfYear` represents the twelve months of the year, where `JAN = 1`, `FEB = 2` etc. You do not need to specify any access modifier for this `enum`. An `enum` declared inside a class is `private` by default.

**_Constructor_**

Now, try adding a constructor to the `PaySlip` class. The constructor is `public` and has two `int` parameters `payMonth` and `payYear`. Inside the constructor, we assign the two parameters to the `private` fields `month` and `year` respectively.

**_Methods_**

Next, let us code the `GeneratePaySlip()` method. This method takes in a list of `Staff` objects and does not return anything. The method declaration is
```
public void GeneratePaySlip(List<Staff> myStaff)
{
}
```
Inside the method, we declare a `string` variable called `path`. Next, still within the `GeneratePaySlip()` method, we use a `foreach` loop to loop through the elements in `myStaff`. This can be done as follows:
```
foreach (Staff f in myStaff)
{
}
```
Everything that follows from here for the `GeneratePaySlip()` method is to be coded within the curly braces of the `foreach` loop.

First, we assign a value to the `path` variable based on the name of the staff.

Recall that the `Staff` class has a property called `NameOfStaff`?

Suppose `NameOfStaff = “Yvonne”`, we want to assign the string “Yvonne.txt” to the `path` variable.

How would you do that? (Hint: You can use `f.NameOfStaff` to access the staff’s name and use the `+` operator to concatenate the “.txt” extension)

After assigning a value to `path`, we want to instantiate a `StreamWriter` object to write to the file at the path specified by the `path` variable, overwriting any existing content on the file so that each pay slip generated does not contain content from the previous month. Let’s call the `StreamWriter` object `sw`.

We can then proceed to use a series of `sw.WriteLine()` statements to generate the pay slip of each employee. 

A typical payslip for a manager looks like this:
```
 1 PAYSLIP FOR DEC 2010
 2 ==========================
 3 Name of Staff: Yvonne
 4 Hours Worked: 1231
 5
 6 Basic Pay: $61,550.00
 7 Allowance: $1,000.00
 8
 9 ==========================
10 Total Pay: $62,550.00
11 ==========================
```
The numbers on the left are added for reference and are not part of the actual pay slip.

A typical payslip for an admin staff looks similar except for line 7. For an admin staff, line 7 will read something like:
```
Overtime Pay: $1,286.50
```
Let us now look at how to generate this payslip.

To write line 1, we need to access the `month` and `year` fields in the class. As `month` is an integer, we need to cast it into a `MonthsOfYear` enum value so that it will be written as `DEC` instead of `12`. The statement below shows how line 1 can be written.
```
sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
```
Line 2 is easy to write. It is simply made up of a series of equal signs (`=`).

To write lines 3 and 4, we need to access the `NameOfStaff` and `HoursWorked` properties in the `Staff` class. The statement below shows how it can be done for line 3.
```
sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
```
Try coding line 4 yourself. 

Next, we use a `sw.WriteLine(“”);` statement to print an empty line.

To write line 6, we need to access the `BasicPay` property in the Staff class. In addition, we also need to use the C specifier to display the `BasicPay` property in currency notation.

Line 7 is harder as we need to determine the runtime type of the current object in the `foreach` loop. If the current instance is a `Manager` object, we access and print the `Allowance` property in the `Manager` class. In order to access the `Allowance` property in the `Manager` class, we need to cast `f` into a `Manager` object by writing
```
((Manager)f).Allowance
```
If the current instance is an `Admin` object, we access and print the `Overtime` property in the `Admin` class.

Line 8 is another empty line and line 9 is made up of a series of equal signs. Line 10 shows the total pay of the current staff, which we can get from the `TotalPay` property of the `Staff` class. Finally, line 11 is another line made up of equal signs.

Last but not least, after generating the pay slip for each staff, we need to close the file using the `sw.Close()` method.

That brings us to the end of the `GeneratePaySlip()` method. Once you have finished coding this method, we can move on to the next method in the `PaySlip` class.

The next method generates a summary of employees who worked less than 10 hours in that month. Let’s call this method `GenerateSummary()`.

Like the `GeneratePaySlip()` method, the `GenerateSummary()` method is `public`, takes in a list of `Staff` objects and does not return any value.

Inside the `GenerateSummary()` method, we use LINQ to select all employees who worked less than 10 hours in that month. We want to know the `NameOfStaff` and `HoursWorked` properties for these employees. In addition, we want to arrange the result in ascending order based on `NameOfStaff`. Try coding this LINQ statement yourself and assigning the result to a var variable called `result`.

Next, let us declare a string variable `path` and assign the string “summary.txt” to it.

Now we are ready to write to “summary.txt”. Declare a `StreamWriter` instance to write to this file. A typical “summary.txt” file looks like this (numbers on the left are added for reference):
```
1 Staff with less than 10 working hours
2
3 Name of Staff: Carol, Hours Worked: 2
4 Name of Staff: Peter, Hours Worked: 6
```
Lines 1 and 2 should be quite easy to code.

To print lines 3 and 4, we need to use a `foreach` loop to loop through each element in the `result` variable obtained from the LINQ statement. Try coding this yourself. 
After displaying the result, you can close the “summary.txt” file using the `Close()` method.

That’s it for our `GenerateSummary()` method.

After coding the `GenerateSummary()` method, we simply need to code the `ToString()` method and our `PaySlip` class is complete. The table below shows a summary of the `PaySlip` class.

**_Fields_**
```
private int month
private int year
```
**_Enum_**
```
enum MonthsOfYear
```
**_Constructor_**
```
public PaySlip(int payMonth, int payYear)
```
**_Methods_**
```
public void GeneratePaySlip(List<Staff> myStaff)
public void GenerateSummary(List<Staff> myStaff)
public override string ToString()
```

## The Program Class

We’ve now come to the most important part of the project – the `Program` class. The `Program` class only has one method – the `Main()` method.

The `Main()` Method

First, let us declare four local variables for the `Main()` method. The first is a list of `Staff` objects. We shall call this list `myStaff`. The next is a `FileReader` object called `fr`. The remaining two are `int` variables. Let’s call them `month` and `year` and initialize them to zero.

Now, we shall use a `while` loop and a `try catch` statement to prompt users to input the year for the payslip. The loop will repeatedly prompt users to enter the year until it gets a valid value.

To do that, we use the `while` loop below:
```
 1 while (year == 0)
 2 {
 3    Console.Write("\nPlease enter the year: ");
 4
 5    try
 6    {
 7       //Code to convert the input to an integer
 8    }
 9    catch (FormatException)
10    {
11       //Code to handle the exception
12    }
13 }
```
Inside the `try` block (Line 7), we read the value that the user entered and try to convert it to an integer. We then assign it to the variable `year`. If it is successful, `year` will no longer be zero and the `while` loop will exit.

If the conversion is not successful, we catch the error in the `catch` block to prevent the program from crashing. Try coding an error message in the `catch` block (Line 11). When conversion is unsuccessful, `year` remains as zero and the `while` loop continues. Users will be repeatedly prompted to enter the year until they enter a valid value.

Once you are done with this `while` block, you can move on to code the `while` block to prompt users to enter the month. The `while` block for the `month` variable is very similar to the one for the `year` variable. However, we want to do more checks for the `month` variable.

In the `try` block, we first try to convert the input to an integer and assign it to the `month` variable. If it is successful, we use an if statement to check if month is less than 1 or greater than 12. If it is, the input is invalid. We’ll display an error message to inform users that they have entered an invalid value. In addition, we’ll also reset `month` to zero so that the `while` loop will repeat itself.

After coding the `try` block, you can proceed to code the `catch` block which simply informs users of the error.

Next, we shall add items to our `myStaff` list. We do that by using the `fr` object to call the `ReadFile()` method in the `FileReader` class and assigning the result to `myStaff`.

We can then start to calculate the pay for each staff. We’ll use the following `for` loop for this.
```
for (int i = 0; i < myStaff.Count; i++)
{
   try
   {
   }
   catch (Exception e)
   {
   }
}
```
Within the `for` loop, we use a `try` `catch` statement. In the `try` block, we do the following:

First, prompt the user to enter the number of hours worked for each staff. An example of a prompt is 
```
Enter hours worked for Yvonne:
```
where “Yvonne” is the name of the staff. You need to access the `NameOfStaff` property for each staff by writing `myStaff[i].NameOfStaff`.

Next, read the input, try to convert it to an integer and assign it to the `HoursWorked` property of the `Staff` object.

After that, we call the `CalculatePay()` method on the `Staff` object to calculate the pay of that staff.

Finally, we use the `ToString()` method to get information about the `Staff` object and display this information on the screen using the `Console.WriteLine()` method.

Next in the `catch` block, we try to catch any errors that might occur. Within this `catch` block, we simply display an error message and reduce the value of i by one (`i--;`) so that the `for` loop will iterate again for the current `Staff` object instead of moving on to the next element in `myStaff`.

With that, we’ve come to the end of the `for` loop. We are now ready to generate the pay slips for each staff. To do that, we need to first declare and instantiate a `PaySlip` object. Let’s call that object `ps`. We pass in the variables `month` and `year` to the constructor when instantiating the object.

Next, we use the `ps` object to invoke the `GeneratePaySlip()` and `GenerateSummary()` methods and pass in `myStaff` as the argument. Finally, we add a `Console.Read();` statement to prevent the console from closing immediately after the program ends.

If you have successfully coded the `Main()` program, give yourself a pat on the shoulders. You have just coded a complete program in C#! Well done!

If you have problems coding it, keep trying. Feel free to ask!

Once you are done coding the `Main()` method, you are ready to run your program. Excited? Let’s do it!

Click on the “Start” button to run the program and key in the values requested. The pay slips generated can be found in the same folder as the .exe file, which is in the CSProject > CSProject > Bin > Debug folder. Try making errors and keying in alphabetical letters instead of numbers. Play around with the program to see how it works. Does everything work as expected? If it does, great! You have done an excellent job! Try to think of ways to improve the software. For instance, you can include more checks to ensure that users entered the correct values for `year` and `HoursWorked`.

If your code does not work, feel free to ask and try to figure out what went wrong. You’ll learn a lot by analysing your mistakes. Problem solving is where the fun lies and where the reward is the greatest. Have fun and never give up!