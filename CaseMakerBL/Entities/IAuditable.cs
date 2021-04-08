using System;

namespace CaseMaker.Entities
{
    public interface IAuditable
    {
        DateTime CreationDate { get; set; }

        DateTime ModDate { get; set; }
    }
}