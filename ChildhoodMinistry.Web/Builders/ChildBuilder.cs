using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Model;

namespace ChildhoodMinistry.Web.Builders
{
    public class ChildBuilder : IModelBuilder<ChildViewModel, Child>
    {
        public ChildViewModel EntityToModel(Child item)
        {
            return new ChildViewModel
            {
                Age = item.Age,
                ChildhoodNum = item.ChildhoodId,
                Ind = item.Id,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Surname = item.Surname
            };
        }

        public Child ModelToEntiy(ChildViewModel item)
        {
            return new Child
            {
                Age = item.Age,
                ChildhoodId = item.ChildhoodNum,
                Id = item.Ind,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Surname = item.Surname
            };
        }
    }
}