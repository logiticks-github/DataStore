using Mobility.Infrastructure.Models;

namespace DataStore.Models
{
    public class Item : BaseModel
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
