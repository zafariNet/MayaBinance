using System;
using System.Collections.Generic;
using System.Text;

namespace MayaBinance.Shared.utils
{
    public class ExceptionHandler
    {
        public static string GetError(Exception e)
        {
            var message="";
            if (e.InnerException != null) message= e.InnerException == null ? e.InnerException.Message : e.Message;
            return message;
        }
    }
}
