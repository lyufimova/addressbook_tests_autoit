using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTATLE = "Group editor";
        public static string GROUPDELETEWINTATLE = "Delete group";


        public GroupHelper(ApplicationManager manager) : base(manager) { }


        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTATLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GROUPWINTATLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        internal void Remove(GroupData groupForRemove)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTATLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select",  "Contact groups|"+groupForRemove.Name, "");
            aux.ControlClick(GROUPWINTATLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPDELETEWINTATLE);
            aux.ControlClick(GROUPDELETEWINTATLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(GROUPDELETEWINTATLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTATLE);
            CloseGroupsDialogue();
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTATLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTATLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTATLE);
        }
    }
}
