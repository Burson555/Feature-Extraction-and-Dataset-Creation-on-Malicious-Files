using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DatasetCreation.FeatureExtraction
{
    class FeatureExtractor_HistogramByte : IFeatureExtractor
    {
        public Dictionary<string, double> extractFeatures(string filePath)
        {
            Dictionary<string, double> features = initializeFeaturesDictionary();


            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);

                foreach(byte b in fileBytes)
                {
                    features[b.ToString()]++;
                }
            }

            return features;
        }

        private Dictionary<string, double> initializeFeaturesDictionary()
        {
            Dictionary<string, double> features = new Dictionary<string, double>();
            byte b = 0;
            for(int i=0; i <= 255; i++)
            {
                features.Add(b.ToString(), 0);
                b++;
            }
            return features;
        }

        public string getDescription()
        {
            return "Extracts an histogram based on file's bytes";
        }

        public string getName()
        {
            return "Histogram Byte";
        }
    }
}
