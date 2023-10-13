namespace PathFinder.Models
{
    public class DroneRouteRequest
    {
        public string StartingPosition { get; set; }
        public string ObjectPosition { get; set; }
        public string DeliveryPoint { get; set; }

        public DroneRouteRequest(string startingPosition, string objectPosition, string deliveryPoint)
        {
            StartingPosition = startingPosition;
            ObjectPosition = objectPosition;
            DeliveryPoint = deliveryPoint;
        }

    }
}
