using System.Collections.Generic;

namespace User_Interface.Models
{
    public class PageUserListView
    {
        public List<ViewUser> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public UsersFilter UsersFilter { get; set; }
    }
}