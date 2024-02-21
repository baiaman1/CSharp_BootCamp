using System;

public class Book
{
    public string? name;
    public string? author;
    public int pages; 
    public int count = 0;

    public Book() 
    {
        System.Console.WriteLine("Without agrs!");
    }
    public Book(string name, string author, int pages) 
    {
        this.name = name;
        this.author = author;
        this.pages = pages;
        System.Console.WriteLine("With agrs!");
    }
}