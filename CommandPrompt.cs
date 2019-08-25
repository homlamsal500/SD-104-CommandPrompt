using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleAppCommandClass
{
    class CommandPrompt
    {

        ConsoleColor backgroundColor;
        ConsoleColor foregroundColor;
        int height;
        int columns;
        string[] screenText;

        // Constructor 
        public CommandPrompt(int height, int columns)

        {

            // set the default backrgoundcolor and foregorund color
            backgroundColor = ConsoleColor.Red;
            foregroundColor = ConsoleColor.Black;

            // create screen to hold the rows height

            screenText = new string[height];
            Console.SetWindowSize(columns, height + 7);

            // lets set the screen text to empty
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";

            }

        }

        public void Display()
        {

            // set the forgroundcolor and background color

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;


            // Console.Clear();
            Console.WriteLine("**************************   SCREEN TEXT DISPLAYED *************");
            // print the screen text array text

            for (int i = 0; i < screenText.Length; i++)
            {

                Console.WriteLine(screenText[i]);
            }


        }

        public void SetScreenText(int lineNumber, string lineofText)
        {
            screenText[lineNumber] = lineofText;



        }

        public void SetBackgroundColor(string color)
        {
            backgroundColor = ConvertColor(color);


        }
        public void SetForegroundColor(string color)
        {

            foregroundColor = ConvertColor(color);

        }

        public static ConsoleColor ConvertColor(string strColor)
        {
            ConsoleColor color;
            switch (strColor.ToLower())
            {
                case "black": color = ConsoleColor.Black; break;
                case "red": color = ConsoleColor.Red; break;
                case "blue": color = ConsoleColor.Blue; break;
                case "green": color = ConsoleColor.Green; break;

                default: color = ConsoleColor.DarkGray; break;

            }

            return color;

        }

        public void ClearScreen()
        {
            // lets set the screen text to empty
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";

            }

        }

        public void SaveScreen(string fileName)
        {
            FileStream stream;
            StreamWriter textOut = null;


            try
            {
                fileName = "C:/Users/shanc/source/repos/ConsoleAppCommandClass/ConsoleAppCommandClass/" + fileName;
                stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                textOut = new StreamWriter(stream);
                textOut.Write("Text is hsre");


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                if (textOut != null)
                {

                    textOut.Close();
                }

            }

        }

        public void ReloadScreen(string fileName)
        {


            FileStream stream;
            StreamReader textIn = null;

            try
            {


                ///////////// Version 1
                // step 1

                FileStream myFileStream = new FileStream("myfile5.txt", FileMode.Open, FileAccess.Read);

                // step 2
                using (StreamReader myFileReader = new StreamReader(myFileStream))
                {
                    // step 3

                    Console.WriteLine(myFileReader.ReadLine());

                }


                ////////////////// Verison 2
                fileName = "C:/Users/shanc/source/repos/ConsoleAppCommandClass/ConsoleAppCommandClass/" + fileName;
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                // textIn = new StreamReader(stream);

                // step 2
                using (StreamReader txtIn = new StreamReader(stream))
                {
                    // step 3

                    Console.WriteLine(txtIn.ReadToEnd());

                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //textIn.Close();

            }




        }


    }
}
