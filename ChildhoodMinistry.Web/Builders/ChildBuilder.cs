using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Interface;
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
                Id = item.Id,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Surname = item.Surname,
                childhood = new ChildhoodInfo
                {
                    Id = item.Childhood.Id,
                    Number = item.Childhood.Number
                }
            };
        }

        public Child ModelToEntiy(ChildViewModel item)
        {
            return new Child
            {
                Age = item.Age,
                Id = item.Id,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Surname = item.Surname,
                ChildhoodId = item.childhood.Id
            };
        }
    }
}