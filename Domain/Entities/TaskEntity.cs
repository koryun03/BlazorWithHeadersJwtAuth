using Domain.Common.Enums;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }

        //  "create table TaskEntity(Id int primary key identity(1,1),Title nvarchar(max),Description nvarchar(max),State int, IsCompleted bit,UserId int ,
        //  CONSTRAINT FK_TaskEntity_User FOREIGN KEY (UserId) REFERENCES UserEntity(Id) ON DELETE CASCADE)"

        //  ete user-y jnjvav tasknela jnjvum cascadov
    }
}
