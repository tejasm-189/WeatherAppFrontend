namespace WeatherApp.Services
{
    using Supabase;
    using System.Threading.Tasks;

    public class SupabaseClient
    {
        private static Client? _client;
        private const string SupabaseUrl = "https://zvyiblbxzuftnvoqipir.supabase.co";
        private const string SupabaseAnonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inp2eWlibGJ4enVmdG52b3FpcGlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzg4NDIzOTMsImV4cCI6MjA1NDQxODM5M30._9d4-EYC6y95nkqE2oFArnEm68OZVYFsYbVa1L2erx8";

        public Client GetClient()
        {
            if (_client == null)
            {
                _client = new Client(SupabaseUrl, SupabaseAnonKey, new SupabaseOptions
                {
                    AutoConnectRealtime = true
                });
            }
            return _client;
        }
    }

}
