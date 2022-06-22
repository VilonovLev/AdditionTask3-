// Продолжаем прокачивать приложение с командами. Добавить к программе, которая заканчивается, 
// когда пишем exit еще 4 команды (их можно придумать самому). Например: 
// SetName – Установить имя 
// Help – вывести список команд 
// SetPassword – Установить пароль 
// Exit – выход WriteName – вывести имя после ввода пароля

List <User> users = new List<User>();
bool flag = true;
User user = new User();

Console.WriteLine("Добро пожаловать в меню!");
PrintHelp();
while(flag)
{
    Console.WriteLine("---Введите команду!---");
    int pick = Convert.ToInt32(Console.ReadLine());
    switch(pick)
    {
        case 1:
        {
            user = Login(user);
            break;
        }
        case 2:
        {
            NewUser();
            break;
        }
        case 3:
        {
            PrintName(user);
            break;
        }
        case 4:
        {
            PrintHelp();
            break;
        }
        case 5:
        {
            Exit();
            break;
        }
    }
    
}

void PrintName(User user)
{
    Console.WriteLine($"Логин пользователя: {user.GetName()}");
}

bool Exit()
{
    Console.WriteLine("Досвидание!");
    return flag = false;
}

void PrintHelp()
{
    Console.WriteLine("Вам доступны комманды\n" +
                    "1 - Вход в акаунт\n" +
                    "2 – Создание профиля\n" + 
                    "3 – Вывести имя после ввода пароля\n" +
                    "4 – Вывести список команд\n" +
                    "5 – Выход\n");
}

User Login(User u)
{
    
    if (users.Count == 0)
    {
        Console.WriteLine("Нет созданных аккаунтов!");
        return u;
    }
    else
    {
        while(true)
        {
            string inputName = Input("Введите логин:");

            foreach(var user in users)
            {
                if (user.GetName() == inputName)
                {
                    string inputPass = Input("Введите пароль:");
                    if(user.GetPass() == inputPass)
                    {
                        Console.WriteLine($"Добро пожаловать {user.GetName()}!");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неверный пароль!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Пользователь не найден!");
                    break;
                }    
            }
        }
    }
}

void NewUser()
{
    User user = new User();
    user.SetName(Input("Придумайте логин:"));
    user.SetPassword(Input("Придумайте пароль:"));
    users.Add(user);
}

string Input(string str)
{
    Console.WriteLine(str);
    return Console.ReadLine();
}

public class User 
{
    private string name = "Вы не авторизованны!";
    private string password = string.Empty;

    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetPassword(string password)
    {
        this.password = password;
    }
    public void WriteName()
    {
        Console.WriteLine(name);
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetPass()
    {
        return this.password;
    }

}

