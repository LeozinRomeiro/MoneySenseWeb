namespace MoneySenseWeb.Models
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; } = "";
        public string Type { get; set; }
        public string? TitleWithIcon
        {
            get
            {
                return this.Icon + " " + this.Title;
            }
        }

    }
}
