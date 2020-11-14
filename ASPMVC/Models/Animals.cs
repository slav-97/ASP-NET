// Программы, игры и их исходные коды
// www.interestprograms.ru

using System.Collections.Generic;

namespace ASPMVC.Models
{
    // Класс модели 
    // Все запросы к базам данных в этом классе
    public class Animals
    {
        // Список с данными животных
        public List<DataAnimals> List = new List<DataAnimals>();

        // Инициализация каталога со списком животных
        public Animals(string dir = null)
        {
            Dogs dogs;
            Cats cats;
            Fish fish;

            switch (dir)
            {
                case "Dogs":
                    dogs = new Dogs(List, "dogs/");
                    break;
                case "Cats":
                    cats = new Cats(List, "cats/");
                    break;
                case "Fish":
                    fish = new Fish(List, "fish/");
                    break;
                default:
                    dogs = new Dogs(List, "dogs/");
                    cats = new Cats(List, "cats/");
                    fish = new Fish(List, "fish/");
                    break;
            }
        }

        // Инициализация данных животного по идентификатору
        public Animals(string dir, string id)
        {
            Dogs dogs;
            Cats cats;
            Fish fish;

            switch (dir)
            {
                case "Dogs":
                    dogs = new Dogs(List, "dogs/", id);
                    break;
                case "Cats":
                    cats = new Cats(List, "cats/", id);
                    break;
                case "Fish":
                    fish = new Fish(List, "fish/", id);
                    break;
                default:
                    //
                    break;
            }
        }
    }



    #region Классы  базы данных

    // Класс базы данных семейства собачьих
    public class Dogs
    {
        // Инициализация полного списка семейства собачьих
        public Dogs(List<DataAnimals> list, string dir)
        {
            DataAnimals da = new DataAnimals("Собака домашняя", dir, "sobaka-dom");
            list.Add(da);

            da = new DataAnimals("Волк", dir, "volk");
            list.Add(da);

            da = new DataAnimals("Лисица", dir, "lisica");
            list.Add(da);

        }

        // Поиск конктретного представителя семейства по идентификатору
        public Dogs(List<DataAnimals> list, string dir, string id)
            : this(list, dir) // предварительная инициализация списка
        {
            // Ищем совпадение идентификатору
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i].Id)
                {
                    DataAnimals da = list[i]; // запоминаем найденное животное

                    list.RemoveAt(i); // удаляем его из списка
                    list.Insert(0, da); // вставляем в начало списка
                    break;
                }
            }
        }
    } // public class Dogs


    // Класс базы данных семейства кошачьих
    // Функциональность аналогична с классом Dogs
    public class Cats
    {
        public Cats(List<DataAnimals> list, string dir)
        {
            DataAnimals da = new DataAnimals("Кошка домашняя", dir, "koshka-dom");
            list.Add(da);

            da = new DataAnimals("Тигр", dir, "tigr");
            list.Add(da);

            da = new DataAnimals("Рысь", dir, "rys");
            list.Add(da);
        }

        public Cats(List<DataAnimals> list, string dir, string id) : this(list, dir)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i].Id)
                {
                    DataAnimals da = list[i];

                    list.RemoveAt(i);
                    list.Insert(0, da);
                    break;
                }
            }
        }
    }// public class Cats


    // Класс базы данных семейства рыб
    // Функциональность аналогична с классом Dogs
    public class Fish
    {
        // Идентификаторы можно создавать и на кириллице
        public Fish(List<DataAnimals> list, string dir)
        {
            DataAnimals da = new DataAnimals("Судак", dir, "судак");
            list.Add(da);

            da = new DataAnimals("Плотва", dir, "плотва");
            list.Add(da);

            da = new DataAnimals("Окунь", dir, "окунь");
            list.Add(da);
        }

        public Fish(List<DataAnimals> list, string dir, string id) : this(list, dir)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i].Id)
                {
                    DataAnimals da = list[i];

                    list.RemoveAt(i);
                    list.Insert(0, da);
                    break;
                }
            }
        }
    }// public class Fish


    // Класс для хранения данных животного
    public class DataAnimals
    {
        public string Id;
        public string Name;
        public string Url;


        public DataAnimals(string name, string url, string id)
        {
            Id = id;
            Name = name;
            Url = url + id;

        }
    }

    #endregion
}