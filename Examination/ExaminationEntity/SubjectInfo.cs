using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationEntity {
    public class SubjectInfo {
        public Guid Id { get; set; }
        public string Abstract { get; set; }
        public string SubType { get; set; }
        public string Result { get; set; }
        public string SelectItem1 { get; set; }
        public string SelectItem2 { get; set; }
        public string SelectItem3 { get; set; }
        public string SelectItem4 { get; set; }
        public string SubLevel { get; set; }
        public byte[] SubAudio { get; set; }
        public string SubAudioName { get; set; }
    }
}
