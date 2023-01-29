namespace DataObjects
{
    public class JsonResponse
    {
        public string Locale { get; set; }
        public string Description { get; set; }
        public BoundingPoly boundingPoly { get; set; }

    }
}