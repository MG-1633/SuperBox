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
            string text =  "|" + comanda.IdComanda + "#" + comanda.From + "!" + comanda.To + "$" + comanda.UserX.Uuid + "&" + comanda.IsUrgent + "*" + comanda.InPregress + "/";
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Comanda a fost salvata cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }
        
    }
    
    public async Task SaveMyDeliverysId(string fileName, string idComanda )
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);
        try
        {
            string text = idComanda + "|";
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Id a fost salvata cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }
        
    }

    public async Task<String[]> ReadMyDeliveryId(string fileName)
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                string readedText = File.ReadAllText(filePath);
                return readedText.Split('|');
            }

        }catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la citire. IdComanda: {ex.Message}");
            throw;
        }
        return null;

    }



    public async Task<Comanda> ReadDeliveryById(string fileName, string idComanda , User user)
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
                string ReadedUuid = "";

                bool ReadedIsUrgent = false;
                string readedIsUrgent = "";
                bool ReadedInPregress = false; 
                string readedInPregress = "";




                int j = 0;
                for (int i = 0; i < lenght; i++)
                {
                    
                     ReadedIdComanda = "";
                     ReadedFrom = "";
                     ReadedTo = "";
                    
                    if (readedText[i] == '|')
                    {
                        j = i;
                        ReadedIdComanda = "";
                        j++;
                        while (readedText[j] != '#')
                        {
                            ReadedIdComanda = ReadedIdComanda + readedText[j];
                            j++;

                        }
                        
                        Console.WriteLine(ReadedIdComanda + "xxxx");



                    }
                   
                    if (ReadedIdComanda == idComanda)
                    {                            Console.WriteLine(  "xxxx");

                            
                            
                            j++;
                            while (readedText[j] != '!')
                            {
                                ReadedFrom = ReadedFrom + readedText[j];
                                j++;
                            }
                            Console.WriteLine(ReadedFrom + "xxxx");
                            j++;
                            while (readedText[j] != '$')
                            {
                                ReadedTo = ReadedTo + readedText[j];
                                j++;
                            }
                            j++;
                            while (readedText[j] != '&')
                            {
                                ReadedUuid= ReadedUuid + readedText[j];
                                j++;
                            }

                            j++;
                            while (readedText[j] != '*')
                            {
                                readedIsUrgent = readedIsUrgent + readedText[j];
                                j++;
                            }
                            if (readedIsUrgent == "true")
                                ReadedIsUrgent = true;

                            j++;
                            while (readedText[j] != '/')
                            {
                                readedInPregress = readedInPregress + readedText[j];
                                j++;
                            }
                            if (readedInPregress == "true")
                                ReadedInPregress = true;
                            






                            Comanda comanda = new Comanda(ReadedFrom, ReadedTo, user, ReadedIsUrgent);
                            return comanda;
                            


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
            Console.WriteLine($"A apărut o eroare la citire Comanda prin Id: {ex.Message}");
            throw;
        }
        return null;
    }

    

    
    public async Task SaveTextToFile(string fileName, string uuid, string username, string password,string admin, string phone, string email)
    {
        var folder = FileSystem.AppDataDirectory;
        var filePath = Path.Combine(folder, fileName);
        
        try
        {
            string text =  "|" + username + "#" + password + "!" + uuid + "$" + admin + "&" + phone + "*" + email + "/";
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Fișierul a fost salvat cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }
    }

     
    public async Task<User> ReadTextFromFile(string fileName,string username, string password)
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
                        Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);Console.WriteLine(readedUsername);



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

}


