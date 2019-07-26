using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DatasetCreation.FeatureExtraction
{
    interface IFeatureExtractor
    {
        String getName();

        String getDescription();

        Dictionary<String,Double> extractFeatures(String filePath);
    }
}
