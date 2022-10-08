﻿using ShiftSoftware.TypeAuth.Core;
using ShiftSoftware.TypeAuth.Core.Actions;
using System.Collections.Generic;
using System.Linq;

namespace TypeAuth.AccessTree.ActionTrees
{

    [ActionTree("CRM Actions", "Actions Related to the CRM Module.")]
    public class CRMActions
    {
        public readonly static ReadWriteDeleteAction Customers = new ReadWriteDeleteAction("Customers");
        public readonly static ReadWriteDeleteAction DiscountVouchers = new ReadWriteDeleteAction("Discount Vouchers");
       
        public readonly static TextAction DiscountValue = new TextAction("Sale Discount", "", "0", "100", (a, b) =>
        {
            var numbers = new System.Collections.Generic.List<int>();

            if (a != null)
                numbers.Add(int.Parse(a));
            if (b != null)
                numbers.Add(int.Parse(b));

            if (numbers.Count > 0)
                return numbers.Max().ToString();

            return null;
        });

        public readonly static ReadWriteAction Tickets = new ReadWriteAction("Tickets");
        public readonly static ReadAction SocialMediaComments = new ReadAction("Social Media Comments");

        public readonly static TextAction WorkSchedule = new TextAction(
            "Work Schedule",
            "One or more time slots allowed for operation. Certain actions are not allowed outside work schedule.",
            null,
            "00:00:00 - 23:59:59",
            (a, b) =>
            {
                var joined = new System.Collections.Generic.List<string>();

                if (a != null)
                    joined.AddRange(a.Split(',').Select(x => x.Trim()).ToList());

                if (b != null)
                    joined.AddRange(b.Split(',').Select(x => x.Trim()).ToList());

                return string.Join(", ", joined);
            }
        );

        public readonly static Dictionary<string, ReadWriteDeleteAction> Departments = new ReadWriteDeleteAction("Departments").Dynamic(() =>
        {
            var a = new DynamicActionList<ReadWriteDeleteAction>();

            a.Add(new ReadWriteDeleteAction("Marketing") { Id = "1" });
            a.Add(new ReadWriteDeleteAction("IT") { Id = "2" });
            a.Add(new ReadWriteDeleteAction("Finance") { Id = "3" });
            a.Add(new ReadWriteDeleteAction("HR") { Id = "4" });

            a.AddSlefReference("Self Department");

            return a.ToDictionary(x => x.Id, x => x);
        });
    }
}
