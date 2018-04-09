using ExaminationEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1 {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1 { 

        [OperationContract]
        bool UserLogin(string name, string password, out string errText,out Guid userId);

        [OperationContract]
        bool RegisterUser(string name, string password, out string errText);

        [OperationContract]
        List<string> GetSubjectTypes();

        [OperationContract]
        List<string> GetSubjectLevels();

        [OperationContract]
        List<SubjectInfo> GetSubjects(int num, string level, string type, out string errText);

        [OperationContract]
        bool SaveScore(Guid id, string name, int score, int subNum, string subLevel, out string errText);

        [OperationContract]
        DataTable GetStudyData(Guid id, string name, DateTime start, DateTime end, out string errText);

        [OperationContract]
        DataTable GetStudyRankingList();
    }
     
}
