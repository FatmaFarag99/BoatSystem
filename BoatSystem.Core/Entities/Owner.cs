namespace BoatSystem.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Owner
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsVerified { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
