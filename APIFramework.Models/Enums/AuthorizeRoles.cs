using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models.Enums
{
    public enum AuthorizeRoles
    {
        [Description("Administrator")]
        Administrator,
        [Description("User")]
        User,
        [Description("Manager")]
        Manager,
    }
}
