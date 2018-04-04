using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationHelper {
    class SerializeHelper {
        public Stream serializeStream(object param) {
            DataContractSerializer serializer = new DataContractSerializer(param.GetType());
            MemoryStream stream = new MemoryStream();

            serializer.WriteObject(stream, param);

            return stream;
        }
         

        public object deserializeStream(Stream stream, Type paramType) {
            DataContractSerializer serializer = new DataContractSerializer(paramType);

            stream.Seek(0, SeekOrigin.Begin);

            object obj = serializer.ReadObject(stream);

            return obj;
        } 

    }
}
