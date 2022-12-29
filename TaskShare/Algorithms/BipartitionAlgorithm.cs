namespace TaskShare.Algorithms
{
    public class BipartitionAlgorithm<T> : IPartitionAlgorithm<T>
    {
        public Func<T, int> Predicate { get; set; }
        public int SubsetsCount { get { return 2; } set { if (value != 2) throw new UnsupportedSubsetsCountException(); } }

        public List<List<T>> Run(List<T> input)
        {
            List<List<T>> result = new List<List<T>>();
            result.Add(new List<T>());
            result.Add(new List<T>());
            int sum = 0;

            foreach (T element in input)
                if (Predicate(element) <= 0)
                    throw new OneOfTheWeightNonPositiveException();
                else
                    sum += Predicate(element);

            if (sum % 2 == 1)
                throw new CannotBeSplitException();

            //                                              0..n sum
            HashSet<(int, int)> canCreateSum = new HashSet<(int, int)>();

            for (int i = 0; i <= input.Count; i++)
                canCreateSum.Add((i, 0));

            for (int j = 1; j <= sum / 2; j++)
                for (int i = 1; i <= input.Count; i++)
                    if (canCreateSum.Contains((i - 1, j)) ||
                        canCreateSum.Contains((i - 1, j - Predicate(input[i - 1]))))
                        canCreateSum.Add((i, j));

            if (!canCreateSum.Contains((input.Count, sum / 2)))
                throw new CannotBeSplitException();

            int x = input.Count, y = sum / 2;
            while (x > 0)
            {
                if (canCreateSum.Contains((x - 1, y - Predicate(input[x - 1]))))
                {
                    y -= Predicate(input[x - 1]);
                    result[0].Add(input[x - 1]);
                }
                else
                    result[1].Add(input[x - 1]);
                x--;
            }

            return result;
        }
    }
}
