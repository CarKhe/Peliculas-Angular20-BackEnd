namespace PeliculasAPI
{
    public class ServicioTransient
    {
        private readonly Guid _id; //Guid = String aleatorio
        public ServicioTransient()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetGuid => _id;
    }

    public class ServicioScoped                                                      
    {
        private readonly Guid _id; //Guid = String aleatorio
        public ServicioScoped()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetGuid => _id;
    }

    public class ServicioSingleton 
    {
        private readonly Guid _id; //Guid = String aleatorio
        public ServicioSingleton ()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetGuid => _id;
    }

}
