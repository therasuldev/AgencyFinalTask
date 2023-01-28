using Core.Interface;

namespace Core.Entities
{
    public class PortfolioModel:IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }  
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
