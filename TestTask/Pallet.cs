namespace TestTask
{
    public class Pallet
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
            private set { weight = value <= 0 ? 30 : value; }
        }

        public int TotalWeight { get; private set; }
        public int TotalVolume { get; private set; }

        public List<Box> boxes = new();

        public DateOnly ExpirationDate { get; private set; }

        public Pallet(int id, int length, int width, int height, int weight, List<Box> boxes)
        {
            Id = id;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            TotalWeight += Weight;
            TotalVolume = Length * Width * Height;
            ExpirationDate = DateOnly.FromDateTime(DateTime.Now);

            foreach (Box box in boxes)
            {
                AddBox(box);
            }
        }

        public void AddBox(Box box)
        {
            if (box.Length > Length || box.Width > Width)
                throw new ArgumentOutOfRangeException("Размеры коробки больше размеров паллеты "
                    + box.Length.ToString() + " " + box.Width.ToString() + " " + Length.ToString() + " " + Width.ToString());

            boxes.Add(box);

            TotalWeight += box.Weight;
            TotalVolume += box.Volume;

            if (box.ExpirationDate < ExpirationDate)
                ExpirationDate = box.ExpirationDate;
        }
    }
}
