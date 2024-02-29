/* Поэтому давайте выделим общий интерфейс 
IConfigurationSource для реализации различных источников. 
Он будет отвечать за загрузку данных из файла 
и иметь метод, возвращающий набор параметров. */

namespace Day03
{
    public interface IConfigurationSource
    {
        int Priority { get; }
        Dictionary<string, string> LoadParameters();
    }
}
