using System;

namespace TsetmcLib
{
    public interface IDayCollectionGenearator
    {
        Days GenerateByDate(DateTime date);
        Days GenerateToday();
    }
}