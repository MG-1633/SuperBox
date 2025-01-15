using System;
using System.IO;
using System.Threading.Tasks;

namespace SuperBox_manager;

public class FileService
{

    public async Task SaveDelivery(string fileName, Comanda comanda)
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);
        try
        {
            string text = "|" + comanda.IdComanda + "#" + comanda.From + "!" + comanda.To + "$" +
                          comanda.UserX.Username + "&" + comanda.IsUrgent + "*" + comanda.Reciver + ")" +
                          comanda.Sender + "(" + comanda.InPregress + "/";
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Comanda a fost salvata cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }

    }

    public async Task<List<Comanda>> ReadDelivery(string fileName, User user)
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);


        try
        {
            if (File.Exists(filePath))
            {
                string readedText = File.ReadAllText(filePath);
                int lenght = readedText.Length;

                string ReadedIdComanda = "";
                string ReadedFrom = "";
                string ReadedTo = "";
                string ReadedUsername = "";

                bool ReadedIsUrgent = false;
                string readedIsUrgent = "";
                bool ReadedInPregress = false;
                string readedInPregress = "";
                string readedReciver = "";
                string readedSender = "";
                List<Comanda> comenzi = new List<Comanda>();


                int j = 0;
                for (int i = 0; i < lenght; i++)
                {



                    if (readedText[i] == '|')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '#')
                        {
                            ReadedIdComanda = ReadedIdComanda + readedText[j];
                            j++;

                        }

                        Console.WriteLine(ReadedIdComanda + "xxxx");

                    }

                    if (readedText[i] == '#')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '!')
                        {
                            ReadedFrom = ReadedFrom + readedText[j];
                            j++;

                        }

                    }

                    Console.WriteLine(ReadedIdComanda + "xxxx");
                    if (readedText[i] == '!')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '$')
                        {
                            ReadedTo = ReadedTo + readedText[j];
                            j++;

                        }

                    }

                    Console.WriteLine(ReadedTo + "xxxxxxxxxxxxxxxxxxxx");
                    if (readedText[i] == '$')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '&')
                        {
                            ReadedUsername = ReadedUsername + readedText[j];
                            j++;

                        }

                    }

                    Console.WriteLine(ReadedIdComanda + "xxxx");
                    if (readedText[i] == '&')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '*')
                        {
                            readedIsUrgent = readedIsUrgent + readedText[j];
                            j++;

                        }

                    }



                    if (readedText[i] == '&')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != ')')
                        {
                            readedReciver = readedReciver + readedText[j];
                            j++;

                        }

                    }

                    Console.WriteLine(ReadedIdComanda + "xxxx");



                    if (readedText[i] == ')')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '(')
                        {
                            readedSender = readedSender + readedText[j];
                            j++;

                        }

                    }

                    Console.WriteLine(ReadedIdComanda + "xxxx");


                    if (readedText[i] == '(')
                    {
                        j = i;

                        j++;
                        while (readedText[j] != '/')
                        {
                            readedInPregress = readedInPregress + readedText[j];
                            j++;

                        }

                        if (readedInPregress == "true")
                            ReadedInPregress = true;

                        if (readedIsUrgent == "true")
                            ReadedIsUrgent = true;
                        Comanda comanda = new Comanda(ReadedFrom, ReadedTo, user, ReadedIsUrgent, readedReciver,
                            readedSender);
                        comenzi.Add(comanda);
                        ReadedIdComanda = "";
                        ReadedFrom = "";
                        ReadedTo = "";
                        ReadedUsername = "";
                        readedInPregress = "";
                        readedSender = "";
                        readedReciver = "*";
                        readedIsUrgent = "";
                        
                    }

                }

                return comenzi;

            }
            else
            {
                Console.WriteLine($"Fișierul nu există: {filePath}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la citire Comanda prin Id: {ex.Message}");
            throw;
        }

        return null;
    }




    public async Task SaveUser(string fileName, string uuid, string username, string password, string admin,
        string phone, string email)
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);

        try
        {
            string text = "|" + username + "#" + password + "!" + uuid + "$" + admin + "&" + phone + "*" + email + "/";
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Fișierul a fost salvat cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }
    }


    public async Task<User> ReadTextFromFile(string fileName, string username, string password)
    {
        // Obținem directorul de stocare al aplicației
        var folder = FileSystem.AppDataDirectory;
        string readedUsername = "";
        string readedPassword = "";
        string readedUuid = "";
        string readedAdmin = "";
        string readedPhone = "";
        string readedEmail = "";
        // Creăm calea completă a fișierului
        var filePath = Path.Combine(folder, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                string readedText = File.ReadAllText(filePath);
                int lenght = readedText.Length;


                for (int i = 0; i < lenght; i++)
                {
                    if (readedText[i] == '|')
                    {
                        int j = i;
                        readedUsername = "";
                        j++;
                        while (readedText[j] != '#')
                        {
                            readedUsername = readedUsername + readedText[j];
                            j++;

                        }

                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);
                        Console.WriteLine(readedUsername);



                    }

                    if (readedText[i] == '#')
                    {
                        int j = i;
                        readedPassword = "";
                        j++;
                        while (readedText[j] != '!')
                        {
                            readedPassword = readedPassword + readedText[j];
                            j++;
                        }

                        if (readedUsername == username && readedPassword == password)
                        {
                            readedPhone = "";
                            readedEmail = "";
                            readedAdmin = "";
                            readedUuid = "";

                            j++;
                            while (readedText[j] != '$')
                            {
                                readedUuid = readedUuid + readedText[j];
                                j++;
                            }

                            j++;
                            while (readedText[j] != '&')
                            {
                                readedAdmin = readedAdmin + readedText[j];
                                j++;
                            }

                            j++;
                            while (readedText[j] != '*')
                            {
                                readedPhone = readedPhone + readedText[j];
                                j++;
                            }

                            while (readedText[j] != '/')
                            {
                                readedEmail = readedEmail + readedText[j];
                                j++;
                            }








                            User user = new User(readedUsername, readedPassword, readedUuid, readedAdmin, readedEmail,
                                readedPhone);
                            return user;



                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Fișierul nu există: {filePath}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la citire: {ex.Message}");
            throw;
        }

        return null;

    }













    public async Task<bool> UserExistsInFile(string fileName, string username)
        {
            var folder = FileSystem.AppDataDirectory;
            string readedUsername = "";

            // Creăm calea completă a fișierului
            var filePath = Path.Combine(folder, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    string readedText = File.ReadAllText(filePath);
                    int lenght = readedText.Length;


                    for (int i = 0; i < lenght; i++)
                    {
                        if (readedText[i] == '|')
                        {
                            int j = i;
                            readedUsername = "";
                            j++;
                            while (readedText[j] != '#')
                            {
                                readedUsername = readedUsername + readedText[j];
                                j++;


                            }

                            if (readedUsername == username) return true;

                        }
                    }

                    Console.WriteLine(readedUsername);



                    return false; // Utilizatorul nu există


                }


            }
            catch (Exception ex)

            {
                //await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
                Console.WriteLine("aici sa dat crucea");
            }

            return false;

        }

        public async Task SaveSuperBox(string fileName, SuperBox superbox)
        {
            var folder = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(folder, fileName);
            try
            {
                string text = "|" + superbox.Id + "#" + superbox.Location + "/";
                await File.AppendAllTextAsync(filePath, text);
                Console.WriteLine($"SuperBox-ul a fost salvat cu succes: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
                throw;
            }

        }

        public async Task<List<SuperBox>> ReadSuperBox(string fileName)
        {
            var folder = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(folder, fileName);
            try
            {
                if (File.Exists(filePath))
                {
                    string readedText = File.ReadAllText(filePath);
                    int lenght = readedText.Length;
                    List<SuperBox> superboxes = new List<SuperBox>();

                    for (int i = 0; i < lenght; i++)
                    {
                        if (readedText[i] == '|')
                        {
                            string readedId = "";
                            string readedLocation = "";
                            int l = i;
                            l++;
                            while (readedText[l] != '#')
                            {
                                readedId = readedId + readedText[l];
                                l++;
                            }

                            l++;
                            while (readedText[l] != '/')
                            {
                                readedLocation = readedLocation + readedText[l];
                                l++;
                            }

                            SuperBox superbox = new SuperBox(readedId, readedLocation);
                            superboxes.Add(superbox);
                        }
                    }

                    return superboxes;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task SaveMakeMeAdmin(string fileName, User user)
        {
            var folder = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(folder, fileName);
            try
            {
                string text = "|" + user.Username + "|";
                await File.AppendAllTextAsync(filePath, text);
                Console.WriteLine($"SuperBox-ul a fost salvat cu succes: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
                throw;
            }

        }


        public async Task<String[]> ReadMakeMeAdmin(string fileName)
        {
            var folder = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(folder, fileName);
            try
            {
                if (File.Exists(filePath))
                {
                    string readedText = File.ReadAllText(filePath);
                    int lenght = readedText.Length;
                    List<String> list = new List<String>();
                    return readedText.Split('|');
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }












}
