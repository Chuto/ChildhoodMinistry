namespace ChildhoodMinistry.Data.Model
{
    public class Child : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public int ChildhoodId { get; set; }
        public virtual Childhood Childhood { get; set; }
    }
}
