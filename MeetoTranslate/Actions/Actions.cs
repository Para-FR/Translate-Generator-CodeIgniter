using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetoTranslate
{
    public class Actions
    {

        public static void addCommentary(string dossierLangue, string textBox_commentaryG)
        {
            string commentaire = textBox_commentaryG.ToString();
            string start_com = "/* ";
            string end_com = " */";
            string basePathConfig = File.ReadAllText(@"D:\Save_Para_End_2017\Ynov\C#\MeetoTranslate\MeetoTranslate\Actions\Chemin.txt");

            string basePath = basePathConfig + '\\' + dossierLangue + "\\general_lang.php";
            string basePathLocal = @"D:\Save_Para_End_2017\\Ynov\\C#\\MeetoTranslate\\MeetoTranslate\\language\\" + dossierLangue + "\\general_lang.php";


            using (System.IO.StreamWriter file_test =
            new System.IO.StreamWriter(basePath, true))
            {
                file_test.WriteLine(start_com + commentaire + end_com);
            }
        }

        public static void addLang(string dossierLangue,string langAttribut, string textbox)
        {
            string lang = "$lang[";
            string lang_mid = "] = \"";
            string lang_end = "\"; ";
            string basePath = File.ReadAllText(@"D:\Save_Para_End_2017\Ynov\C#\MeetoTranslate\MeetoTranslate\Actions\Chemin.txt");
            string contents = File.ReadAllText(@"D:\\Programs\\wamp643\\www\\meeto\\meeto2017\\appz\app\\language\\french\\general_lang.php");
            string test = "\'" + textbox.ToString() + "\'";

            using (System.IO.StreamWriter file_french =
                    new System.IO.StreamWriter(basePath + dossierLangue +"\\general_lang.php", true))
            {
                file_french.WriteLine(lang + langAttribut + lang_mid + textbox + lang_end);
            }
        }

    }
}
