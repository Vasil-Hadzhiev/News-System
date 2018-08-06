namespace NewsSystem.Services
{
    using NewsSystem.Data;

    public abstract class Service
    {
        public Service()
        {
            this.Context = new NewsSystemDbContext();
        }

        public NewsSystemDbContext Context { get; set; }
    }
}