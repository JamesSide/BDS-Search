﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public interface ISearchEngine
    {
        List<SearchResult> Search(string query);
    }
}
