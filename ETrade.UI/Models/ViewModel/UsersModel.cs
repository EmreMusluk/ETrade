using ETrade.Entity.Concrete;

namespace ETrade.UI.Models.ViewModel
{
    public class UsersModel
    {
        public Users Users{ get; set; }
        public List<County> Counties { get; set; }
        public string Msg { get; set; }
    }
}
