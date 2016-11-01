namespace ChildhoodMinistry.Web.Interface
{
    public interface IModelBuilder<TViewmodel, TEntity>
    {
        TViewmodel EntityToModel(TEntity item);
        TEntity ModelToEntiy(TViewmodel item);
    }
}