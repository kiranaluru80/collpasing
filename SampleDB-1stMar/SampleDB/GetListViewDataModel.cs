using System;
namespace SampleDB
{
        public class GetListViewDataModel
        {
            public int Request_ID { get; set; }
            public string Requested_By { get; set; }
            public string Description { get; set; }
            public DateTime CreatedDate { get; set; }
            public Group Group { get; set; }
            public object MajorGroup_Id { get; set; }
            public User User { get; set; }
            public object Org_Id { get; set; }
            public object Active { get; set; }
        }
    }

