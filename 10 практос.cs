using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Кафе");
        Console.WriteLine("--------------------------");

        bool isAuthenticated = false;
        string loggedInUser = "";

        while (!isAuthenticated)
        {
            Console.WriteLine("Введите логин: ");
            string username = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();

            isAuthenticated = AuthenticateUser(username, password, out string employeeName);
            loggedInUser = isAuthenticated ? employeeName : username;

            if (!isAuthenticated)
            {
                Console.WriteLine("Неверный логин или пароль. Попробуйте еще раз.");
            }
        }

        Console.WriteLine($"Вы успешно авторизовались как {loggedInUser}");

        string role = GetRoleByUsername(loggedInUser);

        Console.WriteLine("--------------------------");
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Просмотреть информацию о пользователях");
        Console.WriteLine("2. Добавить пользователя");
        Console.WriteLine("3. Изменить информацию о пользователе");
        Console.WriteLine("4. Удалить пользователя");
        Console.WriteLine("5. Поиск по пользователям");
        Console.WriteLine("6. Выйти");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Введите номер действия: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ViewUsers();
                    break;
                case "2":
                    AddUser();
                    break;
                case "3":
                    UpdateUser();
                    break;
                case "4":
                    DeleteUser();
                    break;
                case "5":
                    SearchUsers();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }

        Console.WriteLine("Спасибо за использование Кафе.");
    }

    static bool AuthenticateUser(string username, string password, out string employeeName)
    {
        
        if (username == "admin" && password == "admin")
        {
            employeeName = "";
            return true;
        }
        else if (username == "cashier" && password == "cashier")
        {
            employeeName = "Кассир";
            return true;
        }
        else if (username == "manager" && password == "manager")
        {
            employeeName = "Менеджер персонала";
            return true;
        }
        else if (username == "storemanager" && password == "storemanager")
        {
            employeeName = "Склад-менеджер";
            return true;
        }
        else if (username == "accountant" && password == "accountant")
        {
            employeeName = "Бухгалтер";
            return true;
        }
        else
        {
            employeeName = "";
            return false;
        }
    }

    static string GetRoleByUsername(string username)
    {
       
        {
            case "admin":
                return "Администратор";
            case "cashier":
                return "Кассир";
            case "manager":
                return "Менеджер персонала";
            case "storemanager":
                return "Склад-менеджер";
            case "accountant":
                return "Бухгалтер";
            default:
                return "";
        }
    }

    static void ViewUsers()
    {
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}
public class CafeInformationSystem
{
    private List<User> users;

    public CafeInformationSystem()
    {
        users = new List<User>
        {
            new User { Id = 1, Name = "Иван", Role = "Администратор" },
            new User { Id = 2, Name = "Мария", Role = "Официант" },
            new User { Id = 3, Name = "Петр", Role = "Бухгалтер" }
        };
    }
    public List<User> GetUsers()
    {
        return users;
    }
}

class Program
{
    static void Main()
    {
        CafeInformationSystem cafeSystem = new CafeInformationSystem();
        List<User> users = cafeSystem.GetUsers();
        Console.WriteLine("Список пользователей кафе:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Роль: {user.Role}");
        }
    }
}
    }

    static void AddUser()
    {
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}

public class CafeInformationSystem
{
    private List<User> users;

    public CafeInformationSystem()
    {
        users = new List<User>
        {
            new User { Id = 1, Name = "Иван", Role = "Администратор" },
            new User { Id = 2, Name = "Мария", Role = "Официант" },
            new User { Id = 3, Name = "Петр", Role = "Бухгалтер" }
        };
    }
    public List<User> GetUsers()
    {
        return users;
    }
    public void AddUser(string name, string role)
    {
        int newId = users.Count + 1;
        var newUser = new User { Id = newId, Name = name, Role = role };
        users.Add(newUser);
    }
}

class Program
{
    static void Main()
    {
        CafeInformationSystem cafeSystem = new CafeInformationSystem();
        List<User> users = cafeSystem.GetUsers();

        Console.WriteLine("Список пользователей кафе:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Роль: {user.Role}");
        }
        cafeSystem.AddUser("Елена", "Официант");
        users = cafeSystem.GetUsers();
        Console.WriteLine("\nОбновленный список пользователей кафе:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Роль: {user.Role}");
        }

{
    public string Username { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
List<User> users = new List<User>();

List<User> GetUsers()
{
    return users;
}

{
    List<User> userList = GetUsers();
    Console.WriteLine("Список пользователей:");
    foreach (User user in userList)
    {
        Console.WriteLine($"Логин: {user.Username}, Имя: {user.FullName}, Email: {user.Email}, Телефон: {user.PhoneNumber}");
    }
}
void AddUser(string username, string fullName, string email, string phoneNumber)
{
    User newUser = new User
    {
        Username = username,
        FullName = fullName,
        Email = email,
        PhoneNumber = phoneNumber
    };

    users.Add(newUser);
}
void UpdateUser(string username, string fullName, string email, string phoneNumber)
{
    User userToUpdate = users.Find(user => user.Username == username);

    if (userToUpdate != null)
    {
        userToUpdate.FullName = fullName;
        userToUpdate.Email = email;
        userToUpdate.PhoneNumber = phoneNumber;
        Console.WriteLine("Информация о пользователе успешно обновлена.");
    }
    else
    {
        Console.WriteLine("Пользователь с таким логином не найден.");
    }
}


void DeleteUser(string username)
{
    User userToDelete = users.Find(user => user.Username == username);

    if (userToDelete != null)
    {
        users.Remove(userToDelete);
        Console.WriteLine("Пользователь успешно удален.");
    }
    else
    {
        Console.WriteLine("Пользователь с таким логином не найден.");
    }
}

void SearchUsers(string searchQuery)
{
    List<User> matchingUsers = users.FindAll(user => 
        user.Username.Contains(searchQuery)  
        user.FullName.Contains(searchQuery)  
        user.Email.Contains(searchQuery) || 
        user.PhoneNumber.Contains(searchQuery)
    );

    if (matchingUsers.Count > 0)
    {
        Console.WriteLine("Найденные пользователи:");
        foreach (User user in matchingUsers)
        {
            Console.WriteLine($"Логин: {user.Username}, Имя: {user.FullName}, Email: {user.Email}, Телефон: {user.PhoneNumber}");
        }
    }
    else
    {
        Console.WriteLine("Пользователи не найдены.");
    }
}
