using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;


public class Human
{
    public string Name;
    public int Age;
    public string[] MyFavoriteClass;
}

Human Liza = new Human();
Liza.Name = "Лизочка";
Liza.Age = 17;
Liza.MyFavoriteClass = new string[] { "C#", "Пайтон", "Базы данных" };

Human Kristina = new Human();
Kristina.Name = "Кристиночка";
Kristina.Age = 17;
Kristina.MyFavoriteClass = new string[] { "ОБЖ", "Бомбежка компов" };

Human Aisha = new Human();
Aisha.Name = "Аишечка";
Aisha.Age = 17;
Aisha.MyFavoriteClass = new string[] { "С#", "ОБЖ" };

List<Human> humans = new List<Human>();
humans.Add(Liza);
humans.Add(Kristina);
humans.Add(Aisha);

XmlSerializer xml = new XmlSerializer(typeof(Human));
using (FileStream fs = new FileStream("D:\\Рабочий стол\\jopapopa.xml", FileMode.OpenOrCreate))
{ 
    xml.Serialize(fs, Kristina);
}

Human human;

XmlSerializer xml = new XmlSerializer(typeof(Human));
using (FileStream fs = new FileStream("D:\\Рабочий стол\\jopapopa.xml", FileMode.Open))
{ 
    human = (Human)xml.Deserialize(fs);
}

string json = JsonConvert.SerializeObject(humans);
File.WriteAllText("D:\\Рабочий стол\\jopapopa2.json", json);

string text = File.ReadAllText("D:\\Рабочий стол\\jopapopa2.json");
List<Human> result = JsonConvert.DeserializeObject<List<Human>>(text);

