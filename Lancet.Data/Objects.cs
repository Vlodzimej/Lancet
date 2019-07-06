using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Data
{
    public class Objects
    {
        public class Admin
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
    }
}
