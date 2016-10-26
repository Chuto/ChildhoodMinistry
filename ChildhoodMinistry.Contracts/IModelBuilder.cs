namespace ChildhoodMinistry.Contracts
{
    public interface IModelBuilder<TViewmodel, TEntity>
    {
        TViewmodel EntityToModel(TEntity item);
        TEntity ModelToEntiy(TViewmodel item);
    }
}
