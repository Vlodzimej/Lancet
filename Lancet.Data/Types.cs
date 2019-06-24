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
            private static Guid _id = new Guid("");
            /// <summary>
            /// Идентификатор группы
            /// </summary>
            public static Guid Id { get { return _id; } }
        }
    }
}
