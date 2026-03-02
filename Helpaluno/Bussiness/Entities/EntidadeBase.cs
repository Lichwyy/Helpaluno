namespace Helpaluno.Bussiness.Entities
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public EntidadeBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }
    }
}
