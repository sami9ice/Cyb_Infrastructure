using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfracstructure.DataStructure.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CYBInfrastructure.Web
{
    public class WebRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static void AddUserToRole(string username, string roleName)
        {

        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

            try
            {
                using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
                {
                    foreach(string username in usernames)
                    {
                        UserAccount user = (from u in db.UserAccounts
                                            where u.StaffID == username
                                            select u).FirstOrDefault();
                        if(user!= null)
                        {
                            var AllDbRoles = (from r in db.Roles select r).ToList();
                            List<string> UsersInRoles = new List<string>();
                            foreach (var role in AllDbRoles)
                            {
                                foreach(string roleName in roleNames)
                                {
                                    if(role.RoleName == roleName)
                                    {
                                        UsersInRoles.Add(role.RoleName);
                                        continue;
                                    }
                                }
                            }
                            if(UsersInRoles.Count > 0)
                            {
                                foreach(var RoleName in UsersInRoles)
                                {
                                    UsersInRoles UIR = (from uir in db.UsersInRole
                                                        where uir.UserAccountId == user.UserID && uir.RoleName == RoleName
                                                        select uir).FirstOrDefault();
                                    if (UIR == null)
                                    {
                                        UIR = new UsersInRoles();
                                        UIR.UserAccountId = user.UserID;
                                        UIR.RoleName = RoleName;
                                        db.UsersInRole.Add(UIR);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                    }
                                       
                                }
                            }
                        }
                    }
                }

            }
            catch
            {

            }

        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //using (var context = new CYBInfrastrctureContext())
           // Any(x => x.StaffID == user.StaffID && x.UserID == user.UserID);
            CYBInfrastrctureContext Db = new CYBInfrastrctureContext();
            string data = Db.UsersInRole.Where(a => a.UserAccount.StaffID == username).SingleOrDefault().Role.RoleName;
            string[] result = { data };
            return result;
                //var result = (from user in context.UserAccounts
                //              join role in context.Roles on user.UserID equals role.RoleId
                //              where user.StaffID == username
                //              select role.RoleName).ToArray();
                //return result;

            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = GetRolesForUser(username);
            foreach (var role in roleName)
            {
                if (role.Equals(roleName))
                {
                    return true;
                }
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}