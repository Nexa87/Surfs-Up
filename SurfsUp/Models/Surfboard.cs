namespace SurfsUpWebApp.Models
{
    public class Surfboard
    {
        public string BoardName { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Thickness {  get; set; }
        public float Volume { get; set; }

        public BoardType boardType;
        public enum BoardType
        {
            None, Shortboard, Funboard, Fish, Longboard, SUP
        }

        public int Price { get; set; }
        public string Equipment { get; set; } // E.g. "Fin, Paddle, Pump, Leash"

        public Surfboard (string boardName, float length, float width, float thickness, float volume, BoardType boardType, int price, string equipment)
        {
            BoardName = boardName;
            Length = length;
            Width = width;
            Thickness = thickness;
            Volume = volume;
            this.boardType = boardType;
            Price = price;
            Equipment = equipment;
        }   
    }
}
