namespace MinTur.Domain.SearchCriteria
{
    public interface ISearchCriteria<in T>
    {
        bool MatchesCriteria(T businessEntity);
    }
}
