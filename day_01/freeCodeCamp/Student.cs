using System;


class Student 
{
    public string? name;
    public string? major;
    public double gpa;

    public Student(string aName, string aMajor, double aGpa)
    {
        name = aName;
        major = aMajor;
        gpa = aGpa;
    }

    public bool HasHorors()
    {
        if (gpa >= 3) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}