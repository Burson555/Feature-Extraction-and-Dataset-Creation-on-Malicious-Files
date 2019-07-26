using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1_DatasetCreation.FeatureExtraction
{
    class FeatureExtractor_PDF_Keywords : IFeatureExtractor
    {
        private string[] keywords = {
            "obj",
            "endobj",
            "stream",
            "endstream",
            "xref",
            "startxref",
            "trailer",
            "/Page",
            "/Encrypt",
            "/JS",
            "/JavaScript",
            "/AA",
            "/OpenAction",
            "/JBIG2Decode"
        };

        public Dictionary<string, double> extractFeatures(string filePath)
        {
            Dictionary<String, Double> features_keywords = new Dictionary<string, double>();

            if (File.Exists(filePath))
            {
                try
                {
                    String fileContent = File.ReadAllText(filePath);
                    int keywordFrequency;
                    foreach (string keyword in keywords)
                    {
                        keywordFrequency = Regex.Matches(fileContent, keyword, RegexOptions.IgnoreCase).Count;
                        features_keywords.Add(keyword, keywordFrequency);
                    }
                } catch (Exception e)
                {
                    String.Format("Error extracting keywords features from file {0}", filePath);
                }
            }

            return features_keywords;
        }

        public string getDescription()
        {
            return "The feature extractor extract 14 keywords: 'obj' .... 'JBig2Decode'";
        }

        public string getName()
        {
            return "PDF Keyworkds";
        }
    }
}
