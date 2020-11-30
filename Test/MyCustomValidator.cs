using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class MyCustomValidator
    {
        //public static Func<dynamic, dynamic> IdGuid()
        //{
        //    _function = id =>
        //    {
        //        if (id.Equals(Guid.Empty)) return new ArgumentNullException(nameof(id));
        //        if (id.HasValue && id.Equals(Guid.Empty)) return new ArgumentNullException(nameof(id));
        //        return true;
        //    };
        //    return _function;
        //}
        public static Func<dynamic, dynamic> IdGuid = id =>
        {
            if (id.Equals(Guid.Empty)) return new ArgumentNullException(nameof(id));
            if (id.HasValue && id.Equals(Guid.Empty)) return new ArgumentNullException(nameof(id));
            return true;
        };
    }
}
