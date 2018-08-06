namespace NewsSystem.Models.EntityModels
{
    public class Like
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}