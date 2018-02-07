using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> test = app.Groups.GetGroupList();
            if ( test.Count == 0  )
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "TEST"
                };
                app.Groups.Add(newGroup);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupForRemove = oldGroups[0];
            app.Groups.Remove(groupForRemove);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(groupForRemove);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

