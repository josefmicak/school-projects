using System.Security.Cryptography;

Calculate();

static void Calculate()
{
    string lines = "";
    string hash_previous = "-";
    string[] difficultyArray = new string[] { "00", "000", "0000", "00000", "000000"};

    for(int i = 0; i < difficultyArray.Length; i++)
    {
        Random random = new Random();
        int data_raw = random.Next(0, 10000000);
        string data;

        using (var md5 = MD5.Create())
        {
            data = String.Concat(md5.ComputeHash(BitConverter
              .GetBytes(data_raw))
              .Select(x => x.ToString("x2")));
        }

        int nonce = 0;
        while (true)
        {
            string block = hash_previous + data + nonce;
            string hash_block = CreateMD5(block);

            int amountOfNullChars = difficultyArray[i].Length;
            string firstNChars = hash_block.Substring(0, amountOfNullChars);

            if (firstNChars == difficultyArray[i])
            {
                lines += "Výška bloku: " + i + "\n";
                lines += "Hash bloku: " + hash_block + "\n";
                lines += "Hash předchozího: " + hash_previous + "\n";
                lines += "Data: " + data + "\n";
                lines += "Data RAW: " + data_raw + "\n";
                lines += "Nonce: " + nonce + "\n";
                lines += "Obtížnost: " + amountOfNullChars + "\n";
                lines += "\n";
                hash_previous = hash_block;
                break;
            }
            else
            {
                nonce++;
            }
        }
    }

    File.WriteAllText("Blockchain.txt", lines);
}

static string CreateMD5(string input)
{
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}