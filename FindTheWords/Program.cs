using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class MostRepeatedWord
{
    public static void Main()
    {
        String line;
        var words = new Dictionary<string,int >(); //делаем словарь
        //откроем файл  
        StreamReader file = new StreamReader(@"C:\CFiles\Text2.txt");

        //читаем строки 
        while ((line = file.ReadLine()) != null)
            // тут преобразуем все буковки в строчные, и игнорим разделители типа точек запятых и прочей лабуды
        {
            String[] string1 = line.ToLower().Split(new String[] { ",", ".", " ", "-"}, StringSplitOptions.RemoveEmptyEntries);
            //добавляем слова

            foreach (String s in string1)
            {
                if (words.ContainsKey(s))
                    words[s]++;
                else 
                    words[s] = 0;
            }
        }
        
        var result = words.OrderByDescending(x => x.Value).Take(10).Select(s => s.Key).ToList();// сортировка словаря по убыванию, запихнули в лист


        Console.WriteLine("самые повторяемые слова: ");
        Console.WriteLine(String.Join("\n", result));
   

        
        file.Close();
    }
    
}