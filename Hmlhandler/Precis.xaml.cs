using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace Xmlhandler
{
    /// <summary>
    /// Логика взаимодействия для Precis.xaml
    /// </summary>
    public partial class Precis : Window
    {
        private void Print(XmlNode name)
        {
            if (name.Name == "theme")
                tblock.Text += String.Format("Тема: {0}\n", name.Attributes["name"].Value);
            else if (name.Name == "definition")
                tblock.Text += String.Format("{0} - {1}\n", name.Attributes["name"].Value, name.Attributes["text"].Value);
            else if (name.Name == "para")
            {
                if (name.Attributes["name"].Value == "")
                    tblock.Text += "\n";
                else
                    tblock.Text += String.Format("\n    {0}\n", name.Attributes["name"].Value);

            }
            else if (name.Name == "arrow")
            {
                tblock.Text += String.Format("{0}\n", name.Attributes["name"].Value);
                foreach (XmlNode arrow in name)
                    Print(arrow);

            }
            else if (name.Name == "mark")
                tblock.Text += String.Format("→ {0}  {1}\n",
                name.Attributes["name"].Value,
                name.Attributes["text"].Value);
            else if (name.Name == "comment")
                tblock.Text += String.Format("Комментарий: {0}\n", name.Attributes["text"].Value);
            else if (name.Name == "text")
                tblock.Text += name.Attributes["text"].Value + "\n";
        }
        public Precis(string name)
        {
            InitializeComponent();
            XmlDocument document = new XmlDocument();
            document.Load(String.Format("../../../Resources/{0}.xml", name));
            XmlElement element = document.DocumentElement;
            this.Title = element.Attributes["name"].Value;

            foreach (XmlNode theme in element)
            {
                Print(theme);
                foreach (XmlNode para in theme)
                {
                    Print(para);
                    foreach (XmlNode text in para)
                        Print(text);
                }
            }
        }
    }
}