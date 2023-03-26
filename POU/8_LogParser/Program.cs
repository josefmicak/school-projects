using Syncfusion.XlsIO;
using System.Text.RegularExpressions;
using System.Linq;

string workspace = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));

if(!File.Exists(workspace + "\\Users.csv"))
{
    SaveAsCsv();
}

List<(int row, string ID, string jmeno, string prijmeni, string vek, string web, string mail, string telefon)> usersList = new List<(int row, string ID, string jmeno, string prijmeni, string vek, string web, string mail, string telefon)>();
List<(int row, string ID, string userID, string time, string data, string hash)> dataList= new List<(int row, string ID, string userID, string time, string data, string hash)>();

List<string> userIdList = new List<string>();
List<string> userIdErrorList = new List<string>();

LoadUsers();

LoadData();

CreateLogFile();

void SaveAsCsv()
{
    using (ExcelEngine excelEngine = new ExcelEngine())
    {
        IApplication application = excelEngine.Excel;
        
        FileStream fileStream = new FileStream(workspace + "\\Users.xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(fileStream);

        IWorksheet worksheet = workbook.Worksheets[0];
        using (FileStream fileStream2 = File.Create(workspace + "\\Users.csv"))
        {
            worksheet.SaveAs(fileStream2, ",");
        }
    }
}

void LoadUsers()
{
    using (var reader = new StreamReader(workspace + "\\Users.csv"))
    {
        int row = 0;
        while (!reader.EndOfStream)
        {
            row++;
            var line = reader.ReadLine();
            var values = line.Split(',');
            if(values.Length == 1)
            {
                break;
            }
            if(values[0] == "ID")
            {
                continue;
            }
            usersList.Add((row, values[0], values[1], values[2], values[3], values[4], values[5], values[6]));
            userIdList.Add(values[0]);
        }
    }

    for(int i = 0; i < usersList.Count; i++)
    {
        string[] splitTelefonByQuotationMark = usersList[i].telefon.Split("\"");
        if(splitTelefonByQuotationMark.Length > 1)
        {
            usersList[i] = (usersList[i].row, usersList[i].ID, usersList[i].jmeno, usersList[i].prijmeni, usersList[i].vek, usersList[i].web, usersList[i].mail, splitTelefonByQuotationMark[1]);
        }
    }
}

void LoadData()
{
    string[] dataLines = File.ReadAllLines(workspace + "\\Data.txt");
    for(int i = 0; i < dataLines.Length; i++)
    {
        string[] splitDataLineBySpace = dataLines[i].Split("  ");
        if(splitDataLineBySpace.Length < 5)
        {
            dataList.Add((i + 1, "Not enough arguments provided", "Not enough arguments provided", "Not enough arguments provided", "Not enough arguments provided", "Not enough arguments provided"));
        }
        else
        {
            dataList.Add((i + 1, splitDataLineBySpace[0], splitDataLineBySpace[1], splitDataLineBySpace[2].Substring(1, splitDataLineBySpace[2].Length - 2), splitDataLineBySpace[3], splitDataLineBySpace[4]));
        }
    }
}

void CreateLogFile()
{
    string logFileContent = "Application launched at " + DateTime.Now + "\n";
    string errorLogFileContent = "";

    logFileContent += "Users.xlsx log (" + usersList.Count + " entries found)" + "\n";
    errorLogFileContent += "Users.xlsx error log\n";
    for (int i = 0; i < usersList.Count; i++)
    {
        bool isIdNumber = int.TryParse(usersList[i].ID, out _);
        if(!isIdNumber)
        {
            logFileContent += "<" + DateTime.Now + "> Error: ID <" + usersList[i].ID + "> is not a number." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: ID <" + usersList[i].ID + "> is not a number." + " (row: " + usersList[i].row + ")\n";
        }

        bool isNameCzech = Regex.IsMatch(usersList[i].jmeno, "^[a-zA-ZáčďéěíňóřšťůúýžÁČĎÉĚÍŇÓŘŠŤŮÚÝŽ\\s]*$");
        if(!isNameCzech)
        {
            logFileContent += "<" + DateTime.Now + "> Error: Name <" + usersList[i].jmeno + "> includes non-Czech characters." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Name <" + usersList[i].jmeno + "> includes non-Czech characters." + " (row: " + usersList[i].row + ")\n";
        }

        bool isSurnameCzech = Regex.IsMatch(usersList[i].prijmeni, "^[a-zA-ZáčďéěíňóřšťůúýžÁČĎÉĚÍŇÓŘŠŤŮÚÝŽ\\s]*$");
        if (!isSurnameCzech)
        {
            logFileContent += "<" + DateTime.Now + "> Error: Surname <" + usersList[i].prijmeni + "> includes non-Czech characters." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Surname <" + usersList[i].prijmeni + "> includes non-Czech characters." + " (row: " + usersList[i].row + ")\n";
        }

        bool isAgeNumber = int.TryParse(usersList[i].vek, out _);
        if (!isAgeNumber)
        {
            logFileContent += "<" + DateTime.Now + "> Error: Age <" + usersList[i].vek + "> is not a number." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Age <" + usersList[i].vek + "> is not a number." + " (row: " + usersList[i].row + ")\n";
        }

        bool isEmailValid = Regex.IsMatch(usersList[i].mail, "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        if (!isEmailValid)
        {
            logFileContent += "<" + DateTime.Now + "> Error: Mail address <" + usersList[i].mail + "> format is not valid." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Mail address <" + usersList[i].mail + "> format is not valid." + " (row: " + usersList[i].row + ")\n";
        }

        bool isPhoneNumber = usersList[i].telefon.All(char.IsDigit);
        if(usersList[i].telefon.Length == 0 || !isPhoneNumber)
        {
            logFileContent += "<" + DateTime.Now + "> Error: Phone <" + usersList[i].telefon + "> is not a number." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Phone <" + usersList[i].telefon + "> is not a number." + " (row: " + usersList[i].row + ")\n";
        }

        bool isPhoneNineCharsLong = true;
        if (usersList[i].telefon.Length != 9)
        {
            isPhoneNineCharsLong = false;
            logFileContent += "<" + DateTime.Now + "> Error: Phone <" + usersList[i].telefon + "> does not have 9 characters." + " (row: " + usersList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Phone <" + usersList[i].telefon + "> does not have 9 characters." + " (row: " + usersList[i].row + ")\n";
        }

        if (isIdNumber && isNameCzech && isSurnameCzech && isAgeNumber && isEmailValid && isPhoneNumber && isPhoneNineCharsLong)
        {
            logFileContent += "{<" + DateTime.Now + "> <" + usersList[i].ID + "> <" + usersList[i].row + ">}" + "\n";
        }
        else
        {
            userIdErrorList.Add(usersList[i].ID);
        }
    }

    logFileContent += "\nData.txt log (" + dataList.Count + " entries found)" + "\n";
    errorLogFileContent += "\nData.txt error log\n";
    for (int i = 0; i < dataList.Count; i++)
    {
        if(dataList[i].ID == "Not enough arguments provided")
        {
            logFileContent += "<" + DateTime.Now + "> Error: Not enough arguments provided." + " (row: " + dataList[i].row + ")\n";
            errorLogFileContent += "<" + DateTime.Now + "> Error: Not enough arguments provided." + " (row: " + dataList[i].row + ")\n";
        }
        else
        {
            bool isIdNumber = int.TryParse(dataList[i].ID, out _);
            if (!isIdNumber)
            {
                logFileContent += "<" + DateTime.Now + "> Error: ID <" + dataList[i].ID + "> is not a number." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: ID <" + dataList[i].ID + "> is not a number." + " (row: " + dataList[i].row + ")\n";
            }

            bool isUserIdNumber = int.TryParse(dataList[i].userID, out _);
            if (!isUserIdNumber)
            {
                logFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> is not a number." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> is not a number." + " (row: " + dataList[i].row + ")\n";
            }

            bool userIdExists = true;
            if(!userIdList.Contains(dataList[i].userID))
            {
                userIdExists = false;
                logFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> doesn't exist in the Users.xlsx file." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> doesn't exist in the Users.xlsx file." + " (row: " + dataList[i].row + ")\n";
            }

            bool userIdNoError = true;
            if (userIdErrorList.Contains(dataList[i].userID))
            {
                userIdNoError = false;
                logFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> exists in the Users.xlsx file, but there is an error with this user." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: UserID <" + dataList[i].userID + "> exists in the Users.xlsx file, but there is an error with this user." + " (row: " + dataList[i].row + ")\n";
            }

            DateTime dateTime;
            bool isTimeValid = DateTime.TryParse(dataList[i].time, out dateTime);
            if (!isTimeValid)
            {
                logFileContent += "<" + DateTime.Now + "> Error: Time <" + dataList[i].time + "> format is not valid." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: Time <" + dataList[i].time + "> format is not valid." + " (row: " + dataList[i].row + ")\n";
            }

            bool isTimeInCurrentYear = true;
            if (isTimeValid)
            {
                if(dateTime.Year != 2022)
                {
                    isTimeInCurrentYear = false;
                    logFileContent += "<" + DateTime.Now + "> Error: Time <" + dataList[i].time + "> has invalid year (" + dateTime.Year + "). (row: " + dataList[i].row + ")\n";
                    errorLogFileContent += "<" + DateTime.Now + "> Error: Time <" + dataList[i].time + "> has invalid year (" +dateTime.Year + "). (row: " + dataList[i].row + ")\n";
                }
            }

            bool isDataContentValid = Regex.IsMatch(dataList[i].data, "^[a-fA-F0-5+-]*$");
            if (!isDataContentValid)
            {
                logFileContent += "<" + DateTime.Now + "> Error: Data <" + dataList[i].data + "> contains forbidden characters." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: Data <" + dataList[i].data + "> contains forbidden characters." + " (row: " + dataList[i].row + ")\n";
            }

            bool isDataLengthValid = true;
            if (dataList[i].data.Length < 20 || dataList[i].data.Length > 50)
            {
                isDataLengthValid = false;
                logFileContent += "<" + DateTime.Now + "> Error: Data <" + dataList[i].data + "> length (" + dataList[i].data.Length + ") is not valid." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: Data <" + dataList[i].data + "> length (" + dataList[i].data.Length + ") is not valid." + " (row: " + dataList[i].row + ")\n";
            }

            bool isHashCorrect = true;
            if (dataList[i].hash != CreateMD5(dataList[i].data))
            {
                isHashCorrect = false;
                logFileContent += "<" + DateTime.Now + "> Error: Hash <" + dataList[i].hash + "> is not correct." + " (row: " + dataList[i].row + ")\n";
                errorLogFileContent += "<" + DateTime.Now + "> Error: Hash <" + dataList[i].hash + "> is not correct." + " (row: " + dataList[i].row + ")\n";
            }

            if (isIdNumber && isUserIdNumber && userIdExists && userIdNoError && isTimeValid && isTimeInCurrentYear && isDataContentValid && isDataLengthValid && isHashCorrect)
            {
                logFileContent += "{<" + DateTime.Now + "> <" + dataList[i].ID + "> <" + dataList[i].row + ">}" + "\n";
            }
        }
    }

    File.WriteAllText(workspace + "\\LogFile.txt", logFileContent);
    File.WriteAllText(workspace + "\\ErrorsLogFile.txt", errorLogFileContent);
}

string CreateMD5(string input)
{
    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes); 
    }
}