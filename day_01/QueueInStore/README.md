# Day 01 – .NET Boot camp
### Make it classy
##  Rules of the Day

- Do not use any nuget packages.
- The name of the solution and the project (and its separate catalog) is d_{xx}, where xx are the digits of the current day.
- Use console application created based on a standard .NET SDK template.
- Each class should be in a separate file.
- Use **top-level-statements**  and **var**.
- To format the output data, use the en-GB **culture**: N2 for the output of monetary amounts, d for dates.

## What's new

- Classes, properties, methods
- Class constructors
- Lambda operators
- Overriding methods
- Encapsulation
- Static classes
- Extension methods


## Exercise 00 – Storage

Let's start with the heart of the store. Create a _Storage_ class and describe its **properties**. The main thing for us is that the storage is determined by the integer number of goods (let's agree, the same) that are stored in it.

The number of goods may vary, but at the time of the creation of the storage, it is determined by its capacity - the initial value. Let the number of goods be specified in the **class constructor**. The storage cannot be created without capacity, so it should not have a **parameterless constructor**.

Add the _IsEmpty_ method to the class, which will return information about the goods that are out of stock. Use a [lambda operator](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator>).

## Exercise 01 – Customers

What about the customers? Create the _Customer_ class and describe its **properties**. Make it so that one customer can be distinguished from another: let them have a name and a serial number under which they entered the store. Since classes inherit from **the Object type** and get access to its methods, [override the ToString()](<https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring?view=net-5.0>) method so that it returns string information with the customer’s number and name.
```
Andrew, customer #1
```

The number and name are not changing. Make these **auto-properties** locked for editing from the outside and set only from the class constructor. The customer cannot be created without them, so it should not have a **parameterless constructor**.

Try creating two customers with the same names and numbers:
```
var customer1 = new Customer("Andrew", 1);
var customer2 = new Customer("Andrew", 1);
```

Output the value of the expression _customer1 == customer2_ to the console. Why is the answer like this? 

Change the _Customer_ class so that output to the console is true.

## Exercise 02 – Shopping cart

Take the _Customer_ class from the previous exercise, let's add it a property that reflects the number of goods in its cart. When a customer is created (in the real world when they appear in the store), they have zero goods.

To prevent users of your classes from changing the value as they like, make the field with the number of goods not changeable from the outside. 

Instead, add the _FillCart_ cart filling method to the customer: let the method take the maximum cart capacity (input argument) and fill the customer's number of goods with a random number (minimum 1, maximum cart capacity).

This is how we implemented the logic of filling the cart in one place and closed it with a convenient method with a readable and understandable name. Welcome to **encapsulation**.

Create 3 users, fill their carts with a capacity of 15 items. Output information about the user and the number of goods in their cart to the console.

Example:
```
Andrew, customer #1 (5 items in cart)
```

## Exercise 03 – Cash register

Create the _CashRegister_ class and describe its properties. Let the cash register have a "name” - some kind of a title that will allow customers to clearly understand which cash register they are talking about. **Override the methods** of the class so that ToString() returns the title and two cash registers with the same heading are equal.
```
Register #1
```

The cash register should not have a parameterless constructor. 
There should also be no queues at the checkout. But we live in the real world and we want to build a model for the real world, so let's implement queues. 

Add the _Customers_ collection to the _CashRegister_ class so that it is a [«first - come, first - served»](<https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-5.0>) type of a queue. 

Think about whether it is necessary to encapsulate this property?

## Exercise 04 – Store

Create the _Store_ class and describe its properties. The store should have a storage and a set of cash registers. 

Implement the class constructor so that it accepts an integer storage capacity and an integer number of cash registers at the input. Fill in the class properties in the constructor using these inputs. Let each cash register be created with a title corresponding to its serial number.

Think about whether it makes sense to lock the **setter** of a cash registers collection from editing?

Add the _IsOpen_ method, that returns true, if there are still goods in the storage.

## Exercise 05 – Queues 

How do you stand in a queue? To the checkout with the least number of customers or to the checkout with the least number of purchases? Let’s implement both situations.

Create a **static** _CustomerExtensions_ class with two **extension methods** for the _Customer_ object: both methods will accept a collection of cash registers (_CashRegister_ objects) and return the register that the customer chooses. The first method is the cash register with the least number of customers, the second one with the least number of goods among all customers in the queue of this cash register.

Don't forget to name the methods so that it is clear what exactly they do. Now you have a separate class responsible for queue picking (we separated the responsibility) and a nice clean way to call these methods in code. Try them.

## Exercise 06 – So how does it work?

Create a store with 3 cash registers and a storage with 40 goods in it. Create 10 different customers. Implement a cycle: let each of the customers fill the cart and stand in queue. The cycle should work while the store is open (you have a method to check it) and there are customers in it. 

Keep in mind that filling the customer's cart with goods should remove them from the storage. Implement it yourself. Customers leave a queue after they get their items from storage.  Customers can’t have more than items left in the storage (storage cannot have less than 0 items). If storage is empty and customer’s cart still has some items to buy output to the console:
```
Andrew, Customer #4 (2 items left in cart)
```

Do this for two different cases of queue selection (exercise 05) and in each case, output the user's name and number, the number of goods, the chosen checkout and the number of people at the checkout, the number of goods in the queue carts to the console in a loop.
```
Andrew, Customer #4 (6 items in cart) - Register #1 (4 people with 20 items behind)
```

The capacity of the cart is 7 items.

![How does it really work](<https://imgs.xkcd.com/comics/efficiency.png>)

[xkcd](<https://xkcd.com/1445/>)
