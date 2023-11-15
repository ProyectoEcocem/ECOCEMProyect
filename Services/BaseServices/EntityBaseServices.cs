namespace ECOCEMProyect.Services;

using ECOCEMProyect.migrations;

public abstract class EntityService<T> where T : class, IEntityModel
{
        private readonly MyContext _webDbContext;

        public EntityService(MyContext webDbContext)
        {
            _webDbContext = webDbContext;
        }
}
