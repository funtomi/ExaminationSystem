using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationEntity {
    [DataContract]
    public class SubjectInfo {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Abstract { get; set; }
        [DataMember]
        public string SubType { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string SelectItem1 { get; set; }
        [DataMember]
        public string SelectItem2 { get; set; }
        [DataMember]
        public string SelectItem3 { get; set; }
        [DataMember]
        public string SelectItem4 { get; set; }
        [DataMember]
        public string SubLevel { get; set; }
        [DataMember]
        public byte[] SubAudio { get; set; }
        [DataMember]
        public string SubAudioName { get; set; }
    }
}
