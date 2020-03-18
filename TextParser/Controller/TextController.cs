using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextParser.Model;
using System.IO;


namespace TextParser.Controller
{
    class TextController
    {
        int filecount;
        Text _text = new Text();
        public void Reader(string[] filenames)
        {
            filecount = filenames.Length;
            foreach (string filename in filenames)
            {
                _text.SetNewAnswer();
                string temp = "";
                try
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                       //while(sr.ReadLine() != null)
                       //{
                            temp = sr.ReadToEnd();
                       //}
                        _text.NewFile(filename,temp);
                    }
                    
                }
                catch (Exception e)
                {
                    _text.SetAnswer(e.Message+"\r\n");
                }
            }
        }
        public void Writter(string filename, int FileNumber)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.Write(_text.GetFileText(FileNumber));
                }
                _text.SetAnswer("Файл " + filename + " записан \r\n");
                if (FileNumber == filecount - 1)
                    _text.ClearDict();
            }
            catch (Exception e)
            {
                _text.SetAnswer(e.Message+"\r\n");
            }
        }
       public void Parser(bool punctiation, string count)
        {
            bool err = false;
            int wordsLength = 0;
            if (count == "")
            {
                wordsLength = 0;
            }
            else if (Convert.ToInt32(count) < 0)
            {
                _text.SetAnswer("Введено число меньше нуля.");
                err = true;
            }
            else
                wordsLength = Convert.ToInt32(count);
            if(!err)
                _text.ParseText(punctiation, wordsLength);
        }
        public string ChangeAnswer()
        {
            return _text.GetAnswer();
        }
        public int GetFIleCount()
        {
            return filecount;
        }
    }
}
