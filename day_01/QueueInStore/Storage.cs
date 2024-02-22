public class Storage 
{
    public int GoodsInStorage;
     
    public Storage(int capacity) 
    {
        GoodsInStorage = capacity;
    }

    public bool IsEmpty() => GoodsInStorage == 0;

    
}