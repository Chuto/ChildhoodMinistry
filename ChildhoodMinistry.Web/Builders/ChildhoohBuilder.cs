using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Interface;
using ChildhoodMinistry.Web.Model;

namespace ChildhoodMinistry.Web.Builders
{
    public class ChildhoohBuilder : IModelBuilder<ChildhoodViewModel, Childhood>
    {
        public ChildhoodViewModel EntityToModel(Childhood item)
        {
            return new ChildhoodViewModel
            {
                Adress = item.Adress,
                Ind = item.Id,
                Number = item.Number
            };
        }

        public Childhood ModelToEntiy(ChildhoodViewModel item)
        {
            return new Childhood
            {
                Adress = item.Adress,
                Id = item.Ind,
                Number = item.Number
            };
        }
    }
}