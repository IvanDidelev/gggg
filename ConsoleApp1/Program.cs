using System;

class Program
{
    static void Main()
    {
        // Исходный алфавит
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        // Сообщения для шифрования
        string message1 = "КРИПТОСТОЙКОСТЬ";
        string message2 = "ГАММИРОВАНИЕ";

        // Ключ
        string key = "ЯБЛОКО";

        // Шифрование
        string encryptedMessage1 = VigenereEncrypt(message1, key, alphabet);
        string encryptedMessage2 = VigenereEncrypt(message2, key, alphabet);

        // Вывод результатов
        Console.WriteLine("Original Message 1: " + message1);
        Console.WriteLine("Encrypted Message 1: " + encryptedMessage1);

        Console.WriteLine("\nOriginal Message 2: " + message2);
        Console.WriteLine("Encrypted Message 2: " + encryptedMessage2);
    }

    static string VigenereEncrypt(string message, string key, string alphabet)
    {
        // Приведение текста и ключа к верхнему регистру
        message = message.ToUpper();
        key = key.ToUpper();

        // Создание таблицы Вижинера
        char[,] vigenereTable = new char[alphabet.Length, alphabet.Length];
        for (int i = 0; i < alphabet.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                vigenereTable[i, j] = alphabet[(i + j) % alphabet.Length];
            }
        }

        // Шифрование
        string encryptedMessage = "";
        int keyIndex = 0;

        foreach (char symbol in message)
        {
            if (alphabet.Contains(symbol))
            {
                int rowIndex = alphabet.IndexOf(key[keyIndex]);
                int columnIndex = alphabet.IndexOf(symbol);
                encryptedMessage += vigenereTable[rowIndex, columnIndex];

                // Увеличение индекса ключа
                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                // Символы, не входящие в алфавит, добавляются без изменений
                encryptedMessage += symbol;
            }
        }

        return encryptedMessage;
    }
}
