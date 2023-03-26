using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(existingImagePathTB.Text))
            {
                MessageBox.Show("Chyba: obrázek neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddTextToImage(textTB.Text, existingImagePathTB.Text, newImageNameTB.Text);
            }
        }

        /// <summary>
        /// Hide text into an existing image
        /// </summary>
        public void AddTextToImage(string text, string existingImagePath, string newImageName)
        {
            string[] imagePixelsArray = GetImagePixelsArray(existingImagePath, null);

            //text we want to hide preceded by a header that contains information about filetype (t = text) and length of the hidden information
            string header = "t" + text.Length + ";";
            string binaryText = StringToBinary(header) + StringToBinary(text);

            bool isPublicImageLargeEnough = true;
            bool userWantsToEnlargeImage = true;
            int maxLength = 0;

            if (binaryText.Length > imagePixelsArray.Length)//check if the image is large enough to contain the text
            {
                isPublicImageLargeEnough = false;
                int headerLength = StringToBinary(header).Length;
                maxLength = (imagePixelsArray.Length - headerLength) / 8;
                string errorMessage = "Chyba: do tohoto obrázku lze zapsat text o velikosti maximálně " + maxLength + " znaků. Délka textu je " + text.Length + " znaků." +
                    "\nChcete tento obrázek zvětšit?";
                var result = MessageBox.Show(errorMessage, "Chyba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    userWantsToEnlargeImage = false;
                }
            }

            var bitmap = new Bitmap(existingImagePath);
            //resize the image in case it's too small and the user wants to resize it
            if (!isPublicImageLargeEnough && userWantsToEnlargeImage)
            {
                //the image is resized in a manner that lets the image keep its original width/height ratio
                double sizeDifference = (bitmap.Width * bitmap.Height) / maxLength;
                int newWidth = bitmap.Width * (int)Math.Ceiling(sizeDifference);
                int newHeight = bitmap.Height * (int)Math.Ceiling(sizeDifference);
                bitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));

                //it's necessary to modify this array too, because for now it holds the pixels of the original (smaller) image
                imagePixelsArray = GetImagePixelsArray(existingImagePath, bitmap);
            }

            if (userWantsToEnlargeImage)
            {
                //add text to array
                int charsWritten = 0;
                for (int i = 0; i < imagePixelsArray.Length; i++)
                {
                    imagePixelsArray[i] = imagePixelsArray[i].Remove(imagePixelsArray[i].Length - 1, 1) + binaryText[charsWritten];
                    charsWritten++;

                    //the word has been written into the array
                    if (charsWritten == binaryText.Length)
                    {
                        break;
                    }
                }

                //create image from pixel array
                int imagePixelsArrayIndex = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int R = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex]);
                        int G = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex + 1]);
                        int B = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex + 2]);
                        Color pixelColor = Color.FromArgb(R, G, B);
                        bitmap.SetPixel(x, y, pixelColor);
                        imagePixelsArrayIndex += 3;
                    }
                }

                //save image
                string path = Path.GetDirectoryName(existingImagePath) + "\\" + newImageName + ".png";
                bitmap.Save(path, ImageFormat.Png);
                MessageBox.Show("Obrázek " + newImageName + ".png úspěšně vytvořen.", "Obrázek vytvořen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Convert an existing image into an array of pixels (in binary form)
        /// </summary>
        public string[] GetImagePixelsArray(string existingImagePath, Bitmap? largerBitmap)
        {
            var bitmap = new Bitmap(existingImagePath);
            if(largerBitmap != null)//this is used only in case the user wants to resize an image that's too small
            {
                bitmap = largerBitmap;
            }
            string[] imagePixelsArray = new string[bitmap.Width * bitmap.Height * 3];
            int imagePixelsArrayIndex = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    imagePixelsArray[imagePixelsArrayIndex] = IntToBinary(pixelColor.R);
                    imagePixelsArrayIndex++;
                    imagePixelsArray[imagePixelsArrayIndex] = IntToBinary(pixelColor.G);
                    imagePixelsArrayIndex++;
                    imagePixelsArray[imagePixelsArrayIndex] = IntToBinary(pixelColor.B);
                    imagePixelsArrayIndex++;
                }
            }

            return imagePixelsArray;
        }

        /// <summary>
        /// Convert an integer into its binary representation
        /// </summary>
        public string IntToBinary(int value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');//asserts that the returned number will always have 8 chars
        }

        /// <summary>
        /// Convert a string into its binary representation
        /// </summary>
        public string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));//asserts that the returned number will always have 8 chars
            }
            return sb.ToString();
        }

        public string ByteToBinary(byte data)
        {
            return Convert.ToString(data, 2).PadLeft(8, '0');
        }

        /// <summary>
        /// Convert a binary representation of an integer back into an integer number
        /// </summary>
        public int BinaryToInt(string data)
        {
            return Convert.ToInt32(data, 2);
        }

        /// <summary>
        /// Convert a binary representation of a string back into a string
        /// </summary>
        public string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public byte BinaryToByte(string data)
        {
            return Convert.ToByte(data, 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //hide all related entities (in case the user for example first gets information in text form from file A and then in image form from file B
            getInfoLabel.Text = "";
            hiddenTextTB.Visible = false;
            label5.Visible = false;
            saveTxtFileLocationTB.Visible = false;
            button3.Visible = false;
            pictureBox1.Visible = false;
            label10.Visible = false;

            if (!File.Exists(existingImagePathTB2.Text))
            {
                MessageBox.Show("Chyba: obrázek neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GetInformationFromImage(existingImagePathTB2.Text);
            }
        }

        /// <summary>
        /// Return either a hidden text or a hidden image from an existing image
        /// </summary>
        public void GetInformationFromImage(string existingImagePath)
        {
            string[] imagePixelsArray = GetImagePixelsArray(existingImagePath, null);//public image

            //we find out whether a text (t), an image (i) or a file (f) has been hidden 
            string fileType = string.Empty;
            for(int i = 0; i < 8; i++)
            {
                fileType += imagePixelsArray[i][imagePixelsArray[i].Length - 1];
            }

            int imagePixelsArrayIndex = 8;
            string fileLength = string.Empty;
            if (BinaryToString(fileType) == "t")//text
            {
                string temp = string.Empty;
                while (true)//we find out the length of the hidden text
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != 8 && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        if (BinaryToString(temp) == ";")//end of the header is marked by a ";"
                        {
                            imagePixelsArrayIndex++;
                            break;
                        }
                        else
                        {
                            fileLength += BinaryToString(temp);
                            temp = string.Empty;
                        }
                    }
                    imagePixelsArrayIndex++;
                }

                string hiddenText = string.Empty;
                temp = string.Empty;
                int currentimagePixelsArrayIndex = imagePixelsArrayIndex;

                while (true)//getting the hidden text itself
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != currentimagePixelsArrayIndex && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        hiddenText += BinaryToString(temp);
                        temp = string.Empty;
                    }
                    if (hiddenText.Length == Convert.ToInt32(fileLength))//the entire text has been read
                    {
                        break;
                    }
                    imagePixelsArrayIndex++;
                }

                //make all relevant entities visible
                getInfoLabel.Text = "Soubor obsahuje skrytý text.";
                hiddenTextTB.Text = hiddenText;
                hiddenTextTB.Visible = true;
                label5.Visible = true;
                saveTxtFileLocationTB.Visible = true;
                button3.Visible = true;
            }
            else if (BinaryToString(fileType) == "i")//image
            {
                string temp = string.Empty;
                string privateImageWidthString = string.Empty;
                string privateImageHeightString = string.Empty;
                bool widthRead = false;
                string header = string.Empty;
                int semicolonCounter = 0;
                bool proportionsRead = false;
                string fileName = string.Empty;

                while (true)//we find out the proportions and the name of the hidden image
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != 8 && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        if (BinaryToString(temp) == "x")//an "x" is included as a divisor between width and height
                        {
                            widthRead = true;
                            temp = string.Empty;
                            imagePixelsArrayIndex++;
                            continue;
                        }
                        else if(BinaryToString(temp) == ";")
                        {
                            semicolonCounter++;
                            header += ";";
                            proportionsRead = true;//first semicolon - proportions have been read, filename follows
                            if (semicolonCounter == 2)//end of the header is marked by a ";"
                            {
                                imagePixelsArrayIndex++;
                                break;
                            }
                            temp = string.Empty;
                        }
                        else
                        {
                            if(!proportionsRead)
                            {
                                if (!widthRead)
                                {
                                    privateImageWidthString += BinaryToString(temp);
                                }
                                else
                                {
                                    privateImageHeightString += BinaryToString(temp);
                                }
                            }
                            else
                            {
                                fileName += BinaryToString(temp);
                            }
                            temp = string.Empty;
                        }
                    }
                    imagePixelsArrayIndex++;
                }

                int privateImageWidth = Convert.ToInt32(privateImageWidthString);
                int privateImageHeight = Convert.ToInt32(privateImageHeightString);
                temp = string.Empty;
                int currentimagePixelsArrayIndex = imagePixelsArrayIndex;
                string[] privateImagePixelsArray = new string[privateImageWidth * privateImageHeight * 3];
                int privateImagePixelsArrayIndex = 0;

                while (true)//getting the hidden image itself
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != currentimagePixelsArrayIndex && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        privateImagePixelsArray[privateImagePixelsArrayIndex] = temp;
                        privateImagePixelsArrayIndex++;
                        temp = string.Empty;
                    }
                    imagePixelsArrayIndex++;

                    if (privateImagePixelsArrayIndex == privateImagePixelsArray.Count())//the entire word has been read
                    {
                        break;
                    }
                }

                //create image from pixel array
                privateImagePixelsArrayIndex = 0;
                var privateBitmap = new Bitmap(privateImageWidth, Convert.ToInt32(privateImageHeight));
                for (int x = 0; x < privateBitmap.Width; x++)
                {
                    for (int y = 0; y < privateBitmap.Height; y++)
                    {
                        int R = BinaryToInt(privateImagePixelsArray[privateImagePixelsArrayIndex]);
                        int G = BinaryToInt(privateImagePixelsArray[privateImagePixelsArrayIndex + 1]);
                        int B = BinaryToInt(privateImagePixelsArray[privateImagePixelsArrayIndex + 2]);
                        Color pixelColor = Color.FromArgb(R, G, B);
                        privateBitmap.SetPixel(x, y, pixelColor);
                        privateImagePixelsArrayIndex += 3;
                    }
                }

                //make all relevant entities visible
                pictureBox1.Image = privateBitmap;
                pictureBox1.Visible = true;
                getInfoLabel.Text = "Soubor obsahuje skrytý obrázek.";
                label10.Visible = true;
                string[] fileNameSplitByDot = fileName.Split(".");
                string pathToSave = Path.GetDirectoryName(existingImagePath) + "\\" + fileName;
                ImageFormat imageFormat = ParseImageFormat(fileNameSplitByDot[1]);//save image in its original format
                pictureBox1.Image.Save(pathToSave, imageFormat);
                string message = "Soubor obsahuje skrytý obrázek s názvem " + fileName + "\nTento soubor byl automaticky uložen do složky ve které se nachází obrázek.";
                MessageBox.Show(message, "Obrázek nalezen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BinaryToString(fileType) == "f")//file
            {
                string temp = string.Empty;
                string header = string.Empty;
                int semicolonCounter = 0;
                while (true)//we find out the length of the hidden file
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != 8 && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        if (BinaryToString(temp) == ";")
                        {
                            semicolonCounter++;
                            header += ";";
                            if (semicolonCounter == 2)//end of the header is marked by a ";"
                            {
                                imagePixelsArrayIndex++;
                                break;
                            }
                            temp = string.Empty;
                        }
                        else
                        {
                            header += BinaryToString(temp);
                            temp = string.Empty;
                        }
                    }
                    imagePixelsArrayIndex++;
                }

                //get file length and file name from the remaining parts of the header
                string[] headerSplitBySemicolon = header.Split(";");
                fileLength = headerSplitBySemicolon[0];
                string fileName = headerSplitBySemicolon[1];

                byte[] hiddenData = new byte[Convert.ToInt32(fileLength)];
                temp = string.Empty;
                int currentimagePixelsArrayIndex = imagePixelsArrayIndex;
                int hiddenDataIndex = 0;

                while (true)//getting the hidden file itself
                {
                    temp += imagePixelsArray[imagePixelsArrayIndex][imagePixelsArray[imagePixelsArrayIndex].Length - 1];
                    if (imagePixelsArrayIndex != currentimagePixelsArrayIndex && (imagePixelsArrayIndex + 1) % 8 == 0)//8 binary chars equal one regular char
                    {
                        hiddenData[hiddenDataIndex] += BinaryToByte(temp);
                        temp = string.Empty;
                        hiddenDataIndex++;
                    }
                    if (hiddenDataIndex == Convert.ToInt32(fileLength))//the entire file has been read
                    {
                        break;
                    }
                    imagePixelsArrayIndex++;
                }

                //make all relevant entities visible
                string pathToSave = Path.GetDirectoryName(existingImagePath) + "\\" + fileName;
                File.WriteAllBytes(pathToSave, hiddenData);
                getInfoLabel.Text = "Soubor obsahuje skrytý soubor.";
                label5.Visible = true;
                label10.Visible = true;
                saveTxtFileLocationTB.Visible = true;
                button3.Visible = true;
                string message = "Soubor obsahuje skrytý soubor s názvem " + fileName + "\nTento soubor byl automaticky uložen do složky ve které se nachází obrázek.";
                MessageBox.Show(message, "Soubor nalezen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                getInfoLabel.Text = "Soubor neobsahuje žádnou steganografii vytvořenou v tomto programu.";
            }
        }

        /// <summary>
        /// Parse string to ImageFormat object
        /// </summary>
        public static ImageFormat ParseImageFormat(string str)
        {
            return (ImageFormat)typeof(ImageFormat)
                    .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                    .GetValue(null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(Path.GetDirectoryName(saveTxtFileLocationTB.Text)))
            {
                MessageBox.Show("Chyba: špatná lokace k uložení souboru.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!pictureBox1.Visible)//text
                {
                    File.WriteAllText(saveTxtFileLocationTB.Text, hiddenTextTB.Text);
                }
                else//image
                {
                    pictureBox1.Image.Save(saveTxtFileLocationTB.Text, ImageFormat.Png);
                }
                MessageBox.Show("Soubor byl úspěšně vytvořen.", "Soubor vytvořen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Hides an existing (private) image into an existing (public) image
        /// </summary>
        public void AddImageToImage(string privateImagePath, string publicImagePath, string newImageName)
        {
            bool isImage = true;
            var privateBitmap = new Bitmap(1,1);
            try
            {
                privateBitmap = new Bitmap(privateImagePath);
            }
            catch
            {
                isImage = false;
                AddFileToImage(privateImagePath, publicImagePath, newImageName);
            }

            if(isImage)
            {
                string header = "i" + privateBitmap.Width + "x" + privateBitmap.Height + ";" + Path.GetFileName(privateImagePath) + ";"; ;//header includes the letter i (for image) and private image's proportions
                string[] privateImagePixelsArray = GetImagePixelsArray(privateImagePath, null);
                string[] publicImagePixelsArray = GetImagePixelsArray(publicImagePath, null);

                bool isPublicImageLargeEnough = true;
                bool userWantsToEnlargeImage = true;
                int maxLength = 0;
                if (StringToBinary(header).Length + privateImagePixelsArray.Length > publicImagePixelsArray.Length)//check if the public image is large enough to contain the private image
                {
                    isPublicImageLargeEnough = false;
                    int headerLength = StringToBinary(header).Length;
                    maxLength = (publicImagePixelsArray.Length - headerLength) / 8;
                    string errorMessage = "Chyba: do tohoto obrázku lze zapsat obrázek o velikosti maximálně " + maxLength + " pixelů. Vkládaný obrázek má " + privateBitmap.Width * privateBitmap.Height + " pixelů." +
                        "\nChcete tento obrázek zvětšit?";
                    var result = MessageBox.Show(errorMessage, "Chyba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        userWantsToEnlargeImage = false;
                    }
                }

                var publicBitmap = new Bitmap(publicImagePath);
                //resize the image in case it's too small and the user wants to resize it
                if (!isPublicImageLargeEnough && userWantsToEnlargeImage)
                {
                    //the image is resized in a manner that lets the image keep its original width/height ratio
                    double sizeDifference = (privateBitmap.Width * privateBitmap.Height) / maxLength;
                    int newWidth = publicBitmap.Width * (int)Math.Ceiling(sizeDifference);
                    int newHeight = publicBitmap.Height * (int)Math.Ceiling(sizeDifference);
                    publicBitmap = new Bitmap(publicBitmap, new Size(newWidth, newHeight));

                    //it's necessary to modify this array too, because for now it holds the pixels of the original (smaller) image
                    publicImagePixelsArray = GetImagePixelsArray(publicImagePath, publicBitmap);
                }

                if (userWantsToEnlargeImage)
                {
                    string privateImagePixels = string.Empty;
                    for (int i = 0; i < privateImagePixelsArray.Count(); i++)
                    {
                        privateImagePixels += privateImagePixelsArray[i];
                    }
                    string binaryText = StringToBinary(header) + privateImagePixels;

                    //hide image (in last bit of every array element)
                    for (int i = 0; i < binaryText.Length; i++)
                    {
                        publicImagePixelsArray[i] = publicImagePixelsArray[i].Remove(publicImagePixelsArray[i].Length - 1, 1) + binaryText[i];
                    }

                    //create image from pixel array
                    int imagePixelsArrayIndex = 0;
                    for (int x = 0; x < publicBitmap.Width; x++)
                    {
                        for (int y = 0; y < publicBitmap.Height; y++)
                        {
                            int R = BinaryToInt(publicImagePixelsArray[imagePixelsArrayIndex]);
                            int G = BinaryToInt(publicImagePixelsArray[imagePixelsArrayIndex + 1]);
                            int B = BinaryToInt(publicImagePixelsArray[imagePixelsArrayIndex + 2]);
                            Color pixelColor = Color.FromArgb(R, G, B);
                            publicBitmap.SetPixel(x, y, pixelColor);
                            imagePixelsArrayIndex += 3;
                        }
                    }

                    //save image
                    string path = Path.GetDirectoryName(publicImagePath) + "\\" + newImageName + ".png";
                    publicBitmap.Save(path, ImageFormat.Png);
                    MessageBox.Show("Obrázek " + newImageName + ".png úspěšně vytvořen.", "Obrázek vytvořen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void AddFileToImage(string privateFilePath, string publicImagePath, string newImageName)
        {
            string[] imagePixelsArray = GetImagePixelsArray(publicImagePath, null);

            byte[] bytes = File.ReadAllBytes(privateFilePath);
            string binaryText = string.Empty;
            for(int i = 0; i < bytes.Length; i++)
            {
                binaryText += ByteToBinary(bytes[i]);
            }
            string header = "f" + bytes.Length + ";" + Path.GetFileName(privateFilePath) + ";";
            binaryText = StringToBinary(header) + binaryText;

            bool isPublicImageLargeEnough = true;
            bool userWantsToEnlargeImage = true;
            int maxLength = 0;

            if (binaryText.Length > imagePixelsArray.Length)//check if the image is large enough to contain the text
            {
                isPublicImageLargeEnough = false;
                int headerLength = StringToBinary(header).Length;
                maxLength = (imagePixelsArray.Length - headerLength) / 8;
                string errorMessage = "Chyba: do tohoto obrázku lze zapsat soubor o velikosti maximálně " + maxLength + " znaků. Délka soubor je " + (binaryText.Length - header.Length)  + " znaků." +
                    "\nChcete tento obrázek zvětšit?";
                var result = MessageBox.Show(errorMessage, "Chyba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    userWantsToEnlargeImage = false;
                }
            }

            var bitmap = new Bitmap(publicImagePath);
            //resize the image in case it's too small and the user wants to resize it
            if (!isPublicImageLargeEnough && userWantsToEnlargeImage)
            {
                //the image is resized in a manner that lets the image keep its original width/height ratio
                double sizeDifference = (bitmap.Width * bitmap.Height) / maxLength;
                int newWidth = bitmap.Width * (int)Math.Ceiling(sizeDifference);
                int newHeight = bitmap.Height * (int)Math.Ceiling(sizeDifference);
                bitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));

                //it's necessary to modify this array too, because for now it holds the pixels of the original (smaller) image
                imagePixelsArray = GetImagePixelsArray(publicImagePath, bitmap);
            }

            if (userWantsToEnlargeImage)
            {
                //add file to array
                int charsWritten = 0;
                for (int i = 0; i < imagePixelsArray.Length; i++)
                {
                    imagePixelsArray[i] = imagePixelsArray[i].Remove(imagePixelsArray[i].Length - 1, 1) + binaryText[charsWritten];
                    charsWritten++;

                    //the file has been written into the array
                    if (charsWritten == binaryText.Length)
                    {
                        break;
                    }
                }

                //create image from pixel array
                int imagePixelsArrayIndex = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int R = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex]);
                        int G = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex + 1]);
                        int B = BinaryToInt(imagePixelsArray[imagePixelsArrayIndex + 2]);
                        Color pixelColor = Color.FromArgb(R, G, B);
                        bitmap.SetPixel(x, y, pixelColor);
                        imagePixelsArrayIndex += 3;
                    }
                }

                //save image
                string path = Path.GetDirectoryName(publicImagePath) + "\\" + newImageName + ".png";
                bitmap.Save(path, ImageFormat.Png);
                MessageBox.Show("Obrázek " + newImageName + ".png úspěšně vytvořen.", "Obrázek vytvořen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(privateImagePathTB.Text))
            {
                MessageBox.Show("Chyba: ukrývaný obrázek neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(publicImagePathTB.Text))
            {
                MessageBox.Show("Chyba: veřejný obrázek neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddImageToImage(privateImagePathTB.Text, publicImagePathTB.Text, newPublicImageNameTB.Text);
            }
        }

        /// <summary>
        /// Detects steganography in an existing image (including images created in other applications)
        /// </summary>
        public void DetectSteganography(string imagePath)
        {
            var bitmap = new Bitmap(imagePath);
            //for convenience, the image is loaded into a 2D array rather than a 1D array
            (int, int, int)[,] imagePixelsArray = new (int, int, int)[bitmap.Width, bitmap.Height];
            for (int bitmapX = 0; bitmapX < bitmap.Width; bitmapX++)
            {
                for (int bitmapY = 0; bitmapY < bitmap.Height; bitmapY++)
                {
                    Color pixelColor = bitmap.GetPixel(bitmapX, bitmapY);
                    int R = pixelColor.R;
                    int G = pixelColor.G;
                    int B = pixelColor.B;
                    imagePixelsArray[bitmapX, bitmapY] = (R, G, B);
                }
            }

            //every square consisting of four neighboring pixels is gradually examined
            //in case three of the pixels share the same R, G or B color value and the fourth pixel contains a color value which differs from the three pixels by one, steganography detection is reported
            int x = 0;
            int y = 0;
            int steganographyDetected = 0;
            for(int i = 0; i < imagePixelsArray.Length; i++)
            {
                //R color
                List<int> RTuple = new List<int> { imagePixelsArray[x, y].Item1, imagePixelsArray[x, y + 1].Item1, imagePixelsArray[x + 1, y].Item1, imagePixelsArray[x + 1, y + 1].Item1 };
                var RTupleGroupByValue = RTuple.GroupBy(x => x);
                var RTupleGroupByValueList = RTupleGroupByValue.Select(x => x.ToList()).ToList();
                if(RTupleGroupByValueList.Count == 2)
                {
                    //check that only one value of the four is distinct
                    if ((RTupleGroupByValueList[0].Count == 3 && RTupleGroupByValueList[1].Count == 1) ||
                        RTupleGroupByValueList[1].Count == 3 && RTupleGroupByValueList[0].Count == 1)
                    {
                        //check that the distinct value differs from the others values only by one
                        if (RTupleGroupByValueList[0].First() + 1 == RTupleGroupByValueList[1].First() ||
                            RTupleGroupByValueList[0].First() - 1 == RTupleGroupByValueList[1].First())
                        {
                            steganographyDetected++;
                        }
                    }
                }

                //G color
                List<int> GTuple = new List<int> { imagePixelsArray[x, y].Item1, imagePixelsArray[x, y + 1].Item1, imagePixelsArray[x + 1, y].Item1, imagePixelsArray[x + 1, y + 1].Item1 };
                var GTupleGroupByValue = GTuple.GroupBy(x => x);
                var GTupleGroupByValueList = GTupleGroupByValue.Select(x => x.ToList()).ToList();
                if (GTupleGroupByValueList.Count == 2)
                {
                    //check that only one value of the four is distinct
                    if ((GTupleGroupByValueList[0].Count == 3 && GTupleGroupByValueList[1].Count == 1) ||
                        GTupleGroupByValueList[1].Count == 3 && GTupleGroupByValueList[0].Count == 1)
                    {
                        //check that the distinct value differs from the others values only by one
                        if (GTupleGroupByValueList[0].First() + 1 == GTupleGroupByValueList[1].First() ||
                            GTupleGroupByValueList[0].First() - 1 == GTupleGroupByValueList[1].First())
                        {
                            steganographyDetected++;
                        }
                    }
                }

                //B color
                List<int> BTuple = new List<int> { imagePixelsArray[x, y].Item1, imagePixelsArray[x, y + 1].Item1, imagePixelsArray[x + 1, y].Item1, imagePixelsArray[x + 1, y + 1].Item1 };
                var BTupleGroupByValue = BTuple.GroupBy(x => x);
                var BTupleGroupByValueList = BTupleGroupByValue.Select(x => x.ToList()).ToList();
                if (BTupleGroupByValueList.Count == 2)
                {
                    //check that only one value of the four is distinct
                    if ((BTupleGroupByValueList[0].Count == 3 && BTupleGroupByValueList[1].Count == 1) ||
                        BTupleGroupByValueList[1].Count == 3 && BTupleGroupByValueList[0].Count == 1)
                    {
                        //check that the distinct value differs from the others values only by one
                        if (BTupleGroupByValueList[0].First() + 1 == BTupleGroupByValueList[1].First() ||
                            BTupleGroupByValueList[0].First() - 1 == BTupleGroupByValueList[1].First())
                        {
                            steganographyDetected++;
                        }
                    }
                }

                x++;
                if(x == imagePixelsArray.GetLength(0)-1)//we've reached the end of the row
                {
                    x = 0;
                    y++;
                }
                if(y == imagePixelsArray.GetLength(1)-1)//we've reached the end of the picture
                {
                    break;
                }
            }
            if(steganographyDetected > 0)
            {
                label12.Text = "Obrázek pravděpodobně obsahuje steganografii (počet nálezů: " + steganographyDetected + ").";
            }
            else
            {
                label12.Text = "Obrázek pravděpodobně neobsahuje žádnou steganografii.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!File.Exists(detectSteganographyImagePathTB.Text))
            {
                MessageBox.Show("Chyba: obrázek neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DetectSteganography(detectSteganographyImagePathTB.Text);
            }
        }
    }
}