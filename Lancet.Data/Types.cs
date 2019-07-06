using System;

namespace Lancet.Data
{
    public class Types
    {
        public static class Account
        {
            private static Guid _id = new Guid("9DFB1336-1EDB-4C6F-9EC2-FB844AD065CC");
            /// <summary>
            /// Идентификатор аккаунта
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
        public static class Group
        {
            private static Guid _id = new Guid("7b3462b0-46e0-4003-b9af-0dd726588e0f");
            /// <summary>
            /// Идентификатор группы
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
        public static class Page
        {
            private static Guid _id = new Guid("14d5b3f8-f896-4c3d-923d-86a314196cdd");
            /// <summary>
            /// Идентификатор страницы
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
        public static class Admin
        {
            private static Guid _id = new Guid("d2ed7419-aa90-4c81-87cd-7d6888dcacf3");
            /// <summary>
            /// Идентификатор роли Админ
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
        public static class User
        {
            private static Guid _id = new Guid("ad1497aa-46f1-4da6-bc4a-8665e40f18ce");
            /// <summary>
            /// Идентификатор роли Пользователь
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
        public static class Role
        {
            private static Guid _id = new Guid("29f7acc5-16f8-44ce-85d7-036ce1e3b325");
            /// <summary>
            /// Идентификатор Роль
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
    }
}
