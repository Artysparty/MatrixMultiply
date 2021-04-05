using System.Text;

namespace MatrixMultiply
{
    internal class Matrix
    {
        public int Size { get; set; }
        private readonly int[,] _data;


        public Matrix(int size)
        {
            Size = size;
            _data = new int[size, size];
        }

        public int this[int x, int y]
        {
            get => _data[x, y];
            set => _data[x, y] = value;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < Size; i++)
            {
                stringBuilder.Append("[ ");
                for (var j = 0; j < Size; j++)
                {
                    stringBuilder.Append(_data[i, j]);
                    stringBuilder.Append(j == Size - 1 ? " " : ", ");
                }

                stringBuilder.AppendLine("]");
            }

            return stringBuilder.ToString();
        }
    }
}