using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace uNhAddIns.Serialization
{
    public class Cloner
    {
        /// <summary>
        /// Make a object clone via Serializing/Deserealizing the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Clone(object obj)
        {
            return Clone(obj, new BinaryFormatter());
        }

        public static object Clone(object obj, IFormatter formatter)
        {   
            using (MemoryStream buffer = new MemoryStream())
            {
                formatter.Serialize(buffer,obj);
                buffer.Position = 0;
                return formatter.Deserialize(buffer);
            }
        }
 
    }
}
