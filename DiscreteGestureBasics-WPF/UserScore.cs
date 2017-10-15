using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    class UserScore
    {
        Dictionary<string, float> ownGestures = null;
        string name = null;
        string dir = @"C:\LOTR\Scores";
        string serializationFile = null;

        public UserScore(string name)
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

        public void show(ListBox lb)
        {
            Console.Out.WriteLine("Name: " + name+"\nGestures:");
            lb.Items.Add("Name: " + name + "\nGestures:");
            ownGestures.ToList().ForEach(x => {
                Console.Out.WriteLine("Gesture: {0}\t Value: {1}", x.Key, x.Value);
                lb.Items.Add("Gesture: " + x.Key + "\tValue: " + x.Value);
            });
            
        }
    }
}
