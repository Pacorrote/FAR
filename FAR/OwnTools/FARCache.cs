namespace FAR.OwnTools
{
    public class FARCache
    {
        private readonly static Dictionary<string, object> _cache = new Dictionary<string, object>();
        public static Dictionary<string, object> OwnCache
        {
            get { return _cache; }
        }
    }
}
