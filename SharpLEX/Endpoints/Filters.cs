using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLEX
{
    class FilterAttribute : Attribute
    {
        internal FilterAttribute(string representation)
        {
            this.Representation = representation;
        }

        public string Representation { get; private set; }
    }

    public static class Filters
    {
        public static string Representation(this Filter f)
        {
            FilterAttribute attribute = GetAttribute(f);
            return attribute.Representation;
        }

        private static FilterAttribute GetAttribute(Filter f)
        {
            return (FilterAttribute)Attribute.GetCustomAttribute(ForValue(f), typeof(FilterAttribute));
        }

        private static System.Reflection.MemberInfo ForValue(Filter f)
        {
            return typeof(Filter).GetField(Enum.GetName(typeof(Filter), f));
        }
    }

    public enum Filter
    {
        [FilterAttribute("start")] START,
        [FilterAttribute("amount")] AMOUNT,
        [FilterAttribute("order_by")] ORDER_BY,
        [FilterAttribute("order")] ORDER,
        [FilterAttribute("concise")] CONCISE,
        [FilterAttribute("creator")] CREATOR,
        [FilterAttribute("broad_category")] BROAD_CATEGORY,
        [FilterAttribute("lex_category")] LEX_CATEGORY,
        [FilterAttribute("lex_type")] LEX_TYPE,
        [FilterAttribute("broad_type")] BROAD_TYPE,
        [FilterAttribute("group")] GROUP,
        [FilterAttribute("query")] TITLE,
        [FilterAttribute("dependencies")] DEPENDENCIES,
        [FilterAttribute("exclude_notcert")] EXCLUDE_NOT_CERTIFIED,
        [FilterAttribute("exclude_locked")] EXCLUDE_LOCKED
    }
}
