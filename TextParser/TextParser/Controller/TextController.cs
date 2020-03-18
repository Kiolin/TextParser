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
        public Text _text = new Text();
        public async void Reader(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        var temp = await sr.ReadToEndAsync();
                        _text.Parser(temp, filename);
                    }
                }
                catch (Exception e)
                {
                    _text.SetAnswer(e.Message);
                }
            }
        }
        public async void Writter(string filename, bool punctiation, int count, int k)
        {
            var words = _text.GetWords();
            _text.SystemWork(punctiation, count);
            string ForWrite = "";
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    for (int i = 0; i < words.ElementAt(k).Value.Count; i++)
                    {
                        ForWrite += words.ElementAt(k).Value[i] + " ";
                    }
                    await sw.WriteAsync(ForWrite);
                }
                _text.SetAnswer("Файл " + filename + "записан\r\n");
            }
            catch (Exception e)
            {
                _text.SetAnswer(e.Message);
            }
        }

    }
}
