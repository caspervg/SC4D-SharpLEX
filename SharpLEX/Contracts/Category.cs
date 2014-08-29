using System;
using System.Collections.Generic;
using System.Linq;

using RestSharp.Deserializers;


namespace SharpLEX.Contracts
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    public class TypeCategory : Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }

    public class BroadCategory : Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
    }

    public class CategoryOverview
    {
        [DeserializeAs(Name="broad_category")]
        public List<BroadCategory> BroadCategories { get; private set; }

        [DeserializeAs(Name = "lex_category")]
        public List<Category> LexCategories { get; private set; }

        [DeserializeAs(Name = "lex_type")]
        public List<TypeCategory> LexTypes { get; private set; }

        [DeserializeAs(Name = "group")]
        public List<Category> LexGroups { get; private set; }

        [DeserializeAs(Name = "author")]
        public List<Category> LexAuthors { get; private set; }
    }
}
