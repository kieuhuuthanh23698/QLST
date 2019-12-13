using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class Context
    {
        public static QLSTDataContext context;

        public static QLSTDataContext getInstance() {
            if (context == null)
                context = new QLSTDataContext();
            return context;
        }

    }
}
