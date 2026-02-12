namespace PeladaPatronato.Infra.CrossCutting.Data
{
  public class Entity
  {
    public Guid Id { get; protected set; }

    public Entity()
    {
      Id = Guid.NewGuid();
    }

    public void SetId(Guid id)
    {
      Id = id;
    }
  }
}
