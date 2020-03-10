using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace TextParser.Model
{
    class Text
    {
        Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
        string answer = "";
        public string GetAnswer()
        {
            return answer;
        }
        public Dictionary<string, List<string>> GetWords()
        {
            return words;
        }
       public void SetAnswer(string _answer)
        {
            answer += _answer;
        }
       
        public void Parser(string FileText,string filename)
        {
            List<string> word = new List<string>();
            var temp = Regex.Matches(FileText, @"[\w']+|\S").Cast<Match>().Select(m => m.Value).ToArray();
            for (int i = 0; i < temp.Length; i++)
                word.Add(temp[i]);
            words.Add(filename,word);
            answer += "Файл" + filename + " успешно прочтён \r\n";
        }
        public void SystemWork(bool punctuation, int count)
        {
            Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
            foreach (var file in words)
            {
                List<string> wordd = new List<string>(); 
                foreach (var word in file.Value)
                {
                    char[] patern =
                    {
                        ',',
                        '.',
                        '?',
                        '!'
                    };
                    if (!punctuation && word.TrimStart(patern) == "")
                    {
                        wordd.Add(word);
                    }
                       else if(word.Length > count && !(word.TrimStart(patern) == ""))
                   {
                        wordd.Add(word);
                    }
               }
                temp.Add(file.Key,wordd);
            }
            words = temp;
        }
    }
}
