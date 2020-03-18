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
        Dictionary<string, string> fileinfo = new Dictionary<string, string>();
        string answer = "";
        char[] patern =
                    {
                        ',',
                        '.',
                        '?',
                        '!'
                    };
        public string GetAnswer()
        {
            return answer;
        }
       public void SetAnswer(string _answer)
        {
            answer += _answer;
        }
        public void SetNewAnswer()
        {
            answer = "";
        }
        public void NewFile(string _filename, string _filetext)
        {
            bool status = true;
            foreach(var file in fileinfo)
            {
                if (file.Key == _filename)
                {
                    answer += "Файл " + _filename + " уже был дбавлен в систему и в данный момент обрабатывается. \r\n";
                    status = false;
                    break;
                }
            }
            if (status)
            {
                fileinfo.Add(_filename, _filetext);
                answer += "Файл " + _filename + " был успешно прочитан и начался процесс обработки. \r\n";
            }
        }
        public void ParseText(bool punctiation, int count)
        {
            var temp = fileinfo.Keys.ToArray();
            for (int i = 0; i < temp.Length; i++)
                fileinfo[temp[i]] = ChangeText(fileinfo[temp[i]], punctiation, count, temp[i]);
        }
        string ChangeText(string file, bool punctiation, int count, string fileName)
        {
            string ResultString ="";
            string word = "";
            for (int i=0 ; i < file.Length; i++)
            {
                //
                if (file[i].ToString().TrimStart(patern) != "" && file[i] != ' ' && file[i] != '\r' && file[i] !='\n')
                {
                    word += file[i];
                }
                else if (!punctiation && file[i] != ' ')
                {
                    ResultString += file[i];
                }
                else if (file[i] == '\r' || file[i] == '\n')
                {
                    ResultString += file[i];
                }
                else
                {  if(word.Length>count)
                         ResultString += word + " ";
                    word = "";
                }
            }
            answer += "Работа с файлом " + fileName + " завершена \r\n";
            return ResultString; 
       }
        public string GetFileText(int fileNumber)
        {
            var temp = fileinfo.Values.ToArray();
            return temp[fileNumber];
        }
        public void ClearDict()
        {
            fileinfo = new Dictionary<string, string>();
        }
    }
}
