using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SubmarineWars
{
    public class HighscoreHelper
    {

        String currDir = Directory.GetCurrentDirectory();
        String highscoreFolder = Directory.GetCurrentDirectory() + "\\highscores";
        String highscoreXml = Directory.GetCurrentDirectory() + "\\highscores\\Highscore.xml";

        // Responsible for checking whether or not the
        // highscore xml file exists
        public HighscoreHelper()
        {
            if (!HighscoreFolderExists())
            {
                Directory.CreateDirectory(highscoreFolder);
            }

            if (!HighscoreFileExists())
            {
                File.Create(highscoreXml).Close();
                SetupXmlStructure();
            }
        }

        public bool HighscoreFileExists()
        {
            if (!File.Exists(highscoreXml))
            {
                return false;
            }
            return true;
        }

        public bool HighscoreFolderExists()
        {
            if (!Directory.Exists(highscoreFolder))
            {
                return false;
            }
            return true;
        }

        // Responsible for creating the XML structure needed
        // to write and read from highscores
        public void SetupXmlStructure()
        {
            // Initialize the xml writer class with file
            XmlDocument xmldocument = new XmlDocument();
            XmlDeclaration declaration = xmldocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmldocument.DocumentElement;
            xmldocument.InsertBefore(declaration, root);

            XmlElement highscoreElement = xmldocument.CreateElement(string.Empty, "highscores", string.Empty);
            xmldocument.AppendChild(highscoreElement);

            xmldocument.Save(highscoreXml);
        }

        public List<KeyValuePair<string, int>> ReadHighscores()
        {
            Dictionary<string, int> highscores = new Dictionary<string, int>();
            XmlDocument xmldocument = GetHighscoreFile();
            XmlNodeList highscoreNodes = xmldocument.DocumentElement.SelectNodes("/highscores/highscore");
            List<KeyValuePair<string, int>> sorted = new List<KeyValuePair<string, int>>();

            foreach (XmlNode highscoreNode in highscoreNodes) {
                highscores.Add(highscoreNode.Attributes["name"].Value, Int32.Parse(highscoreNode.Attributes["score"].Value));
            }

            sorted = (from kv in highscores orderby kv.Value descending select kv).ToList();

            return sorted;
        }


        public XmlDocument GetHighscoreFile()
        {
            if (HighscoreFileExists() && HighscoreFolderExists())
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(highscoreXml);
                return xmldoc;
            }
            return null;
        }

        internal void AddHighscore(string name, int score)
        {
            XmlDocument xmldocument = GetHighscoreFile();

            XmlNode root = xmldocument.SelectSingleNode("/highscores");
            XmlNodeList highscoreNodes = xmldocument.DocumentElement.SelectNodes("/highscores/highscore");

            bool nodeExists = false;

            foreach (XmlNode highscoreNode in highscoreNodes)
            {

                if (highscoreNode.Attributes["name"].Equals(name) && Int32.Parse(highscoreNode.Attributes["score"].Value) < score)
                {
                    nodeExists = true;
                }
                else if (highscoreNode.Attributes["name"].Equals(name) && Int32.Parse(highscoreNode.Attributes["score"].Value) > score)
                {
                    nodeExists = true;
                    highscoreNode.Attributes["score"].Value = score.ToString();
                }
            }

            if (!nodeExists)
            {
                XmlElement child = xmldocument.CreateElement(string.Empty, "highscore", string.Empty);
                XmlAttribute nameAttr = xmldocument.CreateAttribute("name");
                XmlAttribute scoreAttr = xmldocument.CreateAttribute("score");

                nameAttr.InnerText = name;
                scoreAttr.InnerText = score.ToString();
                child.Attributes.Append(nameAttr);
                child.Attributes.Append(scoreAttr);

                root.AppendChild(child);
            }

            xmldocument.Save(highscoreXml);
        }
    }
}
