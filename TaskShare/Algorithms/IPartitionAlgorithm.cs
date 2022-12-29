namespace TaskShare.Algorithms
{
    public interface IPartitionAlgorithm<T>
    {
        Func<T, int> Predicate { get; set; }
        int SubsetsCount { get; set; }
        List<List<T>> Run(List<T> input);
    }
}
