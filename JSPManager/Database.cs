using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace JSPManager
{
    public class Database
    {
        public static bool AddMember(Member member)
        {
            using (var db = new LiteDatabase("db.sql"))
            {
                var members = db.GetCollection<Member>("members");
                if (members.Exists(x => x.DiscordID == member.DiscordID))
                {
                    Logging.LogInfo("Member already exists, skipping");
                    return false;
                }
                else
                {
                    members.Insert(member);
                    Logging.LogInfo("Member created: " + member.DiscordID );
                    return true;
                }
            }
        }
        public static bool RemoveMember(int discordId)
        {
            using (var db = new LiteDatabase("db.sql"))
            {
                var members = db.GetCollection<Member>("members");
                var member = members.FindOne(x => x.DiscordID == discordId);
                if (member != null)
                {
                    members.Delete(member.Id);
                    Logging.LogInfo("Member deleted: " + member.DiscordID);
                    return true;
                } 
                else
                {
                    return false;
                }
                
            }
        }
    }
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int DiscordID { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
