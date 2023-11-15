namespace ECOCEMProyect.Services;

public interface IEntitiesServices<Entity>
{
    Task<Entity> GetByIdAsync(int Id);
    Task AddAsync(Entity new_entity);
    Task EditAsync(int Id, Entity edited_entity);
    Task RemoveAsync(int Id);
}
