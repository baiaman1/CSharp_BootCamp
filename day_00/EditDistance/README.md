# Working out the bugs

“Never interrupt your enemy when he is making a mistake.”

**― Napoleon Bonaparte**

### What's new

- StreamReader (Read from File)
- Levenshtein distance (minimum number of single-character edits) 
- System.IO


You need to implement a console application that asks for a username:

```
>Enter name:
```

### Output format

Next, the user must enter their name (it can contain only letters, spaces and hyphens), to which the program reacts in the following way.

| Case | Expected output |
|---|---|
| Name was found in the dictionary |Hello, {name}! |
| A close name was found in the dictionary (the editing distance to which is no more than 1) |>Did you mean “{corrected name}”? Y/N |
| Y |Hello, {corrected name}! |
| N |>Did you mean “{new correction option}”? Y/N <br/> or <br/> Your name was not found. |
| No related name was found |Your name was not found. |
| Name not entered  |Your name was not found. |

#### The user specified incorrect data
```
Something went wrong. Check your input and retry.
```

#### Examples of launching an application from the project folder

```
$ dotnet run
>Enter name:
Mrk
>Did you mean “Mark”? Y/N
Y
>Hello, Mark!
```
