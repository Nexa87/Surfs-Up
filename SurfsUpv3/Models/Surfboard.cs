namespace SurfsUpv3.Models
{
    public class Surfboard
    {
        public int SurfboardId { get; set; }
        public string BoardName { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Thickness {  get; set; }
        public float Volume { get; set; }

        public int Price { get; set; } // måske vi skal vælge en anden vartype
        public string Equipment { get; set; } // E.g. "Fin, Paddle, Pump, Leash"

        // public BoardType boardType { get; set; }
        // public enum BoardType
        // {
        //     None, Shortboard, Funboard, Fish, Longboard, SUP
        // }

        public Surfboard (int surfboardId, string boardName, float length, float width, float thickness, float volume, /*BoardType boardtype,*/ int price, string equipment)
        {
            SurfboardId = surfboardId;
            BoardName = boardName;
            Length = length;
            Width = width;
            Thickness = thickness;
            Volume = volume;
            //boardType = boardtype;
            Price = price;
            Equipment = equipment;
        }
        public Surfboard()
        {
        }


    }
    
}
