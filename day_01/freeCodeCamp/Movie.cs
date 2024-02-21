class Movie 
{
    public string? title;
    public string? director;
    private string? rating;

    public Movie(string title, string director, string rating)
    {
        this.title = title;
        this.director = director;
        Rating = rating;   
    }

    public string Rating 
    {
        // get 
        // {
        //     return rating;
        // }
        set
        {
            if (value == "PG" || value == "PG-13") 
            {
                rating = value;
            }
            else 
            {
                rating = "NR";
            }
        }
    }

}
