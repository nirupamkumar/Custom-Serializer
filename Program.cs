using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;

namespace Custom_Serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player
            {
                health = 100,
                mana = 100,
                completedTutorial = true
            };

            using (MemoryStream mStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(mStream))
                {
                    writer.Write(player.health);
                    writer.Write(player.mana);
                    writer.Write(player.completedTutorial);
                    File.WriteAllBytes("playerdata.bin", mStream.ToArray());
                }
            }

        }

        static void ReadBinaryValues()
        {
            byte[] data = File.ReadAllBytes("playerdata.bin");
            using (MemoryStream ms = new MemoryStream(data))
            {
                using(BinaryReader reader = new BinaryReader(ms))
                {
                    Player readPlayer = new Player
                    {
                        health = reader.ReadInt32(),
                        mana = reader.ReadInt32(),
                        completedTutorial = reader.ReadBoolean()
                    };
                }
            }

        }

        
    }
}
