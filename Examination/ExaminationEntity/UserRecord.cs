using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationEntity {
    public class UserRecord {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Record { get; set; }
        public DateTime TestTime { get; set; }
        public int TestTimes { get; set; }
        public int HighestScore { get; set; }
    }
}
