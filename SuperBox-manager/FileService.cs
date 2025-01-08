using System;
using System.IO;
using System.Threading.Tasks;

namespace SuperBox_manager;

public class FileService
{
   
    public async Task SaveTextToFile(string fileName, string uuid, string username, string password,string admin, string phone, string email)
    {
        // Obținem directorul de stocare al aplicației
        var folder = FileSystem.AppDataDirectory;
        
        // Creăm calea completă a fișierului
        var filePath = Path.Combine(folder, fileName);
        
        try
        {
            // Scriem textul în fișier
            string text = "!" + uuid + "@" + username + "#" + password + "$" + admin + "&" + phone + "*" + email;
            await File.AppendAllTextAsync(filePath, text);
            Console.WriteLine($"Fișierul a fost salvat cu succes: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A apărut o eroare la salvare: {ex.Message}");
            throw;
        }
    }

    
    public async Task<string> ReadTextFromFile(string fileName,string username, string password)
    {
        // Obținem directorul de stocare al aplicației
        var folder = FileSystem.AppDataDirectory;
        string readedUsername = "";
        string readedPassword = "";
        // Creăm calea completă a fișierului
        var filePath = Path.Combine(folder, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                // Citim textul din fișier
                string readedText = File.ReadAllText(filePath);
                int lenght = readedText.Length;
                
                
                for (int i = 0; i < lenght; i++)
                {
                    if (readedText[i] == '@')
                    {
                        int j = i;
                        readedUsername = "";
                        j++;
                        while (readedText[j] != '#')
                        {
                            readedUsername = readedUsername + readedText[j];
                            Console.WriteLine("aici s a dat crucea");
                            j++;

                        }
                        
                        Console.WriteLine(readedUsername);
                        



                    }
                    if (readedText[i] == '#')
                    {
                        int j = i;
                        readedPassword = "";
                        j++;
                        while (readedText[j] != '$')
                        {
                            readedPassword = readedPassword + readedText[j];
                            j++;
                        }

                        if (readedUsername == username && readedPassword == password)
                        {
                            return "true";
                        }
                    }
                }
                //return await File.ReadAllTextAsync(filePath);
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
        Console.WriteLine("aici s a dat crucea");
        return "false";

        
    }
    public async Task<bool> UserExistsInFile(string fileName, string username)
    {
        try
        {
            // Citim conținutul fișierului
            if (File.Exists(fileName))
            {
                string[] lines = await File.ReadAllLinesAsync(fileName);

                // Verificăm dacă există un utilizator cu același nume
                foreach (string line in lines)
                {
                    // Presupunem formatul: uuid,username,password,admin,email,phone
                    string[] parts = line.Split(',');
                    if (parts.Length > 1 && parts[1] == username)
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception)
        {
            // Gestionăm erorile (opțional, logare)
        }

        return false; // Utilizatorul nu există
    }
}