using System.Collections;
using System.Collections.Generic;

namespace User_Interface.Models
{
    public class PageProjectListView
    {
        public List<ViewProject> Projects { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public ProjectsFilter ProjectsFilter { get; set; }
    }
}