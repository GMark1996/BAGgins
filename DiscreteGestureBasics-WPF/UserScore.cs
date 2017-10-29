using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    public class UserScore
    {
        Dictionary<string, float> ownGestures = null;
        string name = null;
        string dir = @"C:\LOTR\Scores";
        string serializationFile = null;

        public string Name { get => name; set => name = value; }

        public UserScore(string name)
        {
            this.Name = name;   
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
                ownGestures = new Dictionary<string, float>();
            }
        }

        public Dictionary<string, float> getGestures()
        {
            return ownGestures;
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
