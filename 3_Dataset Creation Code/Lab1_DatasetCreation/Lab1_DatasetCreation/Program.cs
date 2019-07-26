using Lab1_DatasetCreation.DatasetCreation;
using Lab1_DatasetCreation.FeatureExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DatasetCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_FeatureExtraction();
            test_DatasetCreation();
        }

        private static void test_DatasetCreation()
        {
            CSVDatasetCreator datasetCreator = new CSVDatasetCreator();
            datasetCreator.createCSVDataset(
                new FeatureExtractor_HistogramByte(),
                @"C:\data\Collections\PDF_0\",
                @"C:\data\datasets\PDF_HistogramByte.csv");
        }

        private static void test_FeatureExtraction()
        {
            IFeatureExtractor featureExtractor;
            featureExtractor = new FeatureExtractor_PDF_Keywords();
            featureExtractor = new FeatureExtractor_HistogramByte();
            Dictionary<String, Double> features = featureExtractor.extractFeatures(@"C:\data\Collections\PDF_0\10.1.1.1.1525.pdf");
            printFeatures(features);
            Console.ReadLine();
        }

        private static void printFeatures(Dictionary<string, double> features)
        {
            foreach(KeyValuePair<string, Double> entry in features)
            {
                Console.WriteLine(String.Format("{0} -> {1}", entry.Key, entry.Value));
            }
        }
    }
}
