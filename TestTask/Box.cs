namespace TestTask
{
    public class Box
    {
        public int Id { get; }

        private int length;
        public int Length 
        { 
            get { return length; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("length = " + value.ToString());
                length = value;
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("width = " + value.ToString());
                width = value;
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("height = " + value.ToString());
                height = value;
            }
        }

        private int weight;
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("weight = " + value.ToString());
                weight = value;
            }
        }

        public int Volume { get; }

        private DateOnly manufacturingDate;
        public DateOnly ManufacturingDate { get { return manufacturingDate; } private set { manufacturingDate = value; } }

        private DateOnly expirationDate;
        public DateOnly ExpirationDate
        {
            get { return expirationDate; }
            private set
            {
                expirationDate = value.Year == 1 ? manufacturingDate.AddDays(100) : value;
                if (expirationDate < manufacturingDate)
                    throw new ArgumentOutOfRangeException("manufacturingDate > expirationDate " + value.ToString());
            }
        }


        public Box(int id, int length, int width, int height, int weight, DateOnly manufacturingDate, DateOnly expirationDate)
        {
            Id = id;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            Volume = Length * Width * Height;
        }
    }
}
