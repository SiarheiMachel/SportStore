using System.Collections.Generic;

namespace SportsStore.Web.Models
{
    public class NavigationModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}