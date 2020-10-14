namespace MenagerTasker.Core.Entities
{
    public abstract class EntityBase 
    {
        public int Id { get;}

        protected internal EntityBase(int id)
        {
            Id = id;
        }
    }
}
