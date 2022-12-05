using BankManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        //public int CreatorId { get; set; }

        public DateTime? LastModificationDate { get; set; }

        //public DateTime? DeletionDate { get; set; }



        //public UserEntity Creator { get; set; }

        public virtual string GetCreationProcessDescription()
        {
            var result = "";

            //if (Creator == null)
            //{
            //    result = $"Entity creator not known, but entity created at time {CreationDate:dd-MM-yyyy mm:ss}";
            //}
            //else
            //{
            //    result = $"Entity creator {Creator.GetUserDescription()} created at time {CreationDate:dd-MM-yyyy mm:ss}";
            //}

            return result;
        }

        public string GetUniqueUserGuid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
