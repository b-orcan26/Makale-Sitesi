using MakaleExample.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakaleExample.ViewModels
{
    public class PartialDataViewModel
    {
        public IPagedList<Makale> Makaleler { get; set; }
        public string ActionName { get; set; }
    }
}