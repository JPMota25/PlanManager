namespace PlanManager.Shared.Authorization
{
    public static class Permissions
    {
        public static class PlanManager
        {
            public static class Profiles
            {
                public static class Company
                {
                    public const string View = "planmanager.company.view";
                    public const string Create = "planmanager.company.create";
                    public const string Edit = "planmanager.company.edit";
                    public const string Delete = "planmanager.company.delete";
                }
                public static class User
                {
                    public const string View = "planmanager.user.view";
                    public const string Create = "planmanager.user.create";
                    public const string Edit = "planmanager.user.edit";
                    public const string Delete = "planmanager.user.delete";
                }
                public static class Person
                {
                    public const string View = "planmanager.person.view";
                    public const string Create = "planmanager.person.create";
                    public const string Edit = "planmanager.person.edit";
                    public const string Delete = "planmanager.person.delete";
                }
                public static class Customer
                {
                    public const string View = "planmanager.customer.view";
                    public const string Create = "planmanager.customer.create";
                    public const string Edit = "planmanager.customer.edit";
                    public const string Delete = "planmanager.customer.delete";
                }
            }
            public static class Plan
            {
                public const string View = "planmanager.plan.view";
                public const string Create = "planmanager.plan.create";
                public const string Edit = "planmanager.plan.edit";
                public const string Delete = "planmanager.plan.delete";
            }

            public static class License
            {
                public const string View = "planmanager.license.view";
                public const string Create = "planmanager.license.create";
                public const string Edit = "planmanager.license.edit";
                public const string Delete = "planmanager.license.delete";
            }

            public static class Sign
            {
                public const string View = "planmanager.sign.view";
                public const string Create = "planmanager.sign.create";
                public const string Edit = "planmanager.sign.edit";
                public const string Delete = "planmanager.sign.delete";
            }

            public static class PlanPermission
            {
                public const string View = "planmanager.plan_permission.view";
                public const string Create = "planmanager.plan_permission.create";
                public const string Edit = "planmanager.plan_permission.edit";
                public const string Delete = "planmanager.plan_permission.delete";
            }

            public static class PlanPermissionRelation
            {
                public const string View = "planmanager.plan_permission_relation.view";
                public const string Create = "planmanager.plan_permission_relation.create";
                public const string Edit = "planmanager.plan_permission_relation.edit";
                public const string Delete = "planmanager.plan_permission_relation.delete";
            }
        }
    }
}
