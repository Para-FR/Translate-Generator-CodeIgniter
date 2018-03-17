using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetoTranslate
{
    public partial class Form1 : Form
    {

        string configPath = Application.StartupPath;
        public Form1()
        {
            InitializeComponent();
            
            textBox_cheminAcces.Text = File.ReadAllText(configPath + "\\Chemin.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contents = File.ReadAllText(@"D:\\Programs\\wamp643\\www\\meeto\\meeto2017\\appz\app\\language\\french\\general_lang.php");
            string test = "\'" + textBox_langAttribut.Text + "\'";



            if (contents.Contains(test))
            {
                MessageBox.Show("L'attribut " + test + "existe déjà", "Erreur");
            }
            // @"D:\Save_Para_End_2017\\Ynov\\C#\\MeetoTranslate\\MeetoTranslate\\language\\test\\general_lang.php"

            else
            {



                if (textBox_french.Text != "" && textBox_english.Text != "" && textBox_deutsch.Text != "" && textBox_spanish.Text != "" && textBox_italian.Text != "" && textBox_chinese.Text != "")
                {
                    string[] langues = new string[] { "french", "english", "german", "spanish", "italian", "chinese", "test" };
                    string[] textboxLang = new string[] { textBox_french.Text, textBox_english.Text, textBox_deutsch.Text, textBox_spanish.Text, textBox_italian.Text, textBox_chinese.Text };
                    for (int i = 0; i < langues.Length - 1; i++)
                    {
                        Actions.addLang(langues[i], test, textboxLang[i]);
                    }

                    DialogResult resultat = MessageBox.Show("Le lang " + textBox_langAttribut.Text + " a bien été ajouté", "Ajout Effectué", MessageBoxButtons.OK);

                    if (resultat == DialogResult.OK)
                    {
                        textBox_langAttribut.Text = String.Empty;

                        textBox_french.Text = String.Empty;
                        textBox_english.Text = String.Empty;
                        textBox_deutsch.Text = String.Empty;
                        textBox_chinese.Text = String.Empty;
                        textBox_spanish.Text = String.Empty;
                        textBox_italian.Text = String.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Erreur", "Un des champs est incomplet");
                }
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox_font.Text, "caca");
            if (textBox_LangPhp.Text != String.Empty)
            {

                string start_chaine = "<?php echo ";
                string chaine = "lang('" + textBox_LangPhp.Text + "')";
                string end_chaine = " ?>";
                string ucfirst = "ucfirst(";
                string strup = "strtoupper(";
                string closeparenthese = ")";


                if (comboBox_font.Text == "ucfirst")
                {
                    //MessageBox.Show("test");
                    textBox_PhpGenerated.Text = start_chaine + ucfirst + chaine + closeparenthese + end_chaine;
                }
                else if (comboBox_font.Text == "strtouppercase")
                {
                    textBox_PhpGenerated.Text = start_chaine + strup + chaine + closeparenthese + end_chaine;
                }
                else
                {

                    textBox_PhpGenerated.Text = start_chaine + chaine + end_chaine;
                }
            }



        }

        // Bouton pour écrire un commentaire dans un lang
        private void btn_commentaryG_Click(object sender, EventArgs e)
        {
            if (textBox_commentaryG.Text != "")
            {
                //string basePath = @"D:\Save_Para_End_2017\\Ynov\\C#\\MeetoTranslate\\MeetoTranslate\\language\\test\\general_lang.php";

                string[] langues = new string[] { "chinese", "english", "french", "german", "italian", "spanish", "test" };

                for (int i = 0; i < 6; i++)
                {
                    Actions.addCommentary(langues[i], textBox_commentaryG.Text);
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string basePathConfig = File.ReadAllText(configPath + "\\Chemin.txt");
                textBox_cheminAcces.Text = fdlg.SelectedPath.ToString();
            }
        }

        private void btn_registerSettings_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file_french =
            new System.IO.StreamWriter(configPath + "\\Chemin.txt", false))
            {
                file_french.WriteLine(textBox_cheminAcces.Text);
            }
            MessageBox.Show("Enregistrement Effectué", "Validé");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Application.StartupPath);
        }
    }
}
