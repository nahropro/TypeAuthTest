using ShiftSoftware.TypeAuth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeAuth.AccessTree.ActionTrees;

namespace TypeAuth.AccessTree
{
    public class AccessTreeFiles
    {
        public static string SuperAdmin = System.IO.File.ReadAllText("C:\\Users\\Nahro\\source\\repos\\nahropro\\TypeAuthTest\\TypeAuthTest\\TypeAuth.ActionTree\\AccessTrees/SuperAdmin.json");
        public static string SalesAdmin = System.IO.File.ReadAllText("C:\\Users\\Nahro\\source\\repos\\nahropro\\TypeAuthTest\\TypeAuthTest\\TypeAuth.ActionTree\\AccessTrees/SalesAdmin.json");
        public static string CRMAgent = System.IO.File.ReadAllText("C:\\Users\\Nahro\\source\\repos\\nahropro\\TypeAuthTest\\TypeAuthTest\\TypeAuth.ActionTree\\AccessTrees/CRMAgent.json");
        public static string Affiliates = System.IO.File.ReadAllText("C:\\Users\\Nahro\\source\\repos\\nahropro\\TypeAuthTest\\TypeAuthTest\\TypeAuth.ActionTree\\AccessTrees/Affiliates.json");
    }

    public class AccessTreeHelper
    {
        public static TypeAuthContext GetTypeAuthContext(string jsonAccessTree)
        {
            return new TypeAuthContext(jsonAccessTree, typeof(SystemActions), typeof(CRMActions));
        }
    }
}
