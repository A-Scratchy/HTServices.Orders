using System.Collections.Generic;

namespace Orders.Application.Interfaces
{
    public interface IRecordList<T>
    {
        ICollection<T> Records { get; set; }
        int Results { get; }
    }
}