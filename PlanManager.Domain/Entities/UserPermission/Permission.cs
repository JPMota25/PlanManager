using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.Entities.UserPermission
{
    public class Permission : Entity
    {
        private void Validate()
        {
            var contract = new Contract<Notification>().Requires();
            AddNotifications(contract);
        }

        protected Permission(string idGroupPermission, GroupPermission? groupPermission, string keyPermission)
        {
            IdGroupPermission = idGroupPermission;
            GroupPermission = groupPermission;
            KeyPermission = keyPermission;
            Validate();
        }
        public string IdGroupPermission { get; private set; }
        public GroupPermission? GroupPermission{ get; set; }
        public string KeyPermission { get; private set; }
        public Permission()
        {
            
        }
    }
}
