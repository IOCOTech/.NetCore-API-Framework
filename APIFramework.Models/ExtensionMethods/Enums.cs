using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models.ExtensionMethods
{
    public static class Enums
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            if (GenericEnum == null) return "";

            MemberInfo[] memberInfo = GenericEnum.GetType().GetMember(GenericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((attribs != null && attribs.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
