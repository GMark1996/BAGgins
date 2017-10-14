using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    class ScoreBoard
    {
        Dictionary<string, float> ownGestures = null;
        string name = null;
        string dir = @"C:\LOTR\";
        string serializationFile = null;
        public ScoreBoard(string name)
        {
            this.name = name;   
            serializationFile = Path.Combine(dir, name + ".bin");

            if (File.Exists(serializationFile))
            {
                using (Stream stream = File.Open(serializationFile, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    ownGestures = (Dictionary<string, float>)bformatter.Deserialize(stream);
                }
            }
            else
            {
                ownGestures = new Dictionary<string, float>()
                {
                    {"You Shall not Pass", 91.94f},
                    {"You Shall Pass", 99.99f}
                };
                //serialize
                using (Stream stream = File.Open(serializationFile, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, ownGestures);
                }
            }
        }

        public void addScore(string gestureName, float value)
        {
            float originalValue = 0;
            if (ownGestures.TryGetValue(gestureName, out originalValue))
            {
                if (originalValue < value)
                    ownGestures[gestureName] = value;
            }
            else
            {
                ownGestures.Add(gestureName, value);
            }

            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, ownGestures);
            }
        }

    }
}
