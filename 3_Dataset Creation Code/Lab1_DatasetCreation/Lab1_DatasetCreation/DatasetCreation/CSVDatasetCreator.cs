using Lab1_DatasetCreation.FeatureExtraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DatasetCreation.DatasetCreation
{
    class CSVDatasetCreator
    {
        public void createCSVDataset(IFeatureExtractor featureExtractor, string directoryPath, string destinationCSVFilePath)
        {
            StringBuilder csvDatasetHeader = new StringBuilder();
            StringBuilder csvDataset = new StringBuilder();
            string delimiter = ",";
            bool headerBuilt = false;
            int counter = 0;

            Dictionary<string, double> fileFeatures;
            if (Directory.Exists(directoryPath))
            {
                foreach (string filePath in Directory.GetFiles(directoryPath))
                {
                    fileFeatures = featureExtractor.extractFeatures(filePath);
                    csvDataset.Append(filePath).Append(delimiter);
                    if (!headerBuilt)
                    {
                        csvDatasetHeader.Append("File path").Append(delimiter);
                    }
                    foreach (KeyValuePair<string, double> feature in fileFeatures.OrderBy(x => x.Key))
                    {
                        csvDataset.Append(feature.Value).Append(delimiter);

                        if (!headerBuilt)
                        {
                            csvDatasetHeader.Append(feature.Key).Append(delimiter);
                        }
                    }

                    csvDataset.Append("\n");
                    headerBuilt = true;
                    Console.WriteLine(String.Format("{0}. {1}", ++counter, filePath));
                }
            }
            writeCSVFile(csvDatasetHeader.Append("\n").Append(csvDataset).ToString(), destinationCSVFilePath);
        }
    

        private void writeCSVFile(string CSV, string destinationCSVFilePath)
        {
            using (StreamWriter sw = new StreamWriter(destinationCSVFilePath))
            {
                sw.Write(CSV);
            }
        }

        private string getCSVrecord(Dictionary<string, double> features)
        {
            String CSVRecord = String.Empty;

            foreach(KeyValuePair<string,double> entry in features)
            {
                CSVRecord += entry.Value + ",";
            }

            return CSVRecord;
        }
    }
}
