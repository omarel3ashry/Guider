namespace Guider.Infrastructure.Meeting
{
    public class ConnectionMapping
    {
        private readonly Dictionary<int, string> _connections = new Dictionary<int, string>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(int key, string connectionId)
        {
            lock (_connections)
            {
                if (_connections.ContainsKey(key))
                {
                    _connections[key] = connectionId;
                }
                else
                {
                    _connections.Add(key, connectionId);
                }

            }
        }

        public string? GetConnection(int key)
        {
            string? connection;

            _connections.TryGetValue(key, out connection);
            
            return connection;
        }

        public void Remove(int key)
        {
            lock (_connections)
            {
                _connections.Remove(key);
            }
        }

    }
}
