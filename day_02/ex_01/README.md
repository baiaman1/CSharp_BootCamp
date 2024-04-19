### Exercise 01 – Work-life balance

“My point is, life is about balance. The good and the bad. The highs and the lows. The pina and the colada.”

**― Ellen DeGeneres, Seriously... I'm Kidding**

### What's new

- Classes, records
- Enum
- Lists, arrays
- Inheritance
- Polymorphism
- Override
- String interpolation

### Project structure:

```
d02_ex01
      Program.cs
      Tasks/
            Task.cs
            TaskType.cs
            TaskPriority.cs
            TaskState.cs

```

### The objective

You work more long hours. Your family, your cat and your favorite succulent began to forget what you look like. In order to strike balance between work, study and personal life, you decide to create a personal task tracker for yourself. 

Think about what a task is, so we can design our application based on the **domain knowledge**. Task is a goal, a problem to solve. To know the content of a goal, you need to describe it. To find it among others, you need to set a title. To achieve your goals, you need to set deadlines. So, the task should have: *a title*, *a description*, and *a due date*.

In addition, tasks will be much more convenient to navigate, if *a priority (Low, Normal, High)* and *a category (Work, Study, Personal)* can be assigned. This is where **enum** will help us.

The status of the task can change: it is created as a *New* one, after all the work is completed, it becomes *Completed*, in addition, the tasks that no longer make sense to work on, can be marked with the *Irrelevant* status, so you do not return to them again. The task can only be in one status and move between them in a certain order (*Completed* ones cannot become *Irrelevant*): sounds like **a state machine**.

You need to implement a program that allows you to create a task list with the ability to display the list, add a new one, or mark the task as Completed or Irrelevant.
Task properties must be closed for external changes. To change statuses, the task must provide special methods that **encapsulate** the logic of changing the status.

### Method 1. Creating the task

```
> add
> Enter a title
> {title}
> Enter a description
> {summary}
> Enter the deadline
> {dueDate}
> Enter the type
> {type}
> Assign the priority
> {priority}

```

Note: the status of the task is not specified by input. The task should always be created in the *New* status.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | Task title |
|summary | string, not required | Description of what needs to be done|
|dueDate | datetime (nullable), not required | By what date the task is planned to be completed|
|type | enum [Work, Study, Personal], required | Task type |
|priority| enum [Low, Normal, High], not required (default value: Normal)| Task priority |

Pay attention to the required input arguments! If the parameter is required, you need to check it at the input. If it is not required, the corresponding field in the class must be nullable. Remember, string is **a reference type**, and it is **nullable** by default. DateTime and enum are **value types**, and they need to be explicitly specified as nullable.

#### Output format

```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```

#### Response format in case of an empty date

```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}
{task.Summary}
```

#### Sample response

```
- Water the flowers
[Personal] [New]
Priority: High, Due till 11/21/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent!
```
#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

### Method 2. Task List

```
> list
```

To set the format for displaying a task in one place, you can override the ToString() method of the task. If the list is empty, you need to display a message about it.
You don't need to sort the tasks.

#### Output format

```
- {task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```

#### Empty list
```
The task list is still empty.
```

### Sample response

```
- Water the flowers
[Personal] [New]
Priority: Normal, Due till 11/5/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent

- Finish Day 02
[Study] [Done]
Priority: High, Due till 11/21/2021
Finish all the exercises of the day 02 of the .NET piscine, upload everything to the repository.

```

### Method 3. Completing the task

```
> done
> Enter a title
> {title}
```

Here we refer to a specific task by the title, considering it to be a unique identifier for simplicity.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |

#### The task does not exist
```
Input error. The task with this title was not found
```

#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

#### Sample response
```
The task [Water the flowers] is completed!
```
### Method 4. The task is not relevant

```
> wontdo
> Enter a title
> {title}
```

Here we refer to a specific task by the title, considering it to be a unique identifier for simplicity.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |

#### The task does not exist
```
Input error. The task with this title was not found
```

#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

#### Sample response
```
The task [Water the flowers] is no longer relevant!
```

### Exit

The application shuts down if you enter

```
> quit
```

or

```
> q
```
