namespace DatoDescripcion
{
    public class CoinDescriptionModel
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Description Description { get; set; }
        public Image Image { get; set; }
    }

    public class Description
    {
        public string En { get; set; }
    }

    public class Image
    {
        public string Thumb { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
    }

}
